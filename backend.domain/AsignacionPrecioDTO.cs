using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class AsignacionPrecioDTO
    {
        public int? nIdAsignacionPrecio { get; set; }
		public int nIdCompania { get; set; }
		public string? sCompania { get; set; }
		public int nIdProyecto { get; set; }
		public string? sProyecto { get; set; }
		public int? nIdGrupo { get; set; }
		public string? sGrupo { get; set; }
		public int? nIdUbicacion { get; set; }
		public string? sUbicacion { get; set; }
		//public int? nIdCondicionPago { get; set; }
		//public string? sCondicionPago { get; set; }
		public int? nIdSector { get; set; }
		public string? sSector { get; set; }
		public int? nIdManzana { get; set; }
		public string? sManzana { get; set; }
		public int? nIdLote { get; set; }
		public string? sLote { get; set; }
		public DateTime dFechaIni { get; set; }
		public string? sFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaFin { get; set; }
        public decimal nPrecio { get; set; }
        public decimal nPrecioVenta { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
		public int? nCantInmuebles { get; set; }
        public int? nCantInmueblesAct { get; set; }
    }

    public class AsignacionPrecioLoteDTO
    {
        public string? sProyecto { get; set; }
        public string? sSector { get; set; }
        public string? sManzana { get; set; }
        public int? nIdLote { get; set; }
        public string? sLote { get; set; }
        public string? sEstado { get; set; }
        public string? sGrupo { get; set; }
        public string? sUbicacion { get; set; }
        public string? sTerreno { get; set; }
        public string? sZonificacion { get; set; }
        public string? sDescripcion { get; set; }
        public decimal? nPrecio { get; set; }
        public bool? bActivo { get; set; }
        public int? nAsignaciones { get; set; }
    }
}
