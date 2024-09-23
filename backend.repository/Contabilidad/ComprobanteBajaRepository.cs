using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Contabilidad
{
    public class ComprobanteBajaRepository : IComprobanteBajaRepository
    {
        private readonly IConfiguration _configuration;

        public ComprobanteBajaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ComprobanteDTO>> getComprobanteById(int nIdComprobante)
        {

            IEnumerable<ComprobanteDTO> list = new List<ComprobanteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 1);
                parameters.Add("nIdComprobante", nIdComprobante);

                list = await connection.QueryAsync<ComprobanteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoMotivos()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 2);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }
    }
}
