using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IAsignacionPrecioBL
    {
        Task<IList<AsignacionPrecioDTO>> getListAsignacionPrecio();
        Task<AsignacionPrecioDTO> getAsignacionPrecioByID(int nIdAsignacionPrecio);
        Task<IList<AsignacionPrecioLoteDTO>> getListAsignacionPrecioLote(int nIdAsignacionPrecio);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectGrupo();
        Task<IList<SelectDTO>> getSelectUbicacion();
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<AsignacionPrecioLoteDTO>> getListLotesParaAsignacion(AsignacionPrecioDTO ap);
        Task<SqlRspDTO> InsAsignacionPrecio(AsignacionPrecioDTO ap);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectMonedaByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectMonedaMaestros();
    }
}
