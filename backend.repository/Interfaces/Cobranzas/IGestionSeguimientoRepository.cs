using backend.domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Cobranzas
{
    public interface IGestionSeguimientoRepository
    {
        Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdCompania, int nIdEmpleado);
        Task<IList<ContratosDeudaDTO>> getListContratosDeuda(int nIdCompania, int nIdCliente);
        Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato, int nIdSeguimiento);
        Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento);
        Task<GestionClienteDTO> getDatosCliente(int nIdUsuario, int nIdCliente, int nIdTipoSeguimiento);
        Task<IList<ClienteSearchDTO>> getListClientSearchByName(int nIdUsuario, int nIdTipoDocumento,string termino);
        Task<IList<SelectDTO>> getSelectTipoContacto();
        Task<IList<SelectDTO>> getSelectMedioContacto();
        Task<SqlRspDTO> InsSeguimientoDetalle(SeguimientoDetalleDTO detalle);
        Task<IList<SeguimientoDetalleDTO>> getListDetalleSeguimiento(int nIdSeguimiento);
        Task<IList<SelectDTO>> getSelectResultado(int bRespuesta, int nIdTipoSeguimiento);
        Task<SqlRspDTO> InsAgendamiento(AgendamientoDTO agendamiento);
        Task<IList<SelectDTO>> getSelectTipoAgendamiento(int nIdTipoSeguimiento);
        Task<IList<AgendamientoDTO>> getListAgendamiento(int nIdSeguimiento);
        Task<SqlRspDTO> InsSeguimientoCuota(SeguimientoCuotaDTO seguimientoCuota);
        Task<SqlRspDTO> UpdTerminarSeguimiento(SeguimientoDTO seguimiento);
        Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoByFilters(SeguimientoFiltrosDTO SeguimientoFiltros);
        Task<IList<SelectDTO>> getSelectLoteByManzana( int nIdManzana );
        Task<IList<SelectDTO>> getSelectTipoDocumento();
        Task<IList<SeguimientoDTO>> getSeguimiento(int nIdSeguimiento);
        Task<IList<SeguimientoCuotaDTO>> getListSeguimientoCuotaBySeguimiento(int nIdSeguimiento);
        Task<IList<SelectDTO>> getInfoContactoByMedioOfCliente(int nIdCliente, int nIdMedioContacto);
        Task<IList<SelectDTO>> getSelectAsesorSeguimiento(int nIdCompania, int nIdUsuario, int tipoListSeguimiento);
        Task<SqlRspDTO> InsAgendamientoByFechaCompromiso(AgendamientoDTO agendamiento);
        Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoVentasByFilters(SeguimientoFiltrosDTO SeguimientoFiltros);
        Task<IList<SeguimientoHistoricoDTO>> ListSeguimientosByCliente(SeguimientoFiltrosDTO SeguimientoFiltros);
        Task<IList<SeguimientoProspectoHistoricoDTO>> postListSeguimientoProspectoByFilters(SeguimientoProspectoFiltrosDTO SeguimientoFiltros);
        Task<IList<SelectDTO>> getInfoContactoByMedioOfProspecto(int nIdProspecto, int nIdMedioContacto);
        Task<IList<SeguimientoChartDTO>> postListSeguimientoChart(SeguimientoChartFilterDTO seguimientoChartFilter);
        Task<SqlRspDTO> InsDescartarReferido(DescartarReferidoDTO descartarRef);
    }
}
