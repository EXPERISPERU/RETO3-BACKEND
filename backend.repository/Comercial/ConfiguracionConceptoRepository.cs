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
    public class ConfiguracionConceptoRepository : IConfiguracionConceptoRepository
    {
        private readonly IConfiguration _configuration;

        public ConfiguracionConceptoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ElementoSistemaDTO>> getListTipoComprante()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 1);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto)
        {
            IEnumerable<ConfiguracionConceptoDTO> list = new List<ConfiguracionConceptoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 2);
                parameters.Add("nIdproyecto", nIdproyecto);

                list = await connection.QueryAsync<ConfiguracionConceptoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
