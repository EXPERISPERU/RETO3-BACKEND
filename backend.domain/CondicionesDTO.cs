using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CondicionesDTO
    {
        public int? nIdCondicion { get; set; }
        public int nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public string sDescripcion { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }

    public class CondicionesDetalleDTO
    {
        public int nIdCondicionesDetalle { get; set; }
        public int nIdCondicion { get; set; }
        public int nIdTipoCondicionDetalle { get; set; }
        public string? sTipoCondicion { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdLote { get; set; }
        public string? sLote { get; set; }
        public int? nIdGrupo { get; set; }
        public string? sGrupo { get; set; }
        public int? nIdUbicacion { get; set; }
        public string? sUbicacion { get; set; }
        public int? nIdTerreno { get; set; }
        public string? sTerreno { get; set; }
        public int? nIdZonificacion { get; set; }
        public string? sZonificacion { get; set; }
        public int? nIdDescripcion { get; set; }
        public string? sDescripcion { get; set; }
        public int? nIdColor { get; set; }
        public string? sColor { get; set; }
        public int? nIdCuotaLote { get; set; }
        public int? nCuotas { get; set; }
        public int? nIdInicialLote { get; set; }
        public string? sInicial { get; set; }
        public int? nIdDescuentoLote { get; set; }
        public string? sDescuento { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
