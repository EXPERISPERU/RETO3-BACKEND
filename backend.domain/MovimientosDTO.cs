using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class MovimientosDTO
    {

        public int? nIdMovimiento { get; set; }
        public int nIdCaja { get; set;}
        public int nIdTipoMovimiento { get; set;}
        public int nIdTipoItem { get; set;}
        public int? nIdOrdenPago { get; set;} 
        public int? nIdComprobante { get; set;}
        public string? sComprobante { get; set; }
        public int? nIdCobranza { get; set;}
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set;}
        public int? nIdUsuario_mod { get;}
        public DateTime? dFecha_mod { get; set; }
        public int? nIdEstado { get; set; }

        //GLOBALES
        public int? nIdCliente { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public int? nMedioPago { get; set; }
        public decimal? nValorTotal { get; set; }
        public int? nTipoFinanciamiento { get; set; }
        public int? nIdLote { get; set; }
        public int? nIdContrato { get; set; }

        //OTROS
        public string? sTipoMovimiento { get; set; }
        public string? sItem { get; set; }
        public string? sNombreCliente { get; set; }
        public string? sUsuarioCrea { get; set; }
        public int? nIdCompania { get; set; }
        public decimal? nValorContrato { get; set; }
        public string? sSimbolo { get; set; }
        public string? sMoneda { get; set; }
        public string? sEstado { get; set; }


        public string? sLote { get; set; }
        public string? sManzana { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto  { get; set; }


        public decimal? nTipoInteresCuotaAplicado { get; set; }
        public string? sIdOperacionBancaria { get; set; }

        //CUOTA
        public int? nIdCuota { get; set; }
        public int? nIdCronograma { get; set; }
        public decimal? nMontoCuota { get; set; }

        //RESERVAS
        public int? nIdPrecioServicio { get; set; }
        public int? nIdMoneda { get; set; }

    }
    public class MovCuotaDTO
    {
        public int? nIdLote { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public int? nIdMoneda { get; set; }
        public int? nIdMedioPago { get; set; }
        public decimal? nValorContrato { get; set; }
        public decimal? nMontoCuota { get; set; }
        public int? nTipoFinanciamiento { get; set; }
        public int? nIdContrato { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public int? nIdCronograma { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
        public int nIdCaja { get; set; }
        public int nIdCompania { get; set; }
        public int nIdTipoItem { get; set; }

    }

    public class MovPreContratoDTO
    {
        public int nIdLote { get; set; }
        public int nIdPrecioServicio { get; set; }
        public decimal nValorPreContrato { get; set; }
        public int?    nVigenciaPreContrato { get; set; }
        public int nIdCliente { get; set; }
        public int nIdTipoGestionComercial { get; set; }
        public int nIdTipoComprobante { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public int? nIdEmpleado { get; set; }
        public int nIdMoneda { get; set; }
        public int nMedioPago { get; set; }
        public int? nIdMedioPago { get; set; }
        public int nIdAsignacionPrecio { get; set; }
        public int? nIdDescuentoLote { get; set; }
        public int? nIdInicialLote { get; set; }
        public decimal nMontoVenta { get; set; }
        public decimal? nMontoDescuento { get; set; }
        public decimal nMontoFinal { get; set; }
        public decimal? nMontoInicial { get; set; }
        public decimal nMontoFinanciado { get; set; }
        public int? nIdCuota { get; set; }
        public int? nCuotas { get; set; }
        public decimal? nValorCuota { get; set; }
        public int nIdUsuario_crea { get; set; }
        public decimal? nTipoInteresCuotaAplicado { get; set; }
        public int? nIdOperacionBancaria { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
        public int nIdCaja { get; set; }
        public int? nIdCompania { get; set; }
        public int nIdTipoItem { get; set; }
        public int? nIdInteresCuota { get; set; }
        public decimal? nMontoInteresCuota { get; set; }
        public int? nIdContrato { get; set; }
    }

    public class MovVentaLoteDTO
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
        public decimal nMontoVenta { get; set; }
        public decimal? nMontoDescuento { get; set; }
        public decimal nMontoFinal { get; set; }
        public decimal? nMontoInicial { get; set; }
        public decimal? nMontoFinanciado { get; set; }
        public decimal? nValorCuota { get; set; }
        public int? nIdCuota { get; set; }
        public int? nCuotas { get; set; }
        public int? nIdCicloPago { get; set; }
        public int nIdUsuario_crea { get; set; }
        public decimal? nTipoInteresCuotaAplicado { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
        public int nIdCaja { get; set; }
        public int? nIdCompania { get; set; }
        public int nIdTipoItem { get; set; }
        public int? nIdInteresCuota { get; set; } //nuevo
        public decimal? nMontoInteresCuota { get; set; } //nuevo
    }

    public class MovReservaDTO
    {
        public int nIdLote { get; set; }
        public int nIdCliente { get; set; }
        public int nIdPrecioServicio { get; set; }
        public int nIdUsuario_crea { get; set; }
        public int nIdMoneda { get; set; }
        public int nIdTipoComprobante { get; set; }
        public int nIdMedioPago { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
        public int nIdCaja { get; set; }
        public int? nIdCompania { get; set; }
        public int nIdTipoItem { get; set; }
    }

    public class MovReporteArqueoDTO
    {
        public string? nMedioPago { get; set; }
        public decimal nValorTotal { get; set; }
        public string? sTipoMovimiento { get; set; }
        public string? sSimbolo { get; set; }
        public string? sMoneda { get; set; }

    }

}
