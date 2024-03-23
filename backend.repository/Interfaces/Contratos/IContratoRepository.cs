using backend.domain;

namespace backend.repository.Interfaces.Contratos
{
    public interface IContratoRepository
    {
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectEstadoContrato();
        Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros);
        Task<ContratoDTO> getContratoById(int nIdContrato);
        Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato);
        Task<IList<OrdenPagoPreContratoDTO>> getListOrdenPagoByContrato(int nIdContrato);
        Task<IList<ContratoByIdClientDTO>> getContratosByIdCliente(int nIdCliente);
        Task<IList<ListInicialByContrato>> getListInicialByContrato(int nIdContrato);
        Task<IList<DocumentosContratoDTO>> getListDocumentosByContrato(int nIdContrato);
        Task<BeneficiarioClienteDTO> getConyugueByCliente(int nIdCliente);
        Task<SqlRspDTO> UpdConyugueContrato(UpdConyugueDTO updConyugue);
        Task<SqlRspDTO> UpdRetirarConyugueContrato(UpdConyugueDTO updConyugue);
        Task<string> getFormatoContratoById(int nIdFormato);
        Task<SqlRspDTO> UpdFirmaContrato(UpdFirmaContratoDTO updfirma);
        Task<SqlRspDTO> UpdFirmaConyugueContrato(UpdFirmaContratoDTO updfirma);
        Task<bool> ValidFinalizarFirmar(int nIdContrato);
        Task<SqlRspDTO> InsDocumentoContrato(DocumentosContratoDTO documento);
    }
}
