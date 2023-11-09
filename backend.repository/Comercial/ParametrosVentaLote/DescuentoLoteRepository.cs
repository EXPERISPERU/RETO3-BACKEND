using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class DescuentoLoteRepository : IDescuentoLoteRepository
    {
        private readonly IConfiguration _configuration;

        public DescuentoLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<DescuentoLoteDTO>> getListDescuentoLote()
        {
            IEnumerable<DescuentoLoteDTO> list = new List<DescuentoLoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 1);

                list = await connection.QueryAsync<DescuentoLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote)
        {
            DescuentoLoteDTO resp = new DescuentoLoteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 2);
                parameters.Add("nIdDescuentoLote", nIdDescuentoLote);

                resp = await connection.QuerySingleOrDefaultAsync<DescuentoLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 4);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 6);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 7);
                parameters.Add("nIdProyecto", descuentoLote.nIdProyecto);
                parameters.Add("sDescripcion", descuentoLote.sDescripcion);
                parameters.Add("nIdCondicionPago", descuentoLote.nIdCondicionPago);
                parameters.Add("nIdTipo", descuentoLote.nIdTipo);
                parameters.Add("nValor", descuentoLote.nValor);
                parameters.Add("nIdMoneda", descuentoLote.nIdMoneda);
                parameters.Add("dFechaIni", descuentoLote.dFechaIni);
                parameters.Add("dFechaFin", descuentoLote.dFechaFin);
                parameters.Add("bActivo", descuentoLote.bActivo);
                parameters.Add("nIdUsuario_crea", descuentoLote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_descuento_lote]", 8);
                parameters.Add("nIdDescuentoLote", descuentoLote.nIdDescuentoLote);
                parameters.Add("sDescripcion", descuentoLote.sDescripcion);
                parameters.Add("dFechaIni", descuentoLote.dFechaIni);
                parameters.Add("dFechaFin", descuentoLote.dFechaFin);
                parameters.Add("bActivo", descuentoLote.bActivo);
                parameters.Add("nIdUsuario_mod", descuentoLote.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 8);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
