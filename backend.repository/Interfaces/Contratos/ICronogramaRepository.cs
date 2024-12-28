using backend.domain;

namespace backend.repository.Interfaces.Contratos
{
    public interface ICronogramaRepository
    {
        Task<List<bbvaDocumento>> getListCronogramasRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto);
        Task<bbvaDocumento> getCronogramaRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdCronograma);
        Task updateMoraCrogramaVencido();
        Task<SqlRspDTO> UpdMoraCronograma(UpdMoraCronogramaDTO updMoraCronograma);
        Task<SqlRspDTO> UpdCicloPago(UpdCicloPagoDTO updCicloPago);
        Task<IList<SelectDTO>> getSelectCicloPago(int nIdContrato);
        Task<SqlRspDTO> UpdReprogramacionCuota(UpdReprogramacionCuotaDTO updReprogramacionCuota);
    }
}
