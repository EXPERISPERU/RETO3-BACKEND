using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IDescuentoLoteRepository
    {
        Task<IList<DescuentoLoteDTO>> getListDescuentoLote();
        Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectTipoDescuento();
        Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote);
        Task<SqlRspDTO> UpdDescuentoLote(DescuentoLoteDTO descuentoLote);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
    }
}
