using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial
{
    public class ConfiguracionRepository: IConfiguracionRepository
    {
        private readonly IConfiguration _configuration;

        public ConfiguracionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ConfiguracionDTO>> getConfiguracionByIdProyecto(int nIdproyecto)
        {

            IEnumerable<ConfiguracionDTO> list = new List<ConfiguracionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 1);
                parameters.Add("nIdproyecto", nIdproyecto);

                list = await connection.QueryAsync<ConfiguracionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        
        }

        public async Task<IList<ElementoSistemaDTO>> getListConceptoVenta()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 4);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ElementoSistemaDTO>> getListDocumentoVenta()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 5);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }



        //FUNCION AGREGAR CONFIGURACION






        public async Task<IList<ElementoSistemaDTO>> getListInteres()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 3);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
