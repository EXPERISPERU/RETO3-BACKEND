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
    public class OficinaRepository : IOficinaRepository
    {
        private readonly IConfiguration _configuration;

        public OficinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<OficinaDTO>> getListOficinaByCompania(int nIdCompania)
        {
            IEnumerable<OficinaDTO> list = new List<OficinaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<OficinaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
