using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InsPreContratoLoteDTO
    {
        public int nIdLote { get; set; }
        public int nIdPrecioServicio { get; set; }
        public decimal nValorPreContrato { get; set; }
        public int nIdCliente { get; set; }
        public int nIdTipoGestionComercial { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public int? nIdEmpleado { get; set; }
        public int nIdMoneda { get; set; }
        public int nMedioPago { get; set; }
        public int nIdAsignacionPrecio { get; set; }
        public int? nIdDescuentoLote { get; set; }
        public int nIdInicialLote { get; set; }
        public decimal nMontoVenta { get; set; }
        public decimal? nMontoDescuento { get; set; }
        public decimal nMontoFinal { get; set; }
        public decimal nMontoInicial { get; set; }
        public decimal nMontoFinanciado { get; set; }
        public int nIdCuota { get; set; }
        public int nCuotas { get; set; }
        public int nIdUsuario_crea { get; set; }
    }

    public class OrdenPagoPreContratoDTO
    { 
        public DateTime dFecha_crea { get; set; }
        public string sFecha_crea { get; set; }
        public int nIdMoneda { get; set; }
        public string sMoneda { get; set; }
        public string sSimbolo { get; set; }
        public decimal nValorTotal { get; set; }
        public string sEstado { get; set; }
        public DateTime dFecha_pago { get; set; }
        public string sFecha_pago { get; set; }
        public int nIdComprobante { get; set; }
    }
}
