using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InsReservaDTO
    {
        public int nIdLote { get; set; }
        public int nIdCliente { get; set; }
        public int nIdPrecioServicio { get; set; }
        //public int? nIdTipoGestionComercial { get; set; }
        //public int? nIdAgenteDealer { get; set; }
        //public int? nIdEmpleado { get; set; }
        public int nIdUsuario_crea { get; set; }
        public int nIdMoneda { get; set; }
        public int nIdTipoComprobante { get; set; }
        public int nMedioPago { get; set; }
        public string? sIdOperacionBancaria { get; set; }
    }

    public class DataReservaDTO
    {
        public int nIdReservaLote { get; set; }
        public int? nIdComprobante { get; set; }
        public int? nIdAdjunto { get; set; }
        public string? sRutaFtp { get; set; }
        public string sComprobante { get; set; }
        public string sNombreCliente { get; set; }
        public string sDocumento { get; set; }
        public string sDireccion { get; set; }
        public string sCelular { get; set; }
        public string sFecha { get; set; }
        public int? nIdProyecto { get; set; }
        public string sProyecto { get; set; }
        public string sSector { get; set; }
        public string sManzana { get; set; }
        public string sLote { get; set; }
        public decimal nMetraje { get; set; }
        public string sFechaFinReserva { get; set; }
        public string sNombrePromotor { get; set; }
        public string sSimbolo { get; set; }
        public string sTotal { get; set; }
    }
}
