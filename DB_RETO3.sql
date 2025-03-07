
CREATE DATABASE DB_RETO3;

CREATE EXTENSION IF NOT EXISTS pgcrypto;


CREATE USER bestrada WITH ENCRYPTED PASSWORD '1234';


GRANT ALL PRIVILEGES ON DATABASE DB_RETO3 TO bestrada;

CREATE TABLE "Usuarios" (
    "nIdUsuario" SERIAL PRIMARY KEY,
    "nIdPersona" INTEGER NOT NULL,
    "sUsuario" TEXT UNIQUE NOT NULL,
    "sPassword" TEXT NOT NULL,
 	"bActivo" BOOLEAN NULL DEFAULT TRUE,
    "nIdUsuario_crea" INTEGER NOT NULL,
    "dFecha_crea" TIMESTAMP NOT NULL DEFAULT NOW(),
    "nIdUsuario_mod" INTEGER NULL,
    "dFecha_mod" TIMESTAMP NULL
);


CREATE TABLE "Personas" (
    "nIdPersona" SERIAL PRIMARY KEY,
    "sPriNombre" TEXT NULL,
    "sSegNombre" TEXT NULL,
    "sApePaterno" TEXT NULL,
    "sApeMaterno" TEXT NULL,
    "sNombreCompleto" TEXT NULL,
    "dFechaNac" DATE NULL,
    "nIdGenero" INTEGER NULL,
    "nIdEstadoCivil" INTEGER NULL,
    "sDNI" TEXT NULL,
    "sCE" TEXT NULL,
    "sRUC" TEXT NULL,
    "nIdUsuario_crea" INTEGER NOT NULL,
    "dFecha_crea" TIMESTAMP NOT NULL DEFAULT NOW(),
    "nIdUsuario_mod" INTEGER NULL,
    "dFecha_mod" TIMESTAMP NULL
);

ALTER TABLE "Usuarios" ADD CONSTRAINT "FK_Usuarios_Persona" FOREIGN KEY ("nIdPersona") REFERENCES "Personas"("nIdPersona");

INSERT INTO "Personas" (
    "sPriNombre",
    "sSegNombre",
    "sApePaterno",
    "sApeMaterno",
    "sNombreCompleto",
    "dFechaNac",
    "nIdGenero",
    "nIdEstadoCivil",
    "sDNI",
    "sCE",
    "sRUC",
    "nIdUsuario_crea",
    "dFecha_crea",
    "nIdUsuario_mod",
    "dFecha_mod"
) VALUES (
    'LUIS',
    'ANDRES',
    'LOPEZ',
    'BACKERIZO',
    'LUIS ANDRES LOPEZ BACKERIZO',
    '1998-10-04',
    1,
    2,
    '12345678',
    NULL,
    NULL,
    1,
    NOW(),
    NULL,
    NULL
)



INSERT INTO "Usuarios" (
    "nIdPersona",
    "sUsuario",
    "sPassword",
    "nIdUsuario_crea",
    "dFecha_crea",
    "nIdUsuario_mod",
    "dFecha_mod",
	"bActivo"
) VALUES (
    1,
    'llopez',
    pgp_sym_encrypt('123456', 'ERP_0620'),
    1,
    NOW(),
    NULL,
    NULL,
	true
)


// AUTHENTICATION
CREATE OR REPLACE FUNCTION fn_pa_autentication(
    susuario TEXT,
    spassword TEXT
)
RETURNS TABLE(
    "nIdUsuario" INT,
	"sUsuario" TEXT,
    "sNombreCompleto" TEXT,
    "nIdPersona" INT,
	"dFechaNac" date,
    "sMsj" TEXT
)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY
    SELECT 
        U."nIdUsuario",
		U."sUsuario",
        PU."sNombreCompleto",
        PU."nIdPersona",
		PU."dFechaNac",
        CASE 
            WHEN U."nIdUsuario" IS NULL THEN 'Usuario y/o clave errónea.'
            ELSE ''
        END AS sMsj
    FROM "Usuarios" U
    INNER JOIN "Personas" PU ON PU."nIdPersona" = U."nIdPersona"
    WHERE U."sUsuario" = susuario
      AND pgp_sym_decrypt(U."sPassword"::bytea, 'ERP_0620') = spassword;

    IF NOT FOUND THEN
        RETURN QUERY
        SELECT 0, ''::TEXT, ''::TEXT, 0, NULL::date, 'Usuario y/o clave errónea.'::TEXT;
    END IF;
END;
$$;


CREATE OR REPLACE FUNCTION fn_get_usuarios()
RETURNS TABLE(
    nIdUsuario INTEGER
    ,sUsuario TEXT
    ,sNombreCompleto TEXT
    ,bActivo BOOLEAN
	,nIdPersona INTEGER
)  
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY 
    SELECT 
        u."nIdUsuario",
        u."sUsuario",
        CONCAT(p."sPriNombre", ' ', p."sSegNombre", ' ', p."sApePaterno", '', p."sApeMaterno") AS sNombreCompleto,
        u."bActivo",
		p."nIdPersona"
    FROM "Usuarios" u
    INNER JOIN "Personas" p ON u."nIdPersona" = p."nIdPersona";
END;
$$;

CREATE OR REPLACE FUNCTION fn_create_usuario(
    _nIdPersona INTEGER,
    _sUsuario TEXT,
    _sPassword TEXT,
    _nIdUsuario_crea INTEGER
)
RETURNS TABLE(nCod INTEGER, sMsj TEXT)
LANGUAGE plpgsql
AS $$
DECLARE
    nCount INTEGER := 0;
BEGIN

    SELECT COUNT(*) INTO nCount FROM "Usuarios" WHERE "sUsuario" = _sUsuario;

    IF nCount > 0 THEN
        sMsj := 'Hay un usuario con este nombre';
        RETURN QUERY SELECT nCod, sMsj;
        RETURN;
    END IF;

    INSERT INTO "Usuarios"(
        "nIdPersona",
        "sUsuario",
        "sPassword",
        "nIdUsuario_crea",
        "dFecha_crea"
    )
    VALUES (
        _nIdPersona,
        _sUsuario,
        pgp_sym_encrypt(_sPassword, 'ERP_0620'),
        _nIdUsuario_crea,
        now()
    )
    RETURNING "nIdUsuario" INTO nCod;

    sMsj := 'Usuario registrado satisfactoriamente';

    RETURN QUERY SELECT nCod, sMsj;
END;
$$;


CREATE OR REPLACE FUNCTION fn_update_usuario(
    _nIdUsuario INTEGER
    ,_sUsuario TEXT
    ,_sPassword TEXT
	,_bActivo BOOLEAN
    ,_nIdUsuario_mod INTEGER
)
RETURNS TABLE(nCod INTEGER, sMsj TEXT)
LANGUAGE plpgsql
AS $$
DECLARE
    nCount INTEGER := 0;
BEGIN

    SELECT COUNT(*) INTO nCount FROM "Usuarios" WHERE "nIdUsuario" = _nIdUsuario;
    IF nCount = 0 THEN
        sMsj := 'No se encontró el usuario';
        RETURN QUERY SELECT _nIdUsuario, sMsj;
        RETURN;
    END IF;

    UPDATE "Usuarios"
    SET
        "sUsuario" = _sUsuario
        ,"sPassword" = pgp_sym_encrypt(_sPassword, 'ERP_0620')
		,"bActivo" = _bActivo
        ,"nIdUsuario_mod" = _nIdUsuario_mod
        ,"dFecha_mod" = now()
    WHERE "nIdUsuario" = _nIdUsuario
    RETURNING "nIdUsuario" INTO nCod;

    sMsj := 'Usuario actualizado satisfactoriamente';

    RETURN QUERY SELECT nCod, sMsj;
END;
$$;



CREATE OR REPLACE FUNCTION fn_delete_usuario(
    _nIdUsuario INTEGER
)
RETURNS TABLE(nCod INTEGER, sMsj TEXT)
LANGUAGE plpgsql
AS $$
DECLARE
    nCount INTEGER := 0;
BEGIN
	SELECT COUNT(*) INTO nCount FROM "Usuarios" WHERE "nIdUsuario" = _nIdUsuario;

	IF nCount = 0 THEN
		sMsj := 'No se encontró el usuario';
		RETURN QUERY SELECT _nIdUsuario, sMsj;
		RETURN;
	END IF;

	DELETE FROM "Usuarios"
	WHERE "nIdUsuario" = _nIdUsuario
	RETURNING "nIdUsuario" INTO nCod;

	sMsj := 'Usuario eliminado satisfactoriamente';

	RETURN QUERY SELECT nCod, sMsj;
END;
$$;