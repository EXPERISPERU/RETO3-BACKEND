using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface IItemCompaniaRepository
    {
        Task<IList<ItemCompaniaDTO>> getListConceptoPagoTipoComprobanteByCompania(int nIdCompania);
        Task<IList<ItemDTO>> getListMaestroConceptoPagos();
        Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes();
        Task<SqlRspDTO> InsItemCompania(ItemCompaniaDTO itemCompaniaDTO);
    }
}
