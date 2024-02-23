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
        public int nIdPersona { get; set; }
        public int? nIdAsignacion { get; set; }
        public int? nIdPeriodoGestion { get; set; }
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

    }
}
