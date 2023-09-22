using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class PeriodoLaboralDTO
    {
		public int nIdPeriodoLaboral { get; set; }
		public int nIdCompania { get; set; }
		public string? sCompania { get; set; }
		public int nIdEmpleado { get; set; }
		public bool bActivo { get; set; }
		public DateTime dFechaIni { get; set; }
		public string? sFechaIni { get; set; }
		public DateTime? dFechaFin { get; set; }
		public string? sFechaFin { get; set; }
		public int nIdUsuario_crea { get; set; }
		public string? sUsuario_crea { get; set; }
		public DateTime? dFecha_crea { get; set; }
		public string? sFecha_crea { get; set; }
		public int? nIdUsuario_mod { get; set; }
		public string? sUsuario_mod { get; set; }
		public DateTime? dFecha_mod { get; set; }
		public string? sFecha_mod { get; set; }
    }
}
