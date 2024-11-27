using backend.domain;

namespace backend.repository.Interfaces.Dealers
{
    public interface IReporteDealerRepository
    {
        Task<IList<ProveedorDTO>> getListProveedorDealer(int nIdUsuario, int nIdCompania);
        Task<IList<AgenteDealerDTO>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor);
        Task<IList<rdReporteDataDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte);
        Task<IList<rdReporteDataDiaDTO>> getListPrecontratoxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte);
        Task<IList<rdReporteDataDiaDTO>> getListVentaxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte);
    }
}
