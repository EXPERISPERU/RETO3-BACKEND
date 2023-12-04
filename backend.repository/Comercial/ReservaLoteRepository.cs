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
                parameters.Add("nIdUsuario_crea", insReserva.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
