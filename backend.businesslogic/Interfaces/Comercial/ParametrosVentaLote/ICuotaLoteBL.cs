using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface ICuotaLoteBL
    {
        Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos();
        Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote);
        Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote);
    }
}
