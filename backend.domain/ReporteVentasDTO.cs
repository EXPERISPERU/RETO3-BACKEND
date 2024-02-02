using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ReporteVentasFiltrosDTO
    {
        public string? sDocumento { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
        public int? nIdItem { get; set; }
        public int? nIdTipoGestion { get; set; }
        public int? nIdPromotor { get; set; }
        public DateTime? dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public int? nIdUsuario { get; set; }
        public int? nIdCompania { get; set; }
    }

    public class ReporteVentasDTO
    {
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCliente { get; set; }
        public string? sProyecto { get; set; }
        public string? sSector { get; set; }
        public string? sManzana { get; set; }
        public string? sLote { get; set; }
        public string? sItem { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public decimal? nValorTotal { get; set; }
        public string? sEstado { get; set; }
        public string? sTipoGestion { get; set; }
        public string? sPromotor { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public DateTime? dFecha_pago { get; set; }
        public int? nIdComprobante { get; set; }
    }
}
