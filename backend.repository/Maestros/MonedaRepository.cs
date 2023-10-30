using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Maestros
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly IConfiguration _configuration;

        public MonedaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<MonedaDTO>> getListMoneda()
        {
            IEnumerable<MonedaDTO> list = new List<MonedaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_moneda]", 1);

                list = await connection.QueryAsync<MonedaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<MonedaDTO> getMonedaByID(int nIdMoneda)
        {
            MonedaDTO res = new MonedaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_moneda]", 2);
                parameters.Add("nIdMoneda", nIdMoneda);

                res = await connection.QuerySingleAsync<MonedaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsMoneda(MonedaDTO moneda)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_moneda]", 3);
                parameters.Add("sMoneda", moneda.sMoneda);
                parameters.Add("sSimbolo", moneda.sSimbolo);
                parameters.Add("nIdUsuario_crea", moneda.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdMoneda(MonedaDTO moneda)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_moneda]", 4);
                parameters.Add("nIdMoneda", moneda.nIdMoneda);
                parameters.Add("sMoneda", moneda.sMoneda);
                parameters.Add("sSimbolo", moneda.sSimbolo);
                parameters.Add("nIdUsuario_mod", moneda.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
