using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IComprobanteMedioPagoBL
    {
        Task<IList<ComprobanteMedioPagoDTO>> getListComprobanteMedioPagoByCompania(int nIdCompania);
        Task<IList<ElementoSistemaDTO>> getListMaestroMedioPago();
        Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes();
        Task<SqlRspDTO> InsComprobanteMedioPago(ComprobanteMedioPagoDTO comprobanteMedioPagoDTO);
    }
}
