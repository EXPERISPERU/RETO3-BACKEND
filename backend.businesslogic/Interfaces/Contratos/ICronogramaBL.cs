using backend.domain;

namespace backend.businesslogic.Interfaces.Contratos
{
    public interface ICronogramaBL
    {
        Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto);
        Task<bbvaDocumento> getCronogramaRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdCronograma);
    }
}
