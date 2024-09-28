using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Contabilidad
{
    public class OrdenPagoRepository : IOrdenPagoRepository
    {
        private readonly IConfiguration _configuration;

        public OrdenPagoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<OrdenPagoDTO>> getListOrdenPago(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<OrdenPagoDTO> res = new List<OrdenPagoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_orden_pago]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                res = await connection.QueryAsync<OrdenPagoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<OrdenPagoDTO> getOrdenPagoById(int nIdOrdenPago)
        {
            OrdenPagoDTO res = new OrdenPagoDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_orden_pago]", 2);
                parameters.Add("nIdOrdenPago", nIdOrdenPago);

                res = await connection.QuerySingleOrDefaultAsync<OrdenPagoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<List<OrdenPagoDetDTO>> getListOrdenPagoDet(int nIdOrdenPago)
        {
            IEnumerable<OrdenPagoDetDTO> res = new List<OrdenPagoDetDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_orden_pago]", 3);
                parameters.Add("nIdOrdenPago", nIdOrdenPago);

                res = await connection.QueryAsync<OrdenPagoDetDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<List<bbvaDocumento>> getListOrdenPagoRecaudoBBVAbyDocumento(string sDocumento, int nConvenio)
        {
            IEnumerable<bbvaDocumento> res = new List<bbvaDocumento>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_orden_pago]", 4);
                parameters.Add("sDocumento", sDocumento);
                parameters.Add("nConvenio", nConvenio);

                res = await connection.QueryAsync<bbvaDocumento>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<bbvaDocumento> getOrdenPagoRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdOrdenPago)
        {
            bbvaDocumento res = new bbvaDocumento(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_orden_pago]", 5);
                parameters.Add("nIdOrdenPago", nIdOrdenPago);
                parameters.Add("sDocumento", sDocumento);
                parameters.Add("nConvenio", nConvenio);

                res = await connection.QuerySingleOrDefaultAsync<bbvaDocumento>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
