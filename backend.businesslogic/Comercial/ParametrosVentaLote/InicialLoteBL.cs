using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class InicialLoteBL : IInicialLoteBL
    {
        IInicialLoteRepository repository;

        public InicialLoteBL() { }

        public InicialLoteBL(IInicialLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<InicialLoteDTO>> getListInicialLote()
        {
            return await repository.getListInicialLote();
        }

        public async Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote)
        {
            return await repository.getInicialLoteByID(nIdInicialLote);
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            return await repository.getSelectTipoValor();
        }

        public async Task<IList<SelectDTO>> getSelectMoneda()
        {
            return await repository.getSelectMoneda();
        }

        public async Task<SqlRspDTO> InsInicialLote(InicialLoteDTO descuentoLote)
        {
            return await repository.InsInicialLote(descuentoLote);
        }
    }
}
