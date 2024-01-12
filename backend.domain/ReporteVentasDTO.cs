using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ReporteVentasDTO
    {
        public int? nIdReservaLote { get; set; }
        public int? nIdLote { get; set; }
        public string? sLote { get; set; }
        public int? nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdCompania { get; set; }
        public string? sRazonSocial { get; set; }
        public int? nIdCliente { get; set; }
        public string? sNombreCompleto { get; set; }
        public string? sDocumento { get; set; }
        public int? nIdTipoGestionComercial { get; set; }
        public string? sTipoGestion { get; set; }
        public string? sPromotor { get; set; }
        public int? nIdOrdenPago { get; set; }
        public string? sFechaPago { get; set; }
        public int? nIdOrdenPagoDet { get; set; }
        public decimal? nMontoReserva { get; set; }
        public int? nIdEstado { get; set; }
        public string? sEstadoPago { get; set; }
        public int? nIdItem { get; set; }
        public string? sTipo { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public string? dFecha_crea { get; set; }
    }
}
