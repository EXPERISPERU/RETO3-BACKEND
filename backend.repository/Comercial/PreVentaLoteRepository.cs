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
    public class PreVentaLoteRepository : IPreVentaLoteRepository
    {
        private readonly IConfiguration _configuration;

        public PreVentaLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioPreVentaByLoteInicial(int nIdLote, decimal nValorInicial)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_preventa_lote]", 1);
                parameters.Add("nIdLote", nIdLote);
                parameters.Add("nValorInicial", nValorInicial);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsPreventaLote(InsPreVentaLoteDTO insPreventaLote)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_preventa_lote]", 2);
                parameters.Add("nIdLote", insPreventaLote.nIdLote);
                parameters.Add("nValorPreventa", insPreventaLote.nValorPreventa);
                parameters.Add("nIdCliente", insPreventaLote.nIdCliente);
                parameters.Add("nIdTipoGestionComercial", insPreventaLote.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", insPreventaLote.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", insPreventaLote.nIdEmpleado);
                parameters.Add("nIdMoneda", insPreventaLote.nIdMoneda);
                parameters.Add("nIdAsignacionPrecio", insPreventaLote.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", insPreventaLote.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", insPreventaLote.nIdInicialLote);
                parameters.Add("nMontoVenta", insPreventaLote.nMontoVenta);
                parameters.Add("nMontoDescuento", insPreventaLote.nMontoDescuento);
                parameters.Add("nMontoFinal", insPreventaLote.nMontoFinal);
                parameters.Add("nMontoInicial", insPreventaLote.nMontoInicial);
                parameters.Add("nMontoFinanciado", insPreventaLote.nMontoFinanciado);
                parameters.Add("nCuotas", insPreventaLote.nCuotas);
                parameters.Add("nIdUsuario_crea", insPreventaLote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
