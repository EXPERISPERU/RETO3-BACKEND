using backend.domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using backend.repository.Interfaces.Maestros;

namespace backend.repository.Maestros
{
    public class TipoCambioRepository : ITipoCambioRepository
    {
        private readonly IConfiguration _configuration;

        public TipoCambioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlRspDTO> insTipoCambio(TipoCambioDTO tipocambio)
        {
            SqlRspDTO res = new SqlRspDTO();
            
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_tipo_cambio]", 1);

                parameters.Add("nIdMonedaOrigen", tipocambio.nIdMonedaOrigen);
                parameters.Add("nIdMonedaDestino", tipocambio.nIdMonedaDestino);
                parameters.Add("dFecha", tipocambio.dFecha);
                parameters.Add("nVenta", tipocambio.nVenta);
                parameters.Add("nCompra", tipocambio.nCompra);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
