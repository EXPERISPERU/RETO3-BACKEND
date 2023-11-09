using backend.businesslogic.Interfaces.Comercial.ParametrosVentaProducto;
using backend.repository.Interfaces.Comercial.ParametrosVentaProducto;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaProducto
{
    public class PrecioBL : IPrecioBL
    {
        IPrecioRepository repository;

        public PrecioBL(IPrecioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<PrecioDTO>> getListPrecio()
        {
            return await repository.getListPrecio();
        }
    }
}
