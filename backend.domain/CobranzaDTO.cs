using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CobranzaDTO
    {

    }

    public class AsignacionClienteDTO
    {
        public int? nIdCliente { get; set; }
        public string nIdPersona { get; set; }
        public string sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sNombreCompleto { get; set; }
        public string? nTotalCuotasVencidas { get; set; }
        public string? nTotalMontoCuotasVencidas { get; set; }
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
    }

}
