using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaProducto
{
    public interface IPrecioRepository
    {
        Task<IList<PrecioDTO>> getListPrecio();
    }
}
