using backend.domain;

namespace backend.repository.Interfaces.Comercial
{
    public interface IReservaLoteRepository
    {
        Task<IList<SelectDTO>> getSelectPrecioReservaByLote(int nIdLote, int nIdMonedaP);
        Task<SqlRspDTO> InsReserva(InsReservaDTO insReserva);
        Task<DataReservaDTO> getDataReserva(int nIdReservaLote);
        Task<string> formatoReciboIngresoReserva();
        Task<DataReservaDTO> getDataReservaByLote(int nIdLote);
        Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<ReservaChartDTO>> getListReservaChart(int nIdUsuario, int nIdCompania, int nIdProyecto);
    }
}
