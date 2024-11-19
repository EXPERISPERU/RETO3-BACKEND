using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Contabilidad
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        private readonly IConfiguration _configuration;

        public ComprobanteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ComprobanteDTO> getComprobanteById(int nIdComprobante)
        {
            ComprobanteDTO res = new ComprobanteDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 3);
                parameters.Add("nIdComprobante", nIdComprobante);

                res = await connection.QuerySingleAsync<ComprobanteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<List<ComprobanteDetDTO>> getComprobanteDetById(int nIdComprobante)
        {
            IEnumerable<ComprobanteDetDTO> res = new List<ComprobanteDetDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 4);
                parameters.Add("nIdComprobante", nIdComprobante);

                res = await connection.QueryAsync<ComprobanteDetDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<string> formatoComprobanteByIdComprobante(int nIdComprobante)
        {
            string res;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 5);
                parameters.Add("nIdComprobante", nIdComprobante);

                res = await connection.QuerySingleAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 6);
                parameters.Add("nIdComprobante", nIdComprobante);
                parameters.Add("sRutaFtp", sRutaFtp);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsCertificacionComprobante(int nIdComprobante, string sCodigo, string? sMensaje, string? sCodigoSunat, string? sMensajeSunat, string? sToken, bool bExito)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 7);
                parameters.Add("nIdComprobante", nIdComprobante);
                parameters.Add("sCodigo", sCodigo);
                parameters.Add("sMensaje", sMensaje);
                parameters.Add("sCodigoSunat", sCodigoSunat);
                parameters.Add("sMensajeSunat", sMensajeSunat);
                parameters.Add("sToken", sToken);
                parameters.Add("bExito", bExito);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<ComprobanteDTO>> getListComprobante(int nIdTipoComprobante, int nIdCompania, int pagina, int cantpagina, string? sFiltro)
        {
            IEnumerable<ComprobanteDTO> list = new List<ComprobanteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 8);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("PageNumber", pagina);
                parameters.Add("RowspPage", cantpagina);
                parameters.Add("sFiltro", sFiltro);
                parameters.Add("nIdTipoComprobante", nIdTipoComprobante);

                list = await connection.QueryAsync<ComprobanteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> posInsNotaCredito(NotaCreditoDTO notaCredito)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 9);
                parameters.Add("nIdComprobanteOrigen", notaCredito.nIdComprobanteOrigen);
                parameters.Add("nIdTipoComprobante", notaCredito.nIdTipoComprobante);
                parameters.Add("nIdCompania", notaCredito.nIdCompania);
                parameters.Add("sMotivoNotaCd", notaCredito.sMotivoNotaCd?.ToString());
                parameters.Add("nIdTipoOperacionNcd", notaCredito.nIdTipoOperacionNcd);
                parameters.Add("nIdUsuario_crea", notaCredito.nIdUsuario_crea);
                parameters.Add("nMontoNotaCredito", notaCredito.nMontoNotaCredito);

                res = await connection.QuerySingleOrDefaultAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<List<int>> getComprobantesPendientesCertByCompania(int nCodigoCompania)
        {
            IEnumerable<int> res = new List<int>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 10);
                parameters.Add("nCodigoCompania", nCodigoCompania);

                res = await connection.QueryAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<List<ComprobanteMetodoPagoDTO>> getMetodoPagoById(int nIdComprobante)
        {
            IEnumerable<ComprobanteMetodoPagoDTO> res = new List<ComprobanteMetodoPagoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();

                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 11);
                parameters.Add("nIdComprobante", nIdComprobante);

                res = await connection.QueryAsync<ComprobanteMetodoPagoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> getListTipoNotaCredito()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 12);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoMotivoBaja()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 13);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsComprobanteBaja(ComprobanteBajaDTO comprobanteBaja)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 14);
                parameters.Add("nIdCobranza", comprobanteBaja.nIdCobranza);
                parameters.Add("nIdComprobante", comprobanteBaja.nIdComprobante);
                parameters.Add("sCodigoBaja", comprobanteBaja.sCodigoBaja);
                parameters.Add("nIdMotivo", comprobanteBaja.nIdMotivo);
                parameters.Add("sMotivo", comprobanteBaja.sMotivo);
                parameters.Add("nIdUsuario_crea", comprobanteBaja.nIdUsuario_crea);
                parameters.Add("nIdUsuario_autoriza", comprobanteBaja.nIdUsuario_autoriza);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<LoginDTO>> AuthUserBaja(string sUsuario, string sContrasena)
        {
            IEnumerable<LoginDTO> list = new List<LoginDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 15);
                parameters.Add("sUsuario", sUsuario);
                parameters.Add("sPassword", sContrasena);

                list = await connection.QueryAsync<LoginDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ComprobanteBajaDTO> getComprobanteBajaById(int nIdComprobanteBaja)
        {
            ComprobanteBajaDTO res = new ComprobanteBajaDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 16);
                parameters.Add("nIdComprobanteBaja", nIdComprobanteBaja);

                res = await connection.QuerySingleAsync<ComprobanteBajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
