using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IDescuentoLoteRepository
    {
        Task<IList<DescuentoLoteDTO>> getListDescuentoLote();
        Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote);
        Task<IList<SelectDTO>> getSelectTipoDescuento();
        Task<IList<SelectDTO>> getSelectMoneda();
        Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote);
    }
}
