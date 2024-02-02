using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using backend.repository.Interfaces.Comercial;

namespace backend.repository.Comercial
{
    public class ReporteVentasRepository : IReporteVentasRepository
    {
        private readonly IConfiguration _configuration;

        public ReporteVentasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdUsuario, int nIdProyecto)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 2);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectManzanaByProyectoSector(int nIdUsuario, int nIdProyecto, int? nIdSector)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdSector", nIdSector);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdUsuario, int nIdManzana)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 4);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdManzana", nIdManzana);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectItemVentas(int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 5);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoGestion(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 6);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectDealerEmpleadoByTipoGestion(int nIdUsuario, int nIdCompania, int nIdTipoGestion)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 7);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdTipoGestion", nIdTipoGestion);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ReporteVentasDTO>> getListReporteVentas(ReporteVentasFiltrosDTO filtros)
        {
            IEnumerable<ReporteVentasDTO> list = new List<ReporteVentasDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 8);
                parameters.Add("sDocumento", filtros.sDocumento);
                parameters.Add("nIdProyecto", filtros.nIdProyecto);
                parameters.Add("nIdSector", filtros.nIdSector);
                parameters.Add("nIdManzana", filtros.nIdManzana);
                parameters.Add("nIdLote", filtros.nIdLote);
                parameters.Add("nIdItem", filtros.nIdItem);
                parameters.Add("nIdTipoGestion", filtros.nIdTipoGestion);
                parameters.Add("nIdPromotor", filtros.nIdPromotor);
                parameters.Add("dFechaIni", filtros.dFechaIni);
                parameters.Add("dFechaFin", filtros.dFechaFin);
                parameters.Add("nIdUsuario", filtros.nIdUsuario);
                parameters.Add("nIdCompania", filtros.nIdCompania);

                list = await connection.QueryAsync<ReporteVentasDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
