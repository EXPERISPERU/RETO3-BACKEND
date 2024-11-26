using backend.domain;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface IReporteDealerBL
    {
        Task<IList<ProveedorDTO>> getListProveedorDealer(int nIdUsuario, int nIdCompania);
        Task<IList<AgenteDealerDTO>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor);
        Task<IList<rdReporteReferidoDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteReferidosDTO rdSelectReporteReferidos);
    }
}
