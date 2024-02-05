using backend.businesslogic.Interfaces.Comercial.ParametrosVentaProducto;
using backend.repository.Interfaces.Comercial.ParametrosVentaProducto;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaProducto
{
    public class ListaPrecioBL : IListaPrecioBL
    {
        IListaPrecioRepository repository;

        public ListaPrecioBL(IListaPrecioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ListaPrecioDTO>> getListListaPrecio()
        {
            return await repository.getListListaPrecio();
        }

        public async Task<ListaPrecioDTO> getListaPrecio(int nIdListaPrecio)
        {
            return await repository.getListaPrecio(nIdListaPrecio);
        }

        public async Task<IList<SelectDTO>> getSelectTipoListaPrecio()
        {
            return await repository.getSelectTipoListaPrecio();
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania)
        {
            return await repository.getSelectOficinaByCompania(nIdCompania);
        }

        public async Task<SqlRspDTO> InsListaPrecio(ListaPrecioDTO listaPrecio)
        {
            return await repository.InsListaPrecio(listaPrecio);
        }

        public async Task<SqlRspDTO> UpdListaPrecio(ListaPrecioDTO listaPrecio)
        {
            return await repository.UpdListaPrecio(listaPrecio);
        }
    }
}
