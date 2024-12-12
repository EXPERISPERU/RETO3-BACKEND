using backend.businesslogic.Interfaces.Contratos;
using backend.domain;
using backend.repository.Interfaces.Contratos;

namespace backend.businesslogic.Contratos
{
    public class CronogramaBL : ICronogramaBL
    {
        private readonly ICronogramaRepository repository;

        public CronogramaBL(ICronogramaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto)
        {
            return await repository.getListCronogramasRecaudoBBVAbyDocumento(sDocumento, nCodigoProyecto);
        }

        public async Task<bbvaDocumento> getCronogramaRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdCronograma)
        {
            return await repository.getCronogramaRecaudoBBVAbyDocumentoAndID(sDocumento, nConvenio, nIdCronograma);
        }

        public async Task updateMoraCrogramaVencido() 
        { 
              await repository.updateMoraCrogramaVencido();
        }

        public async Task<SqlRspDTO> UpdMoraCronograma(UpdMoraCronogramaDTO updMoraCronograma)
        {
            return await repository.UpdMoraCronograma(updMoraCronograma);
        }
    }
}
