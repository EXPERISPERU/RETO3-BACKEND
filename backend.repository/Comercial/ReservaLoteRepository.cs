using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class ReservaLoteRepository : IReservaLoteRepository
    {
        private readonly IConfiguration _configuration;

        public ReservaLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioReservaByLote(int nIdLote)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 1);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsReserva(InsReservaDTO insReserva)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 2);
                parameters.Add("nIdLote", insReserva.nIdLote);
                parameters.Add("nIdCliente", insReserva.nIdCliente);
                parameters.Add("nIdPrecioServicio", insReserva.nIdPrecioServicio);
                //parameters.Add("nIdTipoGestionComercial", insReserva.nIdTipoGestionComercial);
                //parameters.Add("nIdEmpleado", insReserva.nIdEmpleado);
                //parameters.Add("nIdAgenteDealer", insReserva.nIdAgenteDealer);
                parameters.Add("nIdUsuario_crea", insReserva.nIdUsuario_crea);
                parameters.Add("nIdMoneda", insReserva.nIdMoneda);
                

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<DataReservaDTO> getDataReserva(int nIdReservaLote)
        {
            DataReservaDTO res = new DataReservaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 3);
                parameters.Add("nIdReservaLote", nIdReservaLote);

                res = await connection.QuerySingleAsync<DataReservaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<string> formatoReciboIngresoReserva()
        {
            string res;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 4);

                res = await connection.QuerySingleAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<DataReservaDTO> getDataReservaByLote(int nIdLote)
        {
            DataReservaDTO res = new DataReservaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 6);
                parameters.Add("nIdLote", nIdLote);

                res = await connection.QuerySingleAsync<DataReservaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reserva_lote]", 7);
                parameters.Add("nIdComprobante", nIdComprobante);
                parameters.Add("sRutaFtp", sRutaFtp);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 13);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
