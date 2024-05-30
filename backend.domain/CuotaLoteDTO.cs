using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CuotaLoteDTO
    {
        public int? nIdCuotaLote { get; set; }
        public int? nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int nCuotas { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
        public string? sIdInteres { get; set; }
    }
}
