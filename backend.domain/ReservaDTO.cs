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
        public int nIdTipoGestionComercial { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public int? nIdEmpleado { get; set; }
        public int nIdUsuario_crea { get; set; }
    }

    public class ReciboIngresoReservaDTO
    {
        public string sCorrelativo { get; set; }
        public string sNombreCliente { get; set; }
        public string sDocumento { get; set; }
        public string sDireccion { get; set; }
        public string sCelular { get; set; }
        public string sFecha { get; set; }
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
