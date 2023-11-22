using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class InicialLoteBL : IInicialLoteBL
    {
        IInicialLoteRepository repository;

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

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            return await repository.getSelectTipoValor();
        }

        public async Task<SqlRspDTO> InsInicialLote(InicialLoteDTO descuentoLote)
        {
            return await repository.InsInicialLote(descuentoLote);
        }

        public async Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO descuentoLote)
        {
            return await repository.UpdInicialLote(descuentoLote);
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            return await repository.getSelectSectorByProyecto(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            return await repository.getSelectManzanaBySector(nIdSector);
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<InicialLoteDTO>> getListEspecificaInicialLote()
        {
            return await repository.getListEspecificaInicialLote();
        }
    }
}
