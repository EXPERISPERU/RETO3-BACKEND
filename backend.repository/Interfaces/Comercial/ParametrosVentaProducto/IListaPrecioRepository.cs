using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaProducto
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
