
using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ICondicionesBL
    {
        Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario);
        Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones);
        Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones);
        Task<IList<SelectDTO>> SelectTipoCondiciones();
        Task<IList<CondicionesDetDTO>> getListCondicionesDetByTipo(int nIdCondicion, int nIdTipoCondicionDet);
        Task<CondicionesDetDTO> getCondicionesDetById(int nIdCondicionesDet);
        Task<IList<SelectDTO>> SelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> SelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> SelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> SelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> SelectGrupoInmueble();
        Task<IList<SelectDTO>> SelectUbicacionInmueble();
        Task<IList<SelectDTO>> SelectTerrenoInmueble();
        Task<IList<SelectDTO>> SelectZonificacionInmueble();
        Task<IList<SelectDTO>> SelectDescripcionInmueble();
        Task<IList<SelectDTO>> SelectColorInmueble();
        Task<IList<SelectDTO>> SelectTipoFinanciamiento();
        Task<IList<SelectDTO>> SelectCuotaLote();
        Task<IList<SelectDTO>> SelectInicial();
        Task<IList<SelectDTO>> SelectDescuento();
    }
}
