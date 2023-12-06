using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IReservaLoteBL
    {
        Task<IList<SelectDTO>> getSelectPrecioReservaByLote(int nIdLote);
        Task<SqlRspDTO> InsReserva(InsReservaDTO insReserva);
        Task<ReciboIngresoReservaDTO> getReciboIngresoReserva(int nIdReservaLote);
        Task<string> formatoReciboIngresoReserva();
    }
}
