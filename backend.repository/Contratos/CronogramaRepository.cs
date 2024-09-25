using backend.domain;
using backend.repository.Interfaces.Contratos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Contratos
{
    public class CronogramaRepository : ICronogramaRepository
    {
        private readonly IConfiguration _configuration;
        
        public CronogramaRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto)
        {
            IEnumerable<bbvaDocumento> res = new List<bbvaDocumento>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_cronograma]", 2);
                parameters.Add("sDocumento", sDocumento);
                parameters.Add("nCodigoProyecto", nCodigoProyecto);

                res = await connection.QueryAsync<bbvaDocumento>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }
    }
}
