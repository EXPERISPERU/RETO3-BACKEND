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
    public class VentaLoteRepository : IVentaLoteRepository
    {
        private readonly IConfiguration _configuration;

        public VentaLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_venta_lote]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectCicloPago(int nIdLote)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_venta_lote]", 2);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsVentaLote(InsVentaLoteDTO insVentaLoteDTO)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_venta_lote]", 3);
                parameters.Add("nIdLote", insVentaLoteDTO.nIdLote);
                parameters.Add("nIdCliente", insVentaLoteDTO.nIdCliente);
                parameters.Add("nIdContrato", insVentaLoteDTO.nIdContrato);
                parameters.Add("nValorContrato", insVentaLoteDTO.nValorContrato);
                parameters.Add("nTipoFinanciamiento", insVentaLoteDTO.nTipoFinanciamiento);
                parameters.Add("nIdTipoGestionComercial", insVentaLoteDTO.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", insVentaLoteDTO.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", insVentaLoteDTO.nIdEmpleado);
                parameters.Add("nIdMoneda", insVentaLoteDTO.nIdMoneda);
                parameters.Add("nMedioPago", insVentaLoteDTO.nMedioPago);
                parameters.Add("nIdAsignacionPrecio", insVentaLoteDTO.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", insVentaLoteDTO.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", insVentaLoteDTO.nIdInicialLote);
                parameters.Add("nMontoVenta", insVentaLoteDTO.nMontoVenta);
                parameters.Add("nMontoDescuento", insVentaLoteDTO.nMontoDescuento);
                parameters.Add("nMontoFinal", insVentaLoteDTO.nMontoFinal);
                parameters.Add("nMontoInicial", insVentaLoteDTO.nMontoInicial);
                parameters.Add("nMontoFinanciado", insVentaLoteDTO.nMontoFinanciado);
                parameters.Add("nValorCuota", insVentaLoteDTO.nValorCuota);
                parameters.Add("nIdCuota", insVentaLoteDTO.nIdCuota);                   
                parameters.Add("nCuotas", insVentaLoteDTO.nCuotas);
                parameters.Add("nIdCicloPago", insVentaLoteDTO.nIdCicloPago);
                parameters.Add("nIdUsuario_crea", insVentaLoteDTO.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
