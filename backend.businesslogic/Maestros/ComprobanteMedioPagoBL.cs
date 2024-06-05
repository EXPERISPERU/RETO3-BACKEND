using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class ComprobanteMedioPagoBL : IComprobanteMedioPagoBL
    {
        IComprobanteMedioPagoRepository repository;
        public ComprobanteMedioPagoBL(IComprobanteMedioPagoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroMedioPago()
        {
            return await repository.getListMaestroMedioPago();
        }

        public async Task<IList<ComprobanteMedioPagoDTO>> getListComprobanteMedioPagoByCompania(int nIdCompania)
        {
            return await repository.getListComprobanteMedioPagoByCompania(nIdCompania);
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes()
        {
            return await repository.getListMaestroTipoComprobantes();
        }

        public async Task<SqlRspDTO> InsComprobanteMedioPago(ComprobanteMedioPagoDTO comprobanteMedioPagoDTO)
        {
            return await repository.InsComprobanteMedioPago(comprobanteMedioPagoDTO);
        }
    }
}
