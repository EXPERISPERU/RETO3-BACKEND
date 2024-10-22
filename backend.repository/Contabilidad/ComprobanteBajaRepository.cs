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
using System.Reflection.Metadata;

namespace backend.repository.Contabilidad
{
    public class ComprobanteBajaRepository : IComprobanteBajaRepository
    {
        private readonly IConfiguration _configuration;

        public ComprobanteBajaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ComprobanteBajaDTO>> getListComprobanteBaja(SelectComprobanteBajaDTO select)
        {
            IEnumerable<ComprobanteBajaDTO> list = new List<ComprobanteBajaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 8);
                parameters.Add("nIdCompania", select.nIdCompania);
                parameters.Add("PageNumber", select.PageNumber);
                parameters.Add("RowspPage", select.RowspPage);

                list = await connection.QueryAsync<ComprobanteBajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ComprobanteDTO>> getComprobanteById(int nIdComprobante)
        {

            IEnumerable<ComprobanteDTO> list = new List<ComprobanteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 1);
                parameters.Add("nIdComprobante", nIdComprobante);

                list = await connection.QueryAsync<ComprobanteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoMotivos()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 2);

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
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 3);
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

        public async Task<IList<LoginDTO>> AuthUserSuperAnulaCompro(string sUsuario, string sContrasena)
        {
            IEnumerable<LoginDTO> list = new List<LoginDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_comprobante_baja]", 4);
                parameters.Add("sUsuario", sUsuario);
                parameters.Add("sPassword", sContrasena);

                list = await connection.QueryAsync<LoginDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
