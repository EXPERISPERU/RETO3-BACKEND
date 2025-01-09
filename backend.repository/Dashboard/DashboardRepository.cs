using backend.domain;
using backend.repository.Interfaces.Dashboard;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Dashboard
{
    public class DashboardRepository: IDashboardRepository
    {
        private readonly IConfiguration _configuration;

        public DashboardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getListUsuarios(int nIdProveedor, int nIdCompania, int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 1);
                parameters.Add("nIdProveedor", nIdProveedor);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 2);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListTipoUsuario()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<TrazabilidadVentasDTO>> postTrazabilidadVentas(TrazabilidadVentasFilterChartDTO trazabilidadVentasFilter)
        {
            IEnumerable<TrazabilidadVentasDTO> list = new List<TrazabilidadVentasDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 4);
                parameters.Add("nIdUsuario", trazabilidadVentasFilter.nIdUsuario);
                parameters.Add("nIdCompania", trazabilidadVentasFilter.nIdCompania);

                parameters.Add("nIdProyecto", trazabilidadVentasFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", trazabilidadVentasFilter.sCodTrimestre);
                parameters.Add("sMes", trazabilidadVentasFilter.sMes);
                parameters.Add("sAno", trazabilidadVentasFilter.sAno);
                parameters.Add("nIdSubordinado", trazabilidadVentasFilter.nIdSubordinado);
                parameters.Add("nIdProveedor", trazabilidadVentasFilter.nIdProveedor);

                list = await connection.QueryAsync<TrazabilidadVentasDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<TrazabilidadPreContratosDTO>> postTrazabilidadPreContratos(TrazabilidadPreContratosFilterChartDTO trazabilidadPreContratosFilter)
        {
            IEnumerable<TrazabilidadPreContratosDTO> list = new List<TrazabilidadPreContratosDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 5);
                parameters.Add("nIdUsuario", trazabilidadPreContratosFilter.nIdUsuario);
                parameters.Add("nIdCompania", trazabilidadPreContratosFilter.nIdCompania);

                parameters.Add("nIdProyecto", trazabilidadPreContratosFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", trazabilidadPreContratosFilter.sCodTrimestre);
                parameters.Add("sMes", trazabilidadPreContratosFilter.sMes);
                parameters.Add("sAno", trazabilidadPreContratosFilter.sAno);
                parameters.Add("nIdSubordinado", trazabilidadPreContratosFilter.nIdSubordinado);
                parameters.Add("nIdProveedor", trazabilidadPreContratosFilter.nIdProveedor);

                list = await connection.QueryAsync<TrazabilidadPreContratosDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<AgendamientoChartDTO>> postListAgendamientoChart(AgendamientoChartFilterDTO agendamientoChartFilter)
        {
            IEnumerable<AgendamientoChartDTO> list = new List<AgendamientoChartDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dashboard].[pa_dashboard]", 6);
                parameters.Add("nIdCompania", agendamientoChartFilter.nIdCompania);
                parameters.Add("nIdUsuario", agendamientoChartFilter.nIdUsuario);
                parameters.Add("nIdProyecto", agendamientoChartFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", agendamientoChartFilter.sCodTrimestre);
                parameters.Add("sMes", agendamientoChartFilter.sMes);
                parameters.Add("sAno", agendamientoChartFilter.sAno);
                parameters.Add("nIdSubordinado", agendamientoChartFilter.nIdSubordinado);

                list = await connection.QueryAsync<AgendamientoChartDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
