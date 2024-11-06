using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class CuotaLoteRepository : ICuotaLoteRepository
    {
        private readonly IConfiguration _configuration;

        public CuotaLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos()
        {
            IEnumerable<CuotaLoteDTO> list = new List<CuotaLoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cuota_lote]", 1);

                list = await connection.QueryAsync<CuotaLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote)
        {
            CuotaLoteDTO resp = new CuotaLoteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cuota_lote]", 2);
                parameters.Add("nIdCuotaLote", nIdCuotaLote);

                resp = await connection.QuerySingleOrDefaultAsync<CuotaLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cuota_lote]", 3);
                parameters.Add("nCuotas", cuotaLote.nCuotas);
                parameters.Add("nIdUsuario_crea", cuotaLote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
