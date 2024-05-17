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
    public class ComprobanteMedioPagoRepository: IComprobanteMedioPagoRepository
    {
        private readonly IConfiguration _configuration;

        public ComprobanteMedioPagoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ComprobanteMedioPagoDTO>> getListComprobanteMedioPagoByCompania(int nIdCompania)
        {
            IEnumerable<ComprobanteMedioPagoDTO> list = new List<ComprobanteMedioPagoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_comprobante_medio_pago]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ComprobanteMedioPagoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();

        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroMedioPago()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_comprobante_medio_pago]", 2);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_comprobante_medio_pago]", 3);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsComprobanteMedioPago(ComprobanteMedioPagoDTO comprobanteMedioPagoDTO)
        {

            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_comprobante_medio_pago]", 4);
                parameters.Add("nIdCompania", comprobanteMedioPagoDTO.nIdCompania);
                parameters.Add("nIdComprobante", comprobanteMedioPagoDTO.nIdComprobante);
                parameters.Add("nIdMedioPago", comprobanteMedioPagoDTO.nIdMedioPago);
                parameters.Add("nIdUsuario_crea", comprobanteMedioPagoDTO.nIdUsuario_crea);
                parameters.Add("bActivo", comprobanteMedioPagoDTO.bActivo);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;

        }
    }
}
