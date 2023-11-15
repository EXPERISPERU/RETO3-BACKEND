using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial
{
    public class LotesDisponiblesRepository : ILotesDisponiblesRepository
    {
        private readonly IConfiguration _configuration;

        public LotesDisponiblesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania)
        {
            IEnumerable<LotesDisponiblesDTO> list = new List<LotesDisponiblesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
