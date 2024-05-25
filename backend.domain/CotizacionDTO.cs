using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CotizacionDTO
    {
        public int? nIdCotizacion { get; set; }
        public string? sCorrelativo { get; set; }
        public int nIdCliente { get; set; }
        public string? sDocumentoCliente { get; set; }
        public string? sNombreCliente { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int nIdLote { get; set; }
        public string? sLote { get; set; }
        public decimal nMetraje { get; set; }
        public int? nIdGrupo { get; set; }
        public string? sGrupo { get; set; }
        public int? nIdUbicacion { get; set; }
        public string? sUbicacion { get; set; }
        public int? nIdTerreno { get; set; }
        public string? sTerreno { get; set; }
        public int? nIdZonificacion { get; set; }
        public string? sZonificacion { get; set; }
        public int? nIdDescripcion { get; set; }
        public string? sDescripcion { get; set; }
        public int? nIdEstado { get; set; }
        public string? sEstado { get; set; }
        public int nIdMoneda { get; set; }
        public string sSimbolo { get; set; }
        public int? nIdAsignacionPrecio { get; set; }
        public decimal? nPrecioVenta { get; set; }
        public int? nIdInicial { get; set; }
        public string? sValorInicial { get; set; }
        public decimal? nInicial { get; set; }
        public int? nIdDescuentoFin { get; set; }
        public string? sValorDescuentoFin { get; set; }
        public decimal? nDescuentoFin { get; set; }
        public decimal? nValorFinanciado { get; set; }
        public int? nIdCuota { get; set; }
        public decimal? nCuotas { get; set; }
        public decimal? nValorCuota { get; set; }
        public int? nIdDescuentoCon { get; set; }
        public string? sValorDescuentoCon { get; set; }
        public decimal? nDescuentoCon { get; set; }
        public decimal? nValorContado { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public string? sTipoInteres { get; set; }
        public decimal? nTipoInteres { get; set; }
    }

    public class InicialDescuentoDTO
    {
        public int nId { get; set; }
        public string sDescripcion { get; set; }
        public decimal nValor { get; set; }
        public int nIdTipo { get; set; }
        public string sTipoCodigo { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdLote { get; set; }
    }
}
