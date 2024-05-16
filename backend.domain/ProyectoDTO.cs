using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
	public class ProyectoDTO
	{
		public int? nIdProyecto { get; set; }
		public int nIdCompania { get; set; }
		public string? sCompania { get; set; }
		public string sNombre { get; set; }
		public string? sDescripcion { get; set; }
		public int nIdUbigeo { get; set; }
		public string? sUbigeo { get; set; }
        public decimal? nLatitud { get; set; }
		public decimal? nLongitud { get; set; }
		public int nSectores { get; set; }
		public int nManzanas { get; set; }
        public int nLotes { get; set; }
        //public bool bIGV { get; set; }
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
