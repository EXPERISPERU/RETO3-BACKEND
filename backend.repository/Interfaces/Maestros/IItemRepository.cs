using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.repository.Interfaces.Maestros
{
    public interface IItemRepository
    {
        Task<IList<ItemDTO>> getListItem();
        Task<IList<SelectDTO>> getSelectTipoItem();
        Task<IList<SelectDTO>> getSelectSubTipoItem(int nIdTipo);
        Task<SqlRspDTO> InsItem(ItemDTO elemento);
        Task<SqlRspDTO> UpdItem(ItemDTO elemento);
    }
}