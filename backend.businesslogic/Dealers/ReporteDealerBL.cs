using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Interfaces.Dealers;

namespace backend.businesslogic.Dealers
{
    public class ReporteDealerBL : IReporteDealerBL
    {
        IReporteDealerRepository repository;

        public ReporteDealerBL(IReporteDealerRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ProveedorDTO>> getListProveedorDealer(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListProveedorDealer(nIdUsuario, nIdCompania);
        }

        public async Task<IList<AgenteDealerDTO>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor)
        { 
            return await repository.getListAgenteDealerByProveedor(nIdUsuario, nIdCompania, nIdProveedor);
        }

        public async Task<IList<rdReporteDataDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            return await repository.getListReferenciasxDiaByAD(rdSelectReporte);
        }

        public async Task<IList<rdReporteDataDiaDTO>> getListPrecontratoxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            return await repository.getListPrecontratoxDiaByAD(rdSelectReporte);
        }

        public async Task<IList<rdReporteDataDiaDTO>> getListVentaxDiaByAD(rdSelectReporteDealerDTO rdSelectReporte)
        {
            return await repository.getListVentaxDiaByAD(rdSelectReporte);
        }
    }
}
