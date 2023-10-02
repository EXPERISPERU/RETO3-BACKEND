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
    public class PrecioRepository : IPrecioRepository
    {
        private readonly IConfiguration _configuration;

        public PrecioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PrecioDTO>> getListPrecio()
        {
            IEnumerable<PrecioDTO> list = new List<PrecioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio]", 1);

                list = await connection.QueryAsync<PrecioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
