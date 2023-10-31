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
    public class CompaniaMonedaRepository : ICompaniaMonedaRepository
    {
        private readonly IConfiguration _configuration;

        public CompaniaMonedaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CompaniaMonedaDTO>> getListMonedaByCompania(int nIdCompania)
        {
            IEnumerable<CompaniaMonedaDTO> list = new List<CompaniaMonedaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania_moneda]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<CompaniaMonedaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<MonedaDTO>> getListMonedaDispByCompania(int nIdCompania)
        {
            IEnumerable<MonedaDTO> list = new List<MonedaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania_moneda]", 2);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<MonedaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsCompaniaMoneda(CompaniaMonedaDTO companiaMoneda)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania_moneda]", 3);
                parameters.Add("nIdCompania", companiaMoneda.nIdCompania);
                parameters.Add("nIdMoneda", companiaMoneda.nIdMoneda);
                parameters.Add("nIdUsuario_crea", companiaMoneda.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> DesActMoneda(CompaniaMonedaDTO companiaMoneda)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania_moneda]", 4);
                parameters.Add("nIdCompania", companiaMoneda.nIdCompania);
                parameters.Add("nIdMoneda", companiaMoneda.nIdMoneda);
                parameters.Add("bActivo", companiaMoneda.bActivo);
                parameters.Add("nIdUsuario_mod", companiaMoneda.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdMonedaPrincipal(CompaniaMonedaDTO companiaMoneda)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania_moneda]", 5);
                parameters.Add("nIdCompania", companiaMoneda.nIdCompania);
                parameters.Add("nIdMoneda", companiaMoneda.nIdMoneda);
                parameters.Add("nIdUsuario_mod", companiaMoneda.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
