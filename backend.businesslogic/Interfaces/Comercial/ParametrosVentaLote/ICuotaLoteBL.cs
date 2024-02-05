using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface ICuotaLoteBL
    {
        Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos();
        Task<IList<CuotaLoteDTO>> getListCuotaLoteEspecifica();
        Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote);
        Task<SqlRspDTO> UpdCuotaLoteProyecto(CuotaLoteDTO cuotaLote);
    }
}
