using backend.domain;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{
    public interface ICuotaLoteRepository
    {
        Task<IList<CuotaLoteDTO>> getListCuotaLoteProyectos();
        Task<CuotaLoteDTO> getCuotaLoteByID(int nIdCuotaLote);
        Task<SqlRspDTO> InsCuotaLoteProyecto(CuotaLoteDTO cuotaLote);
    }
}
