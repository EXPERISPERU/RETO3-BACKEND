using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IDescuentoLoteBL
    {
        Task<IList<DescuentoLoteDTO>> getListDescuentoLote();
        Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote);
        Task<IList<SelectDTO>> getSelectTipoDescuento();
        Task<IList<SelectDTO>> getSelectMoneda();
        Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote);
    }
}
