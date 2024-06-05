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
    public class ItemCompaniaBL : IItemCompaniaBL
    {
        IItemCompaniaRepository repository;
        public ItemCompaniaBL(IItemCompaniaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ItemCompaniaDTO>> getListConceptoPagoTerminologiaByCompania(int nIdCompania)
        {
            return await repository.getListConceptoPagoTerminologiaByCompania(nIdCompania);
        }

        public async Task<IList<ItemCompaniaDTO>> getListConceptoPagoTipoComprobanteByCompania(int nIdCompania)
        {
            return await repository.getListConceptoPagoTipoComprobanteByCompania(nIdCompania);
        }

        public async Task<IList<ItemDTO>> getListMaestroConceptoPagos()
        {
            return await repository.getListMaestroConceptoPagos();
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes()
        {
            return await repository.getListMaestroTipoComprobantes();
        }

        public async Task<SqlRspDTO> InsItemCompania(ItemCompaniaDTO itemCompaniaDTO)
        {
            return await repository.InsItemCompania(itemCompaniaDTO);
        }

        public async Task<SqlRspDTO> InsItemCompania_Terminologia(ItemCompaniaDTO itemCompaniaDTO)
        {
            return await repository.InsItemCompania_Terminologia(itemCompaniaDTO);
        }
    }
}
