using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Contratos
{
    public interface IContratoBL
    {
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectEstadoContrato();
        Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros);
        Task<ContratoDTO> getContratoById(int nIdContrato);
        Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato);
        Task<IList<OrdenPagoPreContratoDTO>> getListOrdenPagoByContrato(int nIdContrato);
    }
}
