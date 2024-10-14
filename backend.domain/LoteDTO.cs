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

        public string? sCodigo { get; set; }
        public int nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdLote { get; set; }
        public string sLote { get; set; }
        public int nIdEstado { get; set; }
        public string? sEstado { get; set; }
        public decimal nMetraje { get; set; }
        public int nIdGrupo { get; set; }
        public string? sGrupo { get; set; }
        public int? nIdColor { get; set; }
        public string? sColor { get; set; }
        public int nIdUbicacion { get; set; }
        public string? sUbicacion { get; set; }
        public int nIdTerreno { get; set; }
        public string? sTerreno { get; set; }
        public int nIdZonificacion { get; set; }
        public string? sZonificacion { get; set; }
        public int nIdDescripcion { get; set; }
        public string? sDescripcion { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
        public int? Id_Old { get; set; }
        public string? Flg_M { get; set; }
    }
}
