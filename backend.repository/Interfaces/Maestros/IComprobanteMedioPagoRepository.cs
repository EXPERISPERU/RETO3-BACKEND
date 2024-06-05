using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface IComprobanteMedioPagoRepository
    {
        Task<IList<ComprobanteMedioPagoDTO>> getListComprobanteMedioPagoByCompania(int nIdCompania);
        Task<IList<ElementoSistemaDTO>> getListMaestroMedioPago();
        Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes();
        Task<SqlRspDTO> InsComprobanteMedioPago(ComprobanteMedioPagoDTO comprobanteMedioPagoDTO);

    }
}
