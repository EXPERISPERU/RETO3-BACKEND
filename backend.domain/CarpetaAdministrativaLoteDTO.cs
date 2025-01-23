using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CarpetaAdministrativaLoteDTO
    {
        public int? nIdContrato { get; set; }
        public int nIdLote { get; set; }
        public int nIdPrecioServicio { get; set; }
        public decimal nValorPreContrato { get; set; }
        public int nVigenciaPreContrato { get; set; }
        public int nIdCliente { get; set; }
        public int nIdTipoGestionComercial { get; set; }
        public int nIdTipoComprobante { get; set; }
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
        public decimal nMontoFinanciado { get; set; }
        public int? nIdCuota { get; set; }
        public int? nCuotas { get; set; }
        public decimal? nValorCuota { get; set; }
        public int nIdUsuario_crea { get; set; }
        public int? nIdOperacionBancaria { get; set; }
        public string? sIdOperacionBancaria { get; set; }
        public string? sIdOperacionIzzipay { get; set; }
    }
}
