using backend.domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Cobranzas
{
    public interface IGestionSeguimientoBL
    {
        Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado);
        Task<IList<ContratosDeudaDTO>> getListContratosDeuda(int nIdCliente);
        Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato);
        Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento);
        Task<GestionClienteDTO> getDatosCliente(int nIdUsuario, int nIdCliente);
        Task<IList<ClienteSearchDTO>> getListClientSearchByName(int nIdUsuario, string termino);
        Task<IList<SelectDTO>> getSelectTipoContacto();
        Task<IList<SelectDTO>> getSelectMedioContacto();
        Task<SqlRspDTO> InsSeguimientoDetalle(SeguimientoDetalleDTO detalle);
        Task<IList<SeguimientoDetalleDTO>> getListDetalleSeguimiento(int nIdSeguimiento);
        Task<IList<SelectDTO>> getSelectResultado(int bRespuesta);
        Task<SqlRspDTO> InsAgendamiento(AgendamientoDTO agendamiento);
        Task<IList<SelectDTO>> getSelectTipoAgendamiento();
        Task<IList<AgendamientoDTO>> getListAgendamiento(int nIdSeguimiento);
        Task<SqlRspDTO> InsSeguimientoCuota(SeguimientoCuotaDTO seguimientoCuota);
        Task<SqlRspDTO> UpdTerminarSeguimiento(SeguimientoDTO seguimiento);
        Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoByFilters(SeguimientoFiltrosDTO SeguimientoFiltros);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectTipoDocumento();
        Task<IList<SeguimientoDTO>> getSeguimiento(int nIdSeguimiento);
    }
}
