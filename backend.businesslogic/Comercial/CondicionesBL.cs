using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Maestros;

namespace backend.businesslogic.Comercial
{
    public class CondicionesBL : ICondicionesBL
    {
        ICondicionesRepository repository;

        public CondicionesBL(ICondicionesRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListCondiciones(nIdCompania, nIdUsuario);
        }

        public async Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones)
        {
            return await repository.InsCondiciones(condiciones);
        }

        public async Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones)
        {
            return await repository.UpdCondiciones(condiciones);
        }

        public async Task<IList<SelectDTO>> SelectTipoCondiciones()
        {
            return await repository.SelectTipoCondiciones();
        }

        public async Task<IList<CondicionesDetDTO>> getListCondicionesDetByTipo(int nIdCondicion, int nIdTipoCondicionDet)
        {
            return await repository.getListCondicionesDetByTipo(nIdCondicion, nIdTipoCondicionDet);
        }

        public async Task<CondicionesDetDTO> getCondicionesDetById(int nIdCondicionesDet)
        {
            return await repository.getCondicionesDetById(nIdCondicionesDet);
        }

        public async Task<IList<SelectDTO>> SelectProyectoByCompania(int nIdCompania)
        {
            return await repository.SelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> SelectSectorByProyecto(int nIdProyecto)
        {
            return await repository.SelectSectorByProyecto(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> SelectManzanaBySector(int nIdSector)
        {
            return await repository.SelectManzanaBySector(nIdSector);
        }

        public async Task<IList<SelectDTO>> SelectLoteByManzana(int nIdManzana)
        {
            return await repository.SelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> SelectGrupoInmueble()
        {
            return await repository.SelectGrupoInmueble();
        }

        public async Task<IList<SelectDTO>> SelectUbicacionInmueble()
        {
            return await repository.SelectUbicacionInmueble();
        }

        public async Task<IList<SelectDTO>> SelectTerrenoInmueble()
        {
            return await repository.SelectTerrenoInmueble();
        }

        public async Task<IList<SelectDTO>> SelectZonificacionInmueble()
        {
            return await repository.SelectZonificacionInmueble();
        }

        public async Task<IList<SelectDTO>> SelectDescripcionInmueble()
        {
            return await repository.SelectDescripcionInmueble();
        }

        public async Task<IList<SelectDTO>> SelectColorInmueble()
        {
            return await repository.SelectColorInmueble();
        }

        public async Task<IList<SelectDTO>> SelectTipoFinanciamiento()
        {
            return await repository.SelectTipoFinanciamiento();
        }

        public async Task<IList<SelectDTO>> SelectCuotaLote()
        {
            return await repository.SelectCuotaLote();
        }

        public async Task<IList<SelectDTO>> SelectInicial()
        {
            return await repository.SelectInicial();
        }

        public async Task<IList<SelectDTO>> SelectDescuento()
        {
            return await repository.SelectDescuento();
        }

        public async Task<SqlRspDTO> InsCondicionesDet(CondicionesDetDTO condicionesDet)
        {
            return await repository.InsCondicionesDet(condicionesDet);
        }

        public async Task<SqlRspDTO> UpdCondicionesDet(CondicionesDetDTO condicionesDet)
        {
            return await repository.UpdCondicionesDet(condicionesDet);
        }

    }
}
