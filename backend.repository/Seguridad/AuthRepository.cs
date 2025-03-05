using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Seguridad;
using Npgsql;
using NpgsqlTypes;

namespace backend.repository.Seguridad
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LoginDTO> AuthUser(authLoginDTO authLogin)
        {
            //LoginDTO resp = new LoginDTO();

            // Conexión a PostgreSQL
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                // Sentencia SQL que invoca a la función
                var sql = "SELECT * FROM fn_pa_autentication(@sUsuario, @sPassword)";

                // Parámetros
                var parameters = new DynamicParameters();
                parameters.Add("sUsuario", authLogin.sUsuario);
                parameters.Add("sPassword", authLogin.sPassword);

                // Ejecutamos la consulta y mapeamos el resultado a LoginDTO
                var result = await connection.QuerySingleOrDefaultAsync<LoginDTO>(
                    sql,
                    parameters
                );
                return result;
            }
        }   
    }
}
