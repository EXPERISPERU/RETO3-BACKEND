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

        public async Task<IList<tipoComprobante>> getListTipoComprante()
        {
            IEnumerable<tipoComprobante> list = new List<tipoComprobante>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 1);
                list = await connection.QueryAsync<tipoComprobante>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
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


        public async Task<IList<ElementoSistemaDTO>> getListMedioPago()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 3);
                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> postInsConfiguracionConcepto(ConfiguracionConceptoDTO configuracion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 4);
                parameters.Add("nIdproyecto", configuracion.nIdproyecto);
                parameters.Add("nIdConceptoVenta", configuracion.nIdConceptoVenta);
                parameters.Add("sIdTipoComprobanteMedioPago", configuracion.sIdTipoComprobanteMedioPago);
                parameters.Add("bActivo", configuracion.bActivo);
                parameters.Add("nIdUsuario_mod", configuracion.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdproyecto, int nIdConceptoVenta)
        {
            IEnumerable<ConfiguracionConceptoDTO> list = new List<ConfiguracionConceptoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 5);
                parameters.Add("nIdproyecto", nIdproyecto);
                parameters.Add("nIdConceptoVenta", nIdConceptoVenta);

                list = await connection.QueryAsync<ConfiguracionConceptoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<JsonFormatDTO>> getComprobanteMedioPago(int nIdCompania)
        {
            IEnumerable<JsonFormatDTO> list = new List<JsonFormatDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion_concepto]", 6);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<JsonFormatDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
