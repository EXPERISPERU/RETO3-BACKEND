using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;

namespace backend.businesslogic.Comercial
{
    public class ReservaLoteBL : IReservaLoteBL
    {
        IReservaLoteRepository repository;

        public ReservaLoteBL(IReservaLoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioReservaByLote(int nIdLote)
        {
            return await repository.getSelectPrecioReservaByLote(nIdLote);
        }

        public async Task<SqlRspDTO> InsReserva(InsReservaDTO insReserva)
        {
            return await repository.InsReserva(insReserva);
        }

        public async Task<DataReservaDTO> getDataReserva(int nIdReservaLote)
        {
            return await repository.getDataReserva(nIdReservaLote);
        }

        public async Task<string> formatoReciboIngresoReserva()
        {
            return await repository.formatoReciboIngresoReserva();
        }

        public async Task<DataReservaDTO> getDataReservaByLote(int nIdLote)
        {
            return await repository.getDataReservaByLote(nIdLote);
        }
    }
}
