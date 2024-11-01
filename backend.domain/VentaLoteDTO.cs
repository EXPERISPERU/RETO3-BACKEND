using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InsVentaLoteDTO
    {
        public int nIdLote { get; set; }
        public int nIdCliente { get; set; }
        public int? nIdContrato { get; set; }
        public decimal nValorContrato { get; set; }
        public int nTipoFinanciamiento { get; set; }
        public int nIdTipoComprobante { get; set; }
        public int nIdTipoGestionComercial { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public int? nIdEmpleado { get; set; }
        public int nIdMoneda { get; set; }
        public int nIdMedioPago { get; set; }
        public int nIdAsignacionPrecio { get; set; }
        public int? nIdDescuentoLote { get; set; }
        public int? nIdInicialLote { get; set; }
        public int? nIdInteresCuota { get; set; }
        public decimal nMontoVenta { get; set; }
        public decimal? nMontoDescuento { get; set; }
        public decimal nMontoFinal { get; set; }
        public decimal? nMontoInicial { get; set; }
        public decimal? nMontoInteresCuota { get; set; }
        public decimal? nMontoFinanciado { get; set; }
        public decimal? nValorCuota { get; set; }
        public int? nIdCuota { get; set; }
        public int? nCuotas { get; set; }
        public int? nIdCicloPago { get; set; }
        public int nIdUsuario_crea { get; set; }
        public decimal? nTipoInteresCuotaAplicado { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
    }


    public class VentaLoteChartDTO
    {
        public int nIdContrato { get; set; }
        public int nIdItem { get; set; }
        public int? nIdReferido { get; set; }
        public int? nIdAsesor { get; set; }
        public string? sNombreAsesor { get; set; }
        public DateTime? dFecha { get; set; }
        public int? nCountVenta { get; set; }

    }

    public class VentaLoteChartFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }

    }
}
