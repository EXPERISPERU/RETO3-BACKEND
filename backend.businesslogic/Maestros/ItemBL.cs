using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class ItemBL : IItemBL
    {
        IItemRepository repository;

        public ItemBL(IItemRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ItemDTO>> getListItem()
        {
            return await repository.getListItem();
        }

        public async Task<IList<SelectDTO>> getSelectTipoItem()
        {
            return await repository.getSelectTipoItem();
        }

        public async Task<IList<SelectDTO>> getSelectSubTipoItem(int nIdTipo)
        {
            return await repository.getSelectSubTipoItem(nIdTipo);
        }

        public async Task<SqlRspDTO> InsItem(ItemDTO elemento)
        {
            return await repository.InsItem(elemento);
        }

        public async Task<SqlRspDTO> UpdItem(ItemDTO elemento)
        {
            return await repository.UpdItem(elemento);
        }

    }
}