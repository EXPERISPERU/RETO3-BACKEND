using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class LoteDTO
    {
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdLote { get; set; }
        public string sLote { get; set; }
        public int nIdEstado { get; set; }
        public string? sEstado { get; set; }
        public decimal nMetraje { get; set; }
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
