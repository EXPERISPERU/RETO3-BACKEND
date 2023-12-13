using backend.domain;

namespace backend.repository.Interfaces.Comercial
{
    public interface IReservaLoteRepository
    {
        Task<IList<SelectDTO>> getSelectPrecioReservaByLote(int nIdLote);
        Task<SqlRspDTO> InsReserva(InsReservaDTO insReserva);
        Task<DataReservaDTO> getDataReserva(int nIdReservaLote);
        Task<string> formatoReciboIngresoReserva();
        Task<DataReservaDTO> getDataReservaByLote(int nIdLote);
    }
}
