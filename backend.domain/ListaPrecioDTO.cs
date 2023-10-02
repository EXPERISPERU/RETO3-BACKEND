using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ListaPrecioDTO
    {
        public int? nIdListaPrecio { get; set; }
        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public int? nIdOficina { get; set; }
        public string? sOficina { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdGrupo { get; set; }
        public string? sGrupo { get; set; }
        public int? nIdUbicacion { get; set; }
        public string? sUbicacion { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdEstadoSector { get; set; }
        public string? sEstadoSector { get; set; }
        public int? nIdCondicionPago { get; set; }
        public string? sCondicionPago { get; set; }
        public bool bActivo { get; set; }
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
