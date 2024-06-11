using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Cobranzas
{
    public interface IAgendamientoRepository
    {
        Task<IList<AgendamientoDTO>> getListAgendamientoByFilters(AgendamientoFiltrosDTO AgendamientoFiltros);
        Task<IList<SelectDTO>> getSelectAsesorAgendamiento(int nIdCompania, int nIdUsuario);
        Task<IList<AgendamientoDTO>> getListAgendamientoVentasByFilters(AgendamientoFiltrosDTO AgendamientoFiltros);
        Task<IList<AgendamientoDTO>> getListAgendamientoAtencionCliente(AgendamientoFiltrosDTO AgendamientoFiltros);
        Task<IList<AgendamientoDTO>> getListAgendamientoProspecto(AgendamientoFiltrosDTO AgendamientoFiltros);
    }
}
