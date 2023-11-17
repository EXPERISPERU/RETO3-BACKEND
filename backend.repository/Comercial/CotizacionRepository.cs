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
    public class CotizacionRepository : ICotizacionRepository
    {
        private readonly IConfiguration _configuration;

        public CotizacionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 1);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 2);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 3);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 4);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion)
        {
            CotizacionDTO res = new CotizacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 5);
                parameters.Add("nIdLote", cotizacion.nIdLote);
                parameters.Add("nIdAsignacionPrecio", cotizacion.nIdAsignacionPrecio);
                parameters.Add("nIdCuota", cotizacion.nIdCuota);
                parameters.Add("nIdInicial", cotizacion.nIdInicial);
                parameters.Add("nIdDescuentoFin", cotizacion.nIdDescuentoFin);
                parameters.Add("nIdDescuentoCon", cotizacion.nIdDescuentoCon);

                res = await connection.QuerySingleAsync<CotizacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion) 
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 6);
                parameters.Add("nIdLote", cotizacion.nIdLote);
                parameters.Add("nIdCliente", cotizacion.nIdCliente);
                parameters.Add("nIdMoneda", cotizacion.nIdMoneda);
                parameters.Add("nIdAsignacionPrecio", cotizacion.nIdAsignacionPrecio);
                parameters.Add("nPrecioVenta", cotizacion.nPrecioVenta);
                parameters.Add("nIdInicial", cotizacion.nIdInicial);
                parameters.Add("nInicial", cotizacion.nInicial);
                parameters.Add("nIdDescuentoFin", cotizacion.nIdDescuentoFin);
                parameters.Add("nDescuentoFin", cotizacion.nDescuentoFin);
                parameters.Add("nValorFinanciado", cotizacion.nValorFinanciado);
                parameters.Add("nIdCuota", cotizacion.nIdCuota);
                parameters.Add("nCuotas", cotizacion.nCuotas);
                parameters.Add("nValorCuota", cotizacion.nValorCuota);
                parameters.Add("nIdDescuentoCon", cotizacion.nIdDescuentoCon);
                parameters.Add("nDescuentoCon", cotizacion.nDescuentoCon);
                parameters.Add("nValorContado", cotizacion.nValorContado);
                parameters.Add("nIdUsuario_crea", cotizacion.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<CotizacionDTO> getCotizacionById(int nIdCotizacion)
        {
            CotizacionDTO res = new CotizacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 7);
                parameters.Add("nIdCotizacion", nIdCotizacion);

                res = await connection.QuerySingleAsync<CotizacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<string> formatoCotizacion()
        {
            string res;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 8);

                res = await connection.QuerySingleAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
