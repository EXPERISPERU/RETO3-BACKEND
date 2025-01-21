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
using backend.repository.Interfaces.Comercial;

namespace backend.repository.Comercial
{
    public class CarpetaAdministrativaLoteRepository : ICarpetaAdministrativaLoteRepository
    {
        private readonly IConfiguration _configuration;

        public CarpetaAdministrativaLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioCarpetaAdministrativaLote(int nIdLote, decimal nValorInicial, int nIdMoneda)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_carpeta_administrativa_lote]", 1);
                parameters.Add("nIdLote", nIdLote);
                parameters.Add("nValorInicial", nValorInicial);
                parameters.Add("nIdMoneda", nIdMoneda);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }


    }
}
