using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Cobranzas
{
    public class GestionSeguimientoBL: IGestionSeguimientoBL
    {
        IGestionSeguimientoRepository repository;
        public GestionSeguimientoBL(IGestionSeguimientoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdCompania, int nIdEmpleado)
        {
            return await repository.getListClientesAsignados(nIdCompania, nIdEmpleado);
        }

        public async Task<IList<ContratosDeudaDTO>> getListContratosDeuda(int nIdCompania, int nIdCliente)
        {
            return await repository.getListContratosDeuda(nIdCompania, nIdCliente);
        }

        public async Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato, int nIdSeguimiento)
        {
            return await repository.getListCronogramaDeuda(nIdContrato, nIdSeguimiento);
        }

        public async Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento)
        {
            return await repository.InsSeguimiento(seguimiento);
        }

        public async Task<GestionClienteDTO> getDatosCliente(int nIdUsuario, int nIdCliente, int nIdTipoSeguimiento)
        {
            return await repository.getDatosCliente(nIdUsuario, nIdCliente, nIdTipoSeguimiento);
        }

        public async Task<IList<ClienteSearchDTO>> getListClientSearchByName(int nIdUsuario, int nIdTipoDocumento, string termino)
        {
            return await repository.getListClientSearchByName(nIdUsuario, nIdTipoDocumento, termino);
        }

        public async Task<IList<SelectDTO>> getSelectTipoContacto()
        {
            return await repository.getSelectTipoContacto();
        }

        public async Task<IList<SelectDTO>> getSelectMedioContacto()
        {
            return await repository.getSelectMedioContacto();
        }

        public async Task<SqlRspDTO> InsSeguimientoDetalle(SeguimientoDetalleDTO detalle)
        {
            return await repository.InsSeguimientoDetalle(detalle);
        }

        public async Task<IList<SeguimientoDetalleDTO>> getListDetalleSeguimiento(int nIdSeguimiento)
        {
            return await repository.getListDetalleSeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SelectDTO>> getSelectResultado(int bRespuesta, int nIdTipoSeguimiento)
        {
            return await repository.getSelectResultado(bRespuesta, nIdTipoSeguimiento);
        }

        public async Task<SqlRspDTO> InsAgendamiento(AgendamientoDTO agendamiento)
        {
            return await repository.InsAgendamiento(agendamiento);
        }

        public async Task<IList<SelectDTO>> getSelectTipoAgendamiento(int nIdTipoSeguimiento)
        {
            return await repository.getSelectTipoAgendamiento(nIdTipoSeguimiento);
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamiento(int nIdSeguimiento)
        {
            return await repository.getListAgendamiento(nIdSeguimiento);
        }

        public async Task<SqlRspDTO> InsSeguimientoCuota(SeguimientoCuotaDTO seguimientoCuota)
        {
            return await repository.InsSeguimientoCuota(seguimientoCuota);
        }

        public async Task<SqlRspDTO> UpdTerminarSeguimiento(SeguimientoDTO seguimiento)
        {
            return await repository.UpdTerminarSeguimiento(seguimiento);
        }

        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoByFilters(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            return await repository.getListSeguimientoByFilters(SeguimientoFiltros);
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            return await repository.getSelectLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> getSelectTipoDocumento()
        {
            return await repository.getSelectTipoDocumento();
        }

        public async Task<IList<SeguimientoDTO>> getSeguimiento(int nIdSeguimiento)
        {
            return await repository.getSeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SeguimientoCuotaDTO>> getListSeguimientoCuotaBySeguimiento(int nIdSeguimiento)
        {
            return await repository.getListSeguimientoCuotaBySeguimiento(nIdSeguimiento);
        }

        public async Task<IList<SelectDTO>> getInfoContactoByMedioOfCliente(int nIdCliente, int nIdMedioContacto)
        {
            return await repository.getInfoContactoByMedioOfCliente(nIdCliente, nIdMedioContacto);
        }

        public async Task<IList<SelectDTO>> getSelectAsesorSeguimiento(int nIdCompania, int nIdUsuario, int tipoListSeguimiento)
        {
            return await repository.getSelectAsesorSeguimiento(nIdCompania, nIdUsuario, tipoListSeguimiento);
        }

        public async Task<SqlRspDTO> InsAgendamientoByFechaCompromiso(AgendamientoDTO agendamiento)
        {
            return await repository.InsAgendamientoByFechaCompromiso(agendamiento);
        }

        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoVentasByFilters(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            return await repository.getListSeguimientoVentasByFilters(SeguimientoFiltros);
        }

        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoAtencionCliente(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            return await repository.getListSeguimientoAtencionCliente(SeguimientoFiltros);
        }

        public async Task<IList<SeguimientoProspectoHistoricoDTO>> postListSeguimientoProspectoByFilters(SeguimientoProspectoFiltrosDTO SeguimientoFiltros)
        {
            return await repository.postListSeguimientoProspectoByFilters(SeguimientoFiltros);
        }

        public async Task<IList<SelectDTO>> getInfoContactoByMedioOfProspecto(int nIdProspecto, int nIdMedioContacto)
        {
            return await repository.getInfoContactoByMedioOfProspecto(nIdProspecto, nIdMedioContacto);
        }

        public async Task<IList<SeguimientoChartDTO>> postListSeguimientoChart(SeguimientoChartFilterDTO seguimientoChartFilter)
        {
            return await repository.postListSeguimientoChart(seguimientoChartFilter);
        }

        public async Task<SqlRspDTO> InsDescartarReferido(DescartarReferidoDTO descartarRef)
        {
            return await repository.InsDescartarReferido(descartarRef);
        }

    }
}
