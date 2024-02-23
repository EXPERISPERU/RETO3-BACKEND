using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Maestros
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly IConfiguration _configuration;

        public DireccionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<DireccionDTO>> getListDireccion(int nIdPersona)
        {
            IEnumerable<DireccionDTO> list = new List<DireccionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_direccion]", 1);
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
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_direccion]", 2);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("nIdVia", direccion.nIdVia);
                parameters.Add("sNombreVia", direccion.sNombreVia);
                parameters.Add("nNumeracion", direccion.nNumeracion);
                parameters.Add("sBlock", direccion.sBlock);
                parameters.Add("nPiso", direccion.nPiso);
                parameters.Add("sDepartamento", direccion.sDepartamento);
                parameters.Add("sSector", direccion.sSector);
                parameters.Add("sManzana", direccion.sManzana);
                parameters.Add("sLote", direccion.sLote);
                parameters.Add("nKm", direccion.nKm);
                parameters.Add("sUrbanizacion", direccion.sUrbanizacion);
                parameters.Add("sReferencia", direccion.sReferencia);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);
                parameters.Add("nIdUsuario_crea", direccion.nIdUsuario_crea);

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
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_direccion]", 3);
                parameters.Add("nIdDireccion", direccion.nIdDireccion);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("nIdVia", direccion.nIdVia);
                parameters.Add("sNombreVia", direccion.sNombreVia);
                parameters.Add("nNumeracion", direccion.nNumeracion);
                parameters.Add("sBlock", direccion.sBlock);
                parameters.Add("nPiso", direccion.nPiso);
                parameters.Add("sDepartamento", direccion.sDepartamento);
                parameters.Add("sSector", direccion.sSector);
                parameters.Add("sManzana", direccion.sManzana);
                parameters.Add("sLote", direccion.sLote);
                parameters.Add("nKm", direccion.nKm);
                parameters.Add("sUrbanizacion", direccion.sUrbanizacion);
                parameters.Add("sReferencia", direccion.sReferencia);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);
                parameters.Add("nIdUsuario_mod", direccion.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectVias()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_direccion]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> UpdDireccionPrincipal(DireccionDTO direccion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_direccion]", 5);
                parameters.Add("nIdDireccion", direccion.nIdDireccion);
                parameters.Add("nIdUsuario_mod", direccion.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
