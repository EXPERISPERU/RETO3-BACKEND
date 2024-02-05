using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CorrelativoDTO
    {
        public int? nIdCorrelativo { get; set; }
        public int nIdSerie { get; set; }
        public string sDescripcion { get; set; }
		public int nDesde { get; set; }
		public int nHasta { get; set; }
		public int nActual { get; set; }
		public bool bActivo {  get; set; }
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
