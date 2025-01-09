using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Dashboard
{
    public interface IDashboardRepository
    {
        Task<IList<SelectDTO>> getListUsuarios(int nIdProveedor, int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListTipoUsuario();
        Task<IList<TrazabilidadVentasDTO>> postTrazabilidadVentas(TrazabilidadVentasFilterChartDTO trazabilidadVentasFilter);
        Task<IList<TrazabilidadPreContratosDTO>> postTrazabilidadPreContratos(TrazabilidadPreContratosFilterChartDTO trazabilidadPreContratosFilter);
        Task<IList<AgendamientoChartDTO>> postListAgendamientoChart(AgendamientoChartFilterDTO agendamientoChartFilter);
    }
}
