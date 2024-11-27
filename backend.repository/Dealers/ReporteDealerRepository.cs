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

        public async Task<IList<rdReporteDataDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            IEnumerable<rdReporteDataDiaDTO> list = new List<rdReporteDataDiaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 3);
                parameters.Add("nIdUsuario", rdSelectReporte.nIdUsuario);
                parameters.Add("nIdCompania", rdSelectReporte.nIdCompania);
                parameters.Add("nIdProveedor", rdSelectReporte.nIdProveedor);
                parameters.Add("nIdAgenteDealer", rdSelectReporte.nIdAgenteDealer);
                parameters.Add("dFechaIni", rdSelectReporte.dFechaIni);
                parameters.Add("dFechaFin", rdSelectReporte.dFechaFin);

                list = await connection.QueryAsync<rdReporteDataDiaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<rdReporteDataDiaDTO>> getListPrecontratoxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            IEnumerable<rdReporteDataDiaDTO> list = new List<rdReporteDataDiaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 4);
                parameters.Add("nIdUsuario", rdSelectReporte.nIdUsuario);
                parameters.Add("nIdCompania", rdSelectReporte.nIdCompania);
                parameters.Add("nIdProveedor", rdSelectReporte.nIdProveedor);
                parameters.Add("nIdAgenteDealer", rdSelectReporte.nIdAgenteDealer);
                parameters.Add("dFechaIni", rdSelectReporte.dFechaIni);
                parameters.Add("dFechaFin", rdSelectReporte.dFechaFin);

                list = await connection.QueryAsync<rdReporteDataDiaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<rdReporteDataDiaDTO>> getListVentaxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            IEnumerable<rdReporteDataDiaDTO> list = new List<rdReporteDataDiaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_reporte]", 5);
                parameters.Add("nIdUsuario", rdSelectReporte.nIdUsuario);
                parameters.Add("nIdCompania", rdSelectReporte.nIdCompania);
                parameters.Add("nIdProveedor", rdSelectReporte.nIdProveedor);
                parameters.Add("nIdAgenteDealer", rdSelectReporte.nIdAgenteDealer);
                parameters.Add("dFechaIni", rdSelectReporte.dFechaIni);
                parameters.Add("dFechaFin", rdSelectReporte.dFechaFin);

                list = await connection.QueryAsync<rdReporteDataDiaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
