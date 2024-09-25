using backend.domain;

namespace backend.repository.Interfaces.Contratos
{
    public interface ICronogramaRepository
    {
        Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto);
    }
}
