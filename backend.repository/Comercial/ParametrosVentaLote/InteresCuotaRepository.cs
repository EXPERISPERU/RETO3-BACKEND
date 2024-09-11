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
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class InteresCuotaRepository : IInteresCuotaRepository
    {
        private readonly IConfiguration _configuration;

        public InteresCuotaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<InteresCuotaDTO>> getListInteresCuota()
        {
            IEnumerable<InteresCuotaDTO> list = new List<InteresCuotaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 1);

                list = await connection.QueryAsync<InteresCuotaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<InteresCuotaDTO> getInteresCuotaByID(int nIdInteresCuota)
        {
            InteresCuotaDTO resp = new InteresCuotaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 2);
                parameters.Add("nIdInteresCuota", nIdInteresCuota);

                resp = await connection.QuerySingleOrDefaultAsync<InteresCuotaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectTipoInteres()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 4);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 6);
                parameters.Add("nIdTipoInteres", interesCuota.nIdTipoInteres);
                parameters.Add("nIdTipoValor", interesCuota.nIdTipoValor);
                parameters.Add("nValor", interesCuota.nValor);
                parameters.Add("nIdMoneda", interesCuota.nIdMoneda);
                parameters.Add("nIdUsuario_crea", interesCuota.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
