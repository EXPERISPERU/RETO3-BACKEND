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
    public class PreContratoLoteRepository : IPreContratoLoteRepository
    {
        private readonly IConfiguration _configuration;

        public PreContratoLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioPreContratoByLoteInicial(int nIdLote, decimal nValorInicial, int nIdMoneda)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 1);
                parameters.Add("nIdLote", nIdLote);
                parameters.Add("nValorInicial", nValorInicial);
                parameters.Add("nIdMoneda", nIdMoneda);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsPreContratoLote(InsPreContratoLoteDTO insPreContratoLote)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 2);
                parameters.Add("nIdLote", insPreContratoLote.nIdLote);
                parameters.Add("nValorPreContrato", insPreContratoLote.nValorPreContrato);
                parameters.Add("nVigenciaPreContrato", insPreContratoLote.nVigenciaPreContrato);
                parameters.Add("nIdCliente", insPreContratoLote.nIdCliente);
                parameters.Add("nIdTipoComprobante", insPreContratoLote.nIdTipoComprobante);
                parameters.Add("nIdTipoGestionComercial", insPreContratoLote.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", insPreContratoLote.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", insPreContratoLote.nIdEmpleado);
                parameters.Add("nIdMoneda", insPreContratoLote.nIdMoneda);
                parameters.Add("nIdMedioPago", insPreContratoLote.nIdMedioPago);
                parameters.Add("nIdAsignacionPrecio", insPreContratoLote.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", insPreContratoLote.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", insPreContratoLote.nIdInicialLote);
                parameters.Add("nIdInteresCuota", insPreContratoLote.nIdInteresCuota);
                parameters.Add("nMontoVenta", insPreContratoLote.nMontoVenta);
                parameters.Add("nMontoDescuento", insPreContratoLote.nMontoDescuento);
                parameters.Add("nMontoFinal", insPreContratoLote.nMontoFinal);
                parameters.Add("nMontoInicial", insPreContratoLote.nMontoInicial);
                parameters.Add("nMontoInteresCuota", insPreContratoLote.nMontoInteresCuota);
                parameters.Add("nMontoFinanciado", insPreContratoLote.nMontoFinanciado);
                parameters.Add("nValorCuota", insPreContratoLote.nValorCuota);
                parameters.Add("nIdCuota", insPreContratoLote.nIdCuota);
                parameters.Add("nCuotas", insPreContratoLote.nCuotas);
                parameters.Add("nIdUsuario_crea", insPreContratoLote.nIdUsuario_crea);
                parameters.Add("sIdOperacionBancaria", insPreContratoLote.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", insPreContratoLote.sIdOperacionIzzipay);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ContratoDTO> getDataPreContratoByLote(int nIdLote, int nIdProyecto, int nIdUsuario)
        {
            ContratoDTO res = new ContratoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 4);
                parameters.Add("nIdLote", nIdLote);
                parameters.Add("nIdProyecto", nIdProyecto);

                res = await connection.QuerySingleAsync<ContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<OrdenPagoPreContratoDTO>> getListOPsPreContratoByContrato(int nIdContrato, int nIdMoneda)
        {
            IEnumerable<OrdenPagoPreContratoDTO> list = new List<OrdenPagoPreContratoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 5);
                parameters.Add("nIdContrato", nIdContrato);
                parameters.Add("nIdMoneda", nIdMoneda);

                list = await connection.QueryAsync<OrdenPagoPreContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> postInsAdicPreContratoLote(InsPreContratoLoteDTO insPreContratoLote)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 8);
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

        public async Task<IList<PreContratoChartDTO>> postListPreContratoChart(PreContratoChartFilterDTO preContratoFilter)
        {
            IEnumerable<PreContratoChartDTO> list = new List<PreContratoChartDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precontrato_lote]", 9);
                parameters.Add("nIdUsuario", preContratoFilter.nIdUsuario);
                parameters.Add("nIdCompania", preContratoFilter.nIdCompania);
                parameters.Add("nIdTipoFilter", preContratoFilter.nIdTipoFilter);
                
                parameters.Add("nIdProyecto", preContratoFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", preContratoFilter.sCodTrimestre);
                parameters.Add("sMes", preContratoFilter.sMes);
                parameters.Add("sAno", preContratoFilter.sAno);
                parameters.Add("nIdSubordinado", preContratoFilter.nIdSubordinado);
                parameters.Add("nIdProveedor", preContratoFilter.nIdProveedor);
                parameters.Add("nTipoMonto", preContratoFilter.nTipoMonto);

                list = await connection.QueryAsync<PreContratoChartDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }
    }
}
