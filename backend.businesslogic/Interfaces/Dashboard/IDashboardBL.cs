using backend.domain;

namespace backend.businesslogic.Interfaces.Dashboard
{
    public interface IDashboardBL
    {
        Task<IList<SelectDTO>> getListUsuarios(int nIdProveedor, int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListTipoUsuario();
        Task<IList<TrazabilidadVentasDTO>> postTrazabilidadVentas(TrazabilidadVentasFilterChartDTO trazabilidadVentasFilter);
        Task<IList<TrazabilidadPreContratosDTO>> postTrazabilidadPreContratos(TrazabilidadPreContratosFilterChartDTO trazabilidadPreContratosFilter);
        Task<IList<AgendamientoChartDTO>> postListAgendamientoChart(AgendamientoChartFilterDTO agendamientoChartFilter);
    }
}
