using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InteresCuotaDTO
    {
        public int? nIdInteresCuota { get; set; }
        public int nIdTipoInteres { get; set; }
        public int nIdProyecto { get; set; }
        public int nIdCuotaLote { get; set; }
        public string sDescripcion { get; set; }
        public int? nIdMoneda { get; set; }
        public decimal nValor { get; set; }
        public DateTime  dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; } 

    }
}
