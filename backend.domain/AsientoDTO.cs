using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.domain
{
    public class AsientoBancoDTO
    {
        public int nIdComprobante { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nIdProyecto { get; set; }
        public string? sCuentaContable { get; set; }
        public string? sCodAsientoProyecto { get; set; }
        public string? sSubdiario { get; set; }
        public string? sFechaDocumento { get; set; }
        public int nIdCompania { get; set; }
        public string? sAnioMes { get; set; }
        public int? nIdComprobanteOrigen { get; set; }
        public int? nIdComprobanteBaja { get; set; }
        public int? nIdCobranza { get; set; }
        public int? nIdMedioPago { get; set; }
        public string? sMovimiento { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public string sDescripcionItem { get; set; }
        public string sAbrevTipoComprobante { get; set; }
        public string sSerie { get; set; }
        public int nCorrelativo { get; set; }
        public int nIdEstado { get; set; }
        public int? bAnulado { get; set; }
        public string sComprobante { get; set; }
        public decimal? nTipoCambio { get; set; }
        public int nIdCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCompleto { get; set; }
        public int nIdNotaCredito { get; set; }
        public decimal nValorNoGravado { get; set; }
        public decimal nValorInafecto { get; set; }
        public decimal nValorSubTotal { get; set; }
        public decimal nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int nIdMoneda { get; set; }
        public string sSunatMoneda { get; set; }
    }

    public class AsientoCajaDTO
    {
        public int nIdComprobante { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nIdProyecto { get; set; }
        public string? sCajaEfectivo { get; set; }
        public string? sCodAsientoProyecto { get; set; }
        public string? sSubdiario { get; set; }
        public string? sFechaDocumento { get; set; }
        public int nIdCompania { get; set; }
        public string? sAnioMes { get; set; }
        public string? sTipoAnexo { get; set; }
        public string? sCodigoAnexo { get; set; }
        public decimal? nTipoCambio { get; set; }
        public int? bAnulado { get; set; }
        public int? nIdComprobanteOrigen { get; set; }
        public int? nIdComprobanteBaja { get; set; }
        public int? nIdCobranza { get; set; }
        public int? nIdMedioPago { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public string sAbrevTipoComprobante { get; set; }
        public string sSerie { get; set; }
        public int nCorrelativo { get; set; }
        public int nIdEstado { get; set; }
        public string sComprobante { get; set; }
        public string sDescripcionItem { get; set; }
        public int nIdCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCompleto { get; set; }
        public int nIdNotaCredito { get; set; }
        public decimal nValorNoGravado { get; set; }
        public decimal nValorInafecto { get; set; }
        public decimal nValorSubTotal { get; set; }
        public decimal nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int nIdMoneda { get; set; }
        public string sSunatMoneda { get; set; }
    }

    public class AsientoBoletasDTO
    {
        public int nIdComprobante { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nIdProyecto { get; set; }
        public string? sCajaEfectivo { get; set; }
        public string? sCodAsientoProyecto { get; set; }
        public string? sSubdiario { get; set; }
        public string? sCuentaContable { get; set; }
        public string? sMovimiento { get; set; }
        public string? sCuentaIgv { get; set; }
        public string? sFechaDocumento { get; set; }
        public int nIdCompania { get; set; }
        public string? sAnioMes { get; set; }
        public string? sCodProyecto { get; set; }
        public string? sTipoAnexo { get; set; }
        public string? sCodigoAnexo { get; set; }
        public int? bAnulado { get; set; }
        public int? nIdComprobanteOrigen { get; set; }
        public int? nIdComprobanteBaja { get; set; }
        public int? nIdCobranza { get; set; }
        public int? nIdMedioPago { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public string sAbrevTipoComprobante { get; set; }
        public string sSerie { get; set; }
        public int nCorrelativo { get; set; }
        public int nIdEstado { get; set; }
        public string sComprobante { get; set; }
        public string sDescripcionItem { get; set; }
        public int nIdCliente { get; set; }
        public decimal nPorcentageIgv { get; set; }
        public string? sDNI { get; set; }
        public string? sInmueble { get; set; }
        public string? sProyecto { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCompleto { get; set; }
        public int nIdNotaCredito { get; set; }
        public decimal nValorNoGravado { get; set; }
        public decimal nValorInafecto { get; set; }
        public decimal nValorSubTotal { get; set; }
        public decimal nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public decimal? nTipoCambio { get; set; }
        public int nIdMoneda { get; set; }
        public string sSunatMoneda { get; set; }
    }

    public class AsientoDevolucionDTO
    {
        public int nIdComprobante { get; set; }
        public string? sCuentaContable { get; set; }
        public string? sMovimiento { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nIdProyecto { get; set; }
        public string? sInmueble { get; set; }
        public string? sCajaEfectivo { get; set; }
        public string? sProyecto { get; set; }
        public string? sCodProyecto { get; set; }
        public string? sCodAsientoProyecto { get; set; }
        public decimal? nTipoCambio { get; set; }
        public string? sSubdiario { get; set; }
        public decimal nPorcentageIgv { get; set; }
        public string? sFechaDocumento { get; set; }
        public string? sFechaDocumentoOrigen { get; set; }
        public int nIdCompania { get; set; }
        public string? sCuentaIgv { get; set; }
        public string? sComprobanteOrigen { get; set; }
        public string? sAnioMes { get; set; }
        public string? sTipoAnexo { get; set; }
        public string? sCodigoAnexo { get; set; }
        public int? bAnulado { get; set; }
        public int? nIdComprobanteOrigen { get; set; }
        public int? nIdComprobanteBaja { get; set; }
        public int? nIdCobranza { get; set; }
        public int? nIdMedioPago { get; set; }
        public int? nIdTipoComprobante { get; set; }
        public string sAbrevTipoComprobante { get; set; }
        public string sSerie { get; set; }
        public int nCorrelativo { get; set; }
        public int nIdEstado { get; set; }
        public string sComprobante { get; set; }
        public string sDescripcionItem { get; set; }
        public int nIdCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCompleto { get; set; }
        public int nIdNotaCredito { get; set; }
        public decimal nValorNoGravado { get; set; }
        public decimal nValorInafecto { get; set; }
        public decimal nValorSubTotal { get; set; }
        public decimal nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int nIdMoneda { get; set; }
        public string sSunatMoneda { get; set; }
    }

    public class AsientoFilterDTO
    {
        public int? nIdProyecto { get; set; }
        public string? dFechaInicio { get; set; }
        public string? dFechaFin { get; set; }
        public int? nIdCompania { get; set; }
    }
}