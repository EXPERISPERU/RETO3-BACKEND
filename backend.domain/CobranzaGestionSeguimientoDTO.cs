using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CobranzaGestionSeguimientoDTO
    {

    }

    public class GestionClienteDTO
    {
        public int nIdCliente { get; set; }
        public int nIdUsuario { get; set; }
        public int? nIdPersona { get; set; }
        public int? nIdAsignacion { get; set; }
        public int? nTiempoGestion { get; set; }
        public int? nIdPeriodoGestion { get; set; }
        public int? nIdSeguimiento { get; set; }
        public string? sNombreCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sGenero { get; set; }
        public string? sStatus { get; set; }
        public string? sTelefono { get; set; }
        public string? sCelular { get; set; }
        public string? sCorreo { get; set; }
        public string? dFechaIni { get; set; }
        public string? dFechaFin { get; set; }
        public int? bActivo { get; set; }
        public string? dFechaNac { get; set; }
    }

    public class ClienteSearchDTO
    {
        public int nIdCliente { get; set; }
        public string sNombreCompleto { get; set; }
        public int? nIdSeguimiento { get; set; }
    }

    public class ContratosDeudaDTO
    {
        public int nIdContrato { get; set; }
        public string sProyecto { get; set; }
        public string? sSector { get; set; }
        public string? sManzana { get; set; }
        public string? sLote { get; set; }
        public string? dFechaIni { get; set; }
        public int? nCuotasVencidas { get; set; }
        public int? nIdMoneda { get; set; }
        public string? nMontoFinalVencido { get; set; }
    }

    public class CronogramaDeudaDTO
    {
        public int nIdCronograma { get; set; }
        public int nIdContrato { get; set; }
        public int nIdSeguimiento { get; set; }
        public int nNroCuota { get; set; }
        public int? nIdMoneda { get; set; }
        public Decimal? nMonto { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public int? diasMora { get; set; }
        public Decimal? nValorMora { get; set; }
        public Decimal? montoTotal { get; set; }
        public int? nIdSeguimientoCuota { get; set; }
        public DateTime? dFechaCompromiso { get; set; }
    }

    public class SeguimientoDTO
    {
        public int? nIdSeguimiento { get; set; }
        public int? nIdTipoSeguimiento { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdAsignacion { get; set; }
        public int? nIdAgendamiento { get; set; }
        public int? nCantidadCuotas { get; set; }
        public string? nTotalPagar { get; set; }
        public string? dFechaIni { get; set; }
        public string? dFechaFin { get; set; }
        public int? nTiempoGestion { get; set; }
        public int? nIdUsuario_crea { get; set; }
    }

    public class SeguimientoDetalleDTO
    {
        public int? nIdSeguimientoDetalle { get; set; }
        public int nIdSeguimiento { get; set; }
        public int? nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int? nIdMedio { get; set; }
        public string? sMedio { get; set; }
        public string? sContacto { get; set; }
        public int? bRespondio { get; set; }
        public string? sRespondio { get; set; }
        public int? nIdResultado { get; set; }
        public string? sResultado { get; set; }
        public string? sHoraMinutos { get; set; }
        public string? sDetalle { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
    }

    public class AgendamientoDTO
    {
        public int? nIdAgendamiento { get; set; }
        public int nIdTipoAgendamiento { get; set; }
        public string? sTipoAgendamiento { get; set; }
        public int? nIdSeguimiento { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdEmpleado { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public DateTime? dFecha { get; set; }
        public string? sDescripcion { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
    }

    public class SeguimientoCuotaDTO
    {
        public int? nIdSeguimientoCuota { get; set; }
        public int nIdSeguimiento { get; set; }
        public int nIdContrato { get; set; }
        public string? sCodContrato { get; set; }
        public int nIdCronograma { get; set; }
        public int nIdMoneda { get; set; }
        public int nNroCuota { get; set; }
        public decimal? nValorCuota { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public int? nDiasMora { get; set; }
        public decimal? nValorMora { get; set; }
        public decimal? nValorTotal { get; set; }
        public decimal? nValorCompromiso { get; set; }
        public DateTime? dFechaCompromiso { get; set; }
        public int? nIdEstadoCompromiso { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
    }

    public class SeguimientoFiltrosDTO
    {
        public int? nIdCompania { get; set; }
        public int? nIdEmpleado { get; set; }
        public int? nIdTipoDocumento { get; set; }
        public string? sDocumento { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
    }
    public class SeguimientoHistoricoDTO
    {
        public int? nIdCliente { get; set; }
        public int? nIdPersona { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCliente { get; set; }
        public int? nIdSeguimiento { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? estado { get; set; }
    }



}
