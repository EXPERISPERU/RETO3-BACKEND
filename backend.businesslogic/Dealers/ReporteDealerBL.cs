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

        public async Task<IList<rdReporteReferidoDiaDTO>> getListReferenciasxDiaByAD(rdSelectReporteReferidosDTO rdSelectReporteReferidos)
        {
            return await repository.getListReferenciasxDiaByAD(rdSelectReporteReferidos);
        }
    }
}
