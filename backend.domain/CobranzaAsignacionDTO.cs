using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CobranzaAsignacionDTO
    {
  
    }

    public class AsignacionClienteDTO
    {
        public int? nIdAsignacion { get; set; }
        public int nIdCliente { get; set; }
        public int nIdEmpleado { get; set; }
        public int? nIdPeriodoGestion { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sNombreCliente { get; set; }
        public int? nTotalCuotasVencidas { get; set; }
        public string? sSimbolo { get; set; }
        public decimal? nTotalMontoCuotasVencidas { get; set; }
        public string? sNombreEmpleado { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public int? nSeguimientos { get; set; }
    }

    public class PeriodoGestionDTO
    {
        public int? nIdPeriodo { get; set; }
        public string sPeriodo { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
    }

    public class AsignacionClienteFiltrosDTO
    {
        public int? nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdCicloPago { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
        public int? estadoMorosidad { get; set; }
        public int? estadoAsignacion { get; set; }
        public int? nIdPeriodoGestion { get; set; }
    }

}
