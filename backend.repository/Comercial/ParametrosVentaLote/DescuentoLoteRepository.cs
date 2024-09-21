using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class DescuentoLoteRepository : IDescuentoLoteRepository
    {
        private readonly IConfiguration _configuration;

        public DescuentoLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<DescuentoLoteDTO>> getListDescuentoLote()
        {
            IEnumerable<DescuentoLoteDTO> list = new List<DescuentoLoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 1);

                list = await connection.QueryAsync<DescuentoLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote)
        {
            DescuentoLoteDTO resp = new DescuentoLoteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 2);
                parameters.Add("nIdDescuentoLote", nIdDescuentoLote);

                resp = await connection.QuerySingleOrDefaultAsync<DescuentoLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMoneda()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 5);
                parameters.Add("nIdTipo", descuentoLote.nIdTipo);
                parameters.Add("nValor", descuentoLote.nValor);
                parameters.Add("nIdMoneda", descuentoLote.nIdMoneda);
                parameters.Add("nIdUsuario_crea", descuentoLote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
