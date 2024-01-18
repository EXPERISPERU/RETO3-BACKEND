using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ContratoDTO
    {
        public int nIdContrato { get; set; }
        public int? nIdContratoO { get; set; }
		public int nIdCondicionPago { get; set; }
		public string? sCondicionPago { get; set; }
        public int nIdLote { get; set; }
		public string? sLote { get; set; }
		public decimal nMetraje { get; set; }
		public int nIdCliente { get; set; }
		public string? sDNI { get; set; }
		public string? sCE { get; set; }
		public string? sRUC { get; set; }
		public string? sNombreCompleto { get; set; }
        public string? sDireccion { get; set; }
		public string? sUbigeo { get; set; }
		public string? sCelular { get; set; }
		public string? sCorreo { get; set; }
		public int nIdMoneda { get; set; }
		public string? sMoneda { get; set; }
		public string? sSimbolo { get; set; }
        public int nIdAsignacionPrecio { get; set; }
		public int? nIdDescuentoLote { get; set; }
        public string? sDescuentoLote { get; set; }
        public int? nIdInicialLote { get; set; }
        public string? sInicialLote { get; set; }
		public int? nIdReferido { get; set; }
		public string? sCodigo { get; set; }
		public decimal nMontoVenta { get; set; }
		public decimal? nMontoDescuento { get; set; }
		public decimal nMontoFinal { get; set; }
		public decimal? nMontoInicial { get; set; }
		public decimal? nMontoFinanciado { get; set; }
		public DateTime? dFechaIni { get; set; }
		public DateTime? dFechaFin { get; set; }
		public int? nIdCuota { get; set; }
		public int? nCuotas { get; set; }
        public int? nIdCicloPago { get; set; }
		public int nIdEstado { get; set; }
		public string? sEstado { get; set; }
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
