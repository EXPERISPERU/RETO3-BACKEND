using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IReporteVentasBL
    {
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdUsuario, int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaByProyectoSector(int nIdUsuario, int nIdProyecto, int? nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdUsuario, int nIdManzana);
        Task<IList<SelectDTO>> getSelectItemVentas(int nIdUsuario);
        Task<IList<SelectDTO>> getSelectTipoGestion(int nIdUsuario, int nIdCompania);
        Task<IList<SelectDTO>> getSelectDealerEmpleadoByTipoGestion(int nIdUsuario, int nIdCompania, int nIdTipoGestion);
        Task<IList<ReporteVentasDTO>> getListReporteVentas(ReporteVentasFiltrosDTO filtros);
    }
}
