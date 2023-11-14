using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using backend.repository.Interfaces.Maestros;

namespace backend.repository.Maestros
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IConfiguration _configuration;

        public PersonaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<DireccionDTO>> getListDireccion(int nIdPersona)
        {
            IEnumerable<DireccionDTO> list = new List<DireccionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_persona]", 1);
                parameters.Add("nIdPersona", nIdPersona);

                list = await connection.QueryAsync<DireccionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsDireccion(DireccionDTO direccion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_persona]", 2);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_persona]", 3);
                parameters.Add("nIdDireccion", direccion.nIdDireccion);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<int> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_persona]", 4);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);
                parameters.Add("sRUC", sRUC);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
