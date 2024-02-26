using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Cobranzas
{
    public interface IAsignacionClienteBL
    {
        Task<IList<SelectDTO>> getSelectPeriodoGestion();
        Task<IList<SelectDTO>> getSelectProyectoByCompania( int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectoresByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectCicloPagoByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectAsesorCobranza(int nIdCompania);
        Task<IList<AsignacionClienteDTO>> getListAsignacionClienteByFilters(AsignacionClienteFiltrosDTO AsignacionFiltros);
        Task<SqlRspDTO> InsAsignacionCliente(AsignacionClienteDTO asignacionCliente);
    }
}
