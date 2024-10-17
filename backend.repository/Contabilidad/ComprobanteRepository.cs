using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Contabilidad
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        private readonly IConfiguration _configuration;

        public ComprobanteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ComprobanteDTO>> getListComprobante(int pagina, int cantpagina)
        {
            IEnumerable<ComprobanteDTO> list = new List<ComprobanteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 8);
                parameters.Add("PageNumber", pagina);
                parameters.Add("RowspPage", cantpagina);

                list = await connection.QueryAsync<ComprobanteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
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

        public async Task<string> formatoComprobanteByIdComprobante(int nIdCompania, int nIdProyecto, int nIdComprobante)
        {
            string res;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante]", 5);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdProyecto", nIdProyecto);
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

        public async Task<SqlRspDTO> InsCertificacionComprobante(int nIdComprobante, string sCodigo, string? sMensaje, string? sCodigoSunat, string? sMensajeSunat, string? sToken)
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

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
