using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IItemBL
    {
        Task<IList<ItemDTO>> getListItem();
        Task<SqlRspDTO> InsItem(ItemDTO item);
        Task<SqlRspDTO> UpdItem(ItemDTO item);
        Task<IList<SelectDTO>> getListElementoSistema();

    }
}