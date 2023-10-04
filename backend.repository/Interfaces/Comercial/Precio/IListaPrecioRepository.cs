using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial.Precio
{
    public interface IListaPrecioRepository
    {
        Task<IList<ListaPrecioDTO>> getListListaPrecio();
        Task<ListaPrecioDTO> getListaPrecio(int nIdListaPrecio);
        Task<IList<SelectDTO>> getSelectTipoListaPrecio();
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania);
        Task<SqlRspDTO> InsListaPrecio(ListaPrecioDTO listaPrecio);
        Task<SqlRspDTO> UpdListaPrecio(ListaPrecioDTO listaPrecio);
    }
}
