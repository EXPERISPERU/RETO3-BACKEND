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


        public async Task<SqlRspDTO> InsCarpetaAdministrativaLote(CarpetaAdministrativaLoteDTO instCarpetaAdminLote)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_carpeta_administrativa_lote]", 2);
                parameters.Add("nIdLote", instCarpetaAdminLote.nIdLote);
                parameters.Add("nValorPreContrato", instCarpetaAdminLote.nValorPreContrato);
                parameters.Add("nVigenciaPreContrato", instCarpetaAdminLote.nVigenciaPreContrato);
                parameters.Add("nIdCliente", instCarpetaAdminLote.nIdCliente);
                parameters.Add("nIdTipoComprobante", instCarpetaAdminLote.nIdTipoComprobante);
                parameters.Add("nIdTipoGestionComercial", instCarpetaAdminLote.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", instCarpetaAdminLote.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", instCarpetaAdminLote.nIdEmpleado);
                parameters.Add("nIdMoneda", instCarpetaAdminLote.nIdMoneda);
                parameters.Add("nIdMedioPago", instCarpetaAdminLote.nIdMedioPago);
                parameters.Add("nIdAsignacionPrecio", instCarpetaAdminLote.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", instCarpetaAdminLote.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", instCarpetaAdminLote.nIdInicialLote);
                parameters.Add("nIdInteresCuota", instCarpetaAdminLote.nIdInteresCuota);
                parameters.Add("nMontoVenta", instCarpetaAdminLote.nMontoVenta);
                parameters.Add("nMontoDescuento", instCarpetaAdminLote.nMontoDescuento);
                parameters.Add("nMontoFinal", instCarpetaAdminLote.nMontoFinal);
                parameters.Add("nMontoInicial", instCarpetaAdminLote.nMontoInicial);
                parameters.Add("nMontoInteresCuota", instCarpetaAdminLote.nMontoInteresCuota);
                parameters.Add("nMontoFinanciado", instCarpetaAdminLote.nMontoFinanciado);
                parameters.Add("nValorCuota", instCarpetaAdminLote.nValorCuota);
                parameters.Add("nIdCuota", instCarpetaAdminLote.nIdCuota);
                parameters.Add("nCuotas", instCarpetaAdminLote.nCuotas);
                parameters.Add("nIdUsuario_crea", instCarpetaAdminLote.nIdUsuario_crea);
                parameters.Add("sIdOperacionBancaria", instCarpetaAdminLote.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", instCarpetaAdminLote.sIdOperacionIzzipay);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsAdicCarpetaAdministrativaLote(CarpetaAdministrativaLoteDTO insPreContratoLote)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_carpeta_administrativa_lote]", 3);
                parameters.Add("nIdContrato", insPreContratoLote.nIdContrato);
                parameters.Add("nIdLote", insPreContratoLote.nIdLote);
                parameters.Add("nValorPreContrato", insPreContratoLote.nValorPreContrato);
                parameters.Add("nVigenciaPreContrato", insPreContratoLote.nVigenciaPreContrato);
                parameters.Add("nIdCliente", insPreContratoLote.nIdCliente);
                parameters.Add("nIdTipoComprobante", insPreContratoLote.nIdTipoComprobante);
                parameters.Add("nIdMoneda", insPreContratoLote.nIdMoneda);
                parameters.Add("nIdMedioPago", insPreContratoLote.nIdMedioPago);
                parameters.Add("nMontoFinal", insPreContratoLote.nMontoFinal);
                parameters.Add("nMontoInicial", insPreContratoLote.nMontoInicial);
                parameters.Add("nIdUsuario_crea", insPreContratoLote.nIdUsuario_crea);
                parameters.Add("sIdOperacionBancaria", insPreContratoLote.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", insPreContratoLote.sIdOperacionIzzipay);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }


    }
}
