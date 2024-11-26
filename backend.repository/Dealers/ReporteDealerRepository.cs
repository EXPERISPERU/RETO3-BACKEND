using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Dealers
{
    public class ReporteDealerRepository : IReporteDealerRepository
    {
        private readonly IConfiguration _configuration;

        public ReporteDealerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProveedorDTO>> getListProveedorDealer(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<ProveedorDTO> list = new List<ProveedorDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ProveedorDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<AgenteDealerDTO>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor)
        {
            IEnumerable<AgenteDealerDTO> list = new List<AgenteDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 2);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdProveedor", nIdProveedor);

                list = await connection.QueryAsync<AgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<rdReporteReferidoDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteReferidosDTO rdSelectReporteReferidos)
        {
            IEnumerable<rdReporteReferidoDiaDTO> list = new List<rdReporteReferidoDiaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 3);
                parameters.Add("nIdUsuario", rdSelectReporteReferidos.nIdUsuario);
                parameters.Add("nIdCompania", rdSelectReporteReferidos.nIdCompania);
                parameters.Add("nIdProveedor", rdSelectReporteReferidos.nIdProveedor);
                parameters.Add("nIdAgenteDealer", rdSelectReporteReferidos.nIdAgenteDealer);
                parameters.Add("dFechaIni", rdSelectReporteReferidos.dFechaIni);
                parameters.Add("dFechaFin", rdSelectReporteReferidos.dFechaFin);

                list = await connection.QueryAsync<rdReporteReferidoDiaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
