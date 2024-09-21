using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class DescuentoLoteBL : IDescuentoLoteBL
    {
        IDescuentoLoteRepository repository;

        public DescuentoLoteBL() {}

        public DescuentoLoteBL(IDescuentoLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<DescuentoLoteDTO>> getListDescuentoLote()
        {
            return await repository.getListDescuentoLote();
        }

        public async Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote)
        {
            return await repository.getDescuentoLoteByID(nIdDescuentoLote);
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            return await repository.getSelectTipoDescuento();
        }

        public async Task<IList<SelectDTO>> getSelectMoneda()
        {
            return await repository.getSelectMoneda();
        }

        public async Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            return await repository.InsDescuentoLote(descuentoLote);
        }
    }
}
