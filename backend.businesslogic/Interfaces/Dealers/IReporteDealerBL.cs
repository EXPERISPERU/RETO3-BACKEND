using backend.domain;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface IReporteDealerBL
    {
        Task<IList<ProveedorDTO>> getListProveedorDealer(int nIdUsuario, int nIdCompania);
        Task<IList<AgenteDealerDTO>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor);
        Task<IList<rdReporteDataDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteDealerDTO rdSelectReporteReferidos);
        Task<IList<rdReporteDataDiaDTO>> getListPrecontratoxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte);
        Task<IList<rdReporteDataDiaDTO>> getListVentaxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte);
    }
}
