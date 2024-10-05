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

        public async Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nConvenio)
        {
            IEnumerable<bbvaDocumento> res = new List<bbvaDocumento>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_cronograma]", 2);
                parameters.Add("sDocumento", sDocumento);
                parameters.Add("nConvenio", nConvenio);

                res = await connection.QueryAsync<bbvaDocumento>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<bbvaDocumento> getCronogramaRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdCronograma)
        {
            bbvaDocumento res = new bbvaDocumento();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_cronograma]", 3);
                parameters.Add("nIdCronograma", nIdCronograma);
                parameters.Add("sDocumento", sDocumento);
                parameters.Add("nConvenio", nConvenio);

                res = await connection.QuerySingleOrDefaultAsync<bbvaDocumento>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
