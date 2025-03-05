using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.domain;
using backend.repository.Interfaces.Seguridad;
using Npgsql;

namespace backend.repository.Seguridad
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<UsuarioDTO>> getAllUsuario()
        {
            IEnumerable<UsuarioDTO> list = new List<UsuarioDTO>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                // Definimos el nombre del procedimiento a ejecutar
                string storedProcedure = "SELECT * FROM fn_get_usuarios()";

                // Inicializamos los parámetros para la consulta
                var parameters = new {};

                list = await connection.QueryAsync<UsuarioDTO>(storedProcedure, parameters);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                // Definimos el nombre del procedimiento a ejecutar
                string storedProcedure = "SELECT * FROM fn_create_usuario(@_nIdPersona, @_sUsuario, @_sPassword, @_nIdUsuario_crea)";

                // Inicializamos los parámetros para la consulta
                var parameters = new
                {
                    _nIdPersona = usuario.nIdPersona,
                    _sUsuario = usuario.sUsuario,
                    _sPassword = usuario.sPassword,
                    _nIdUsuario_crea = usuario.nIdUsuario_crea
                };

                // Ejecutamos el procedimiento y obtenemos el resultado
                var result = await connection.QuerySingleOrDefaultAsync<SqlRspDTO>(storedProcedure, parameters);

                // Asignamos el resultado a la respuesta
                resp = result ?? new SqlRspDTO { sMsj = "Error al registrar el usuario." };
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                // Definimos el nombre del procedimiento a ejecutar
                string storedProcedure = "SELECT * FROM fn_update_usuario(@_nIdUsuario, @_sUsuario, @_sPassword, @_bActivo, @_nIdUsuario_mod)";

                // Inicializamos los parámetros para la consulta
                var parameters = new
                {
                    _nIdUsuario = usuario.nIdUsuario,
                    _sUsuario = usuario.sUsuario,
                    _sPassword = usuario.sPassword,
                    _bActivo = usuario.bActivo,
                    _nIdUsuario_mod = usuario.nIdUsuario_mod
                };

                // Ejecutamos el procedimiento y obtenemos el resultado
                resp = await connection.QuerySingleOrDefaultAsync<SqlRspDTO>(storedProcedure, parameters);
            }
            return resp;
        }

        public async Task<SqlRspDTO> dltUsuario(int nIdUsuario)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                // Definimos el nombre del procedimiento a ejecutar
                string storedProcedure = "SELECT * FROM fn_delete_usuario(@_nIdUsuario)";

                // Inicializamos los parámetros para la consulta
                var parameters = new
                {
                    _nIdUsuario = nIdUsuario
                };

                // Ejecutamos el procedimiento y obtenemos el resultado
                resp = await connection.QuerySingleOrDefaultAsync<SqlRspDTO>(storedProcedure, parameters);
            }
            return resp;
        }

        public async Task<UsuarioDTO> getUserById( int nIdUsuario )
        {
            UsuarioDTO resp = new UsuarioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_usuario]", 14);
                parameters.Add("nIdUsuario", nIdUsuario);

                resp = await connection.QuerySingleAsync<UsuarioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return resp;
        }

    }
}
