using backend.businesslogic.Interfaces.Contratos;
using backend.domain;
using backend.repository.Interfaces.Contratos;

namespace backend.businesslogic.Contratos
{
    public class ContratoBL : IContratoBL
    {
        IContratoRepository repository;

        public ContratoBL(IContratoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        { 
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            return await repository.getSelectSectorByProyecto(nIdProyecto);
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            return await repository.getSelectManzanaBySector(nIdSector);
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        { 
            return await repository.getSelectCondicionPago();
        }

        public async Task<IList<SelectDTO>> getSelectEstadoContrato()
        {
            return await repository.getSelectEstadoContrato();
        }

        public async Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros)
        {
            return await repository.getListContratoByFilters(contratoFiltros);
        }

        public async Task<ContratoDTO> getContratoById(int nIdContrato)
        {
            return await repository.getContratoById(nIdContrato);
        }

        public async Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato)
        {
            return await repository.getListCronogramaByContrato(nIdContrato);
        }

        public async Task<IList<OrdenPagoPreContratoDTO>> getListOrdenPagoByContrato(int nIdContrato)
        {
            return await repository.getListOrdenPagoByContrato(nIdContrato);
        }

        public async Task<IList<ContratoByIdClientDTO>> getContratosByIdCliente(int nIdCliente)
        {
            return await repository.getContratosByIdCliente(nIdCliente);
        }

        public async Task<IList<ListInicialByContrato>> getListInicialByContrato(int nIdContrato)
        {
            return await repository.getListInicialByContrato(nIdContrato);
        }

        public async Task<IList<DocumentosContratoDTO>> getListDocumentosByContrato(int nIdContrato)
        {
            return await repository.getListDocumentosByContrato(nIdContrato);
        }

        public async Task<BeneficiarioClienteDTO> getConyugueByCliente(int nIdCliente)
        {
            return await repository.getConyugueByCliente(nIdCliente);
        }

        public async Task<SqlRspDTO> UpdConyugueContrato(UpdConyugueDTO updConyugue)
        {
            return await repository.UpdConyugueContrato(updConyugue);
        }

        public async Task<SqlRspDTO> UpdRetirarConyugueContrato(UpdConyugueDTO updConyugue)
        {
            return await repository.UpdRetirarConyugueContrato(updConyugue);
        }

        public async Task<string> getFormatoContratoById(int nIdFormato)
        {
            return await repository.getFormatoContratoById(nIdFormato);
        }

        public async Task<SqlRspDTO> UpdFirmaContrato(UpdFirmaContratoDTO updfirma)
        {
            return await repository.UpdFirmaContrato(updfirma);
        }

        public async Task<SqlRspDTO> UpdFirmaConyugueContrato(UpdFirmaContratoDTO updfirma)
        {
            return await repository.UpdFirmaConyugueContrato(updfirma);
        }

        public async Task<bool> ValidFinalizarFirmar(int nIdContrato)
        { 
            return await repository.ValidFinalizarFirmar(nIdContrato);
        }

        public async Task<SqlRspDTO> InsDocumentoContrato(DocumentosContratoDTO documento)
        {
            return await repository.InsDocumentoContrato(documento);
        }
    }
}
