using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class AsignacionPrecioBL : IAsignacionPrecioBL
    {
        IAsignacionPrecioRepository repository;

        public AsignacionPrecioBL(IAsignacionPrecioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<AsignacionPrecioDTO>> getListAsignacionPrecio() 
        { 
            return await repository.getListAsignacionPrecio();
        }

        public async Task<AsignacionPrecioDTO> getAsignacionPrecioByID(int nIdAsignacionPrecio)
        {
            return await repository.getAsignacionPrecioByID(nIdAsignacionPrecio);
        }

        public async Task<IList<AsignacionPrecioLoteDTO>> getListAsignacionPrecioLote(int nIdAsignacionPrecio)
        {
            return await repository.getListAsignacionPrecioLote(nIdAsignacionPrecio);
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectGrupo()
        {
            return await repository.getSelectGrupo();
        }

        public async Task<IList<SelectDTO>> getSelectUbicacion()
        {
            return await repository.getSelectUbicacion();
        }

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        {
            return await repository.getSelectCondicionPago();
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

        public async Task<IList<AsignacionPrecioLoteDTO>> getListLotesParaAsignacion(AsignacionPrecioDTO ap)
        {
            return await repository.getListLotesParaAsignacion(ap);
        }

        public async Task<SqlRspDTO> InsAsignacionPrecio(AsignacionPrecioDTO ap)
        {
            return await repository.InsAsignacionPrecio(ap);
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }
    }
}
