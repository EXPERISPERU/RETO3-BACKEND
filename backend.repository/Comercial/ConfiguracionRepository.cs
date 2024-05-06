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

        //FUNCION AGREGAR CONFIGURACION
        public async Task<SqlRspDTO> InsConfiguracion(ConfiguracionDTO configuracion)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 2);
                parameters.Add("nIdConfiguracion", configuracion.nIdConfiguracion);
                parameters.Add("nIdProyecto", configuracion.nIdProyecto);
                parameters.Add("nIdMoneda", configuracion.nIdMoneda);
                parameters.Add("bImpuestoVenta", configuracion.bImpuestoVenta);
                parameters.Add("sIdInteres", configuracion.sIdInteres);
                parameters.Add("sIdDocumentoVenta", configuracion.sIdDocumentoVenta);
                parameters.Add("nIdUsuario_crea", configuracion.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }


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

        public async Task<IList<ItemCompaniaDTO>> getListConceptoVenta(int nIdCompania)
        {
            IEnumerable<ItemCompaniaDTO> list = new List<ItemCompaniaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 4);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ItemCompaniaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<SqlRspDTO> InsSistemaConfiguracionConcepto(ConfiguracionConceptoDTO configuracionConcepto)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 6);
                parameters.Add("nIdProyecto", configuracionConcepto.nIdproyecto);
                parameters.Add("nIdConfiguracion", configuracionConcepto.nIdConfiguracion);
                //parameters.Add("nIdConceptoVenta", configuracionConcepto.nIdConceptoVenta);
                parameters.Add("arrayConceptoVenta", configuracionConcepto.sConceptoVenta);
                parameters.Add("nIdUsuario_crea", configuracionConcepto.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<CompaniaMonedaDTO>> getListMonedaByCompania(int nIdCompania)
        {
            IEnumerable<CompaniaMonedaDTO> list = new List<CompaniaMonedaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 7);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<CompaniaMonedaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ImpuestosVentaDTO>> getListImpuestoVenta(int nIdCompania)
        {
            IEnumerable<ImpuestosVentaDTO> list = new List<ImpuestosVentaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_configuracion]", 8);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ImpuestosVentaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
