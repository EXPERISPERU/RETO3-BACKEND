namespace backend.domain
{
	public class ContratoDTO
	{
		public int nIdContrato { get; set; }
		public int? nIdContratoO { get; set; }
		public int nIdCondicionPago { get; set; }
		public string? sCodigoCondicionPago { get; set; }
		public string? sCondicionPago { get; set; }
        public int nIdLote { get; set; }
		public string? sLote { get; set; }
		public int? nIdManzana { get; set; }
		public string? sManzana { get; set; }
		public int? nIdSector { get; set; }
		public string? sSector { get; set; }
		public int? nIdProyecto { get; set; }
		public int? nCodigoProyecto { get; set; }
        public string? sProyecto { get; set; }
		public string? sGrupo { get; set; }
		public string? sUbicacion { get; set; }
		public decimal nMetraje { get; set; }
        public int nIdCliente { get; set; }
		public string? sDNI { get; set; }
		public string? sCE { get; set; }
		public string? sRUC { get; set; }
		public string? sPriNombre { get; set; }
		public string? sSegNombre { get; set; }
		public string? sApePaterno { get; set; }
		public string? sApeMaterno { get; set; }
        public string? sNombreCompleto { get; set; }
        public string? sDireccion { get; set; }
		public string? sUbigeo { get; set; }
		public string? sCelular { get; set; }
		public string? sCelular2 { get; set; }
		public string? sTelefono { get; set; }
        public string? sCorreo { get; set; }
		public int? nIdEstadoCivil { get; set; }
		public string? sEstadoCivil { get; set; }
        public bool? bConyugue { get; set; }
		public int? nIdBeneficiario { get; set; }
        public string? sDNIConyugue { get; set; }
        public string? sCEConyugue { get; set; }
        public string? sRUCConyugue { get; set; }
        public string? sNombreCompletoConyugue { get; set; }
        public string? sCelularConyugue { get; set; }
        public string? sCorreoConyugue { get; set; }
		public string? sEstadoCivilConyugue { get; set; }
        public int nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
		public string? sSimbolo { get; set; }
		public int nIdAsignacionPrecio { get; set; }
		public int? nIdDescuentoLote { get; set; }
        public string? sDescuentoLote { get; set; }
		public int? nIdMonedaDesc { get; set; }
		public string? sSimboloDesc { get; set; }
		public decimal? nValorDesc { get; set; }
		public int? nIdInicialLote { get; set; }
		public string? sInicialLote { get; set; }
        public int? nIdMonedaIni { get; set; }
        public string? sSimboloIni { get; set; }
        public decimal? nValorIni { get; set; }
        public int? nIdReferido { get; set; }
		public string? sTipoGestion { get; set; }
		public string? sPromotor { get; set; }
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
        public int? nCuotasPagadas { get; set; }
        public decimal? tCuotasPagadas { get; set; }
        public int? nCuotasPendientes { get; set; }
        public decimal? tCuotasPendientes { get; set; }
        public decimal? nValorCuota { get; set; }
        public int? nIdCicloPago { get; set; }
		public int? nDiaPago { get; set; }
		public int nIdEstado { get; set; }
		public string? sEstado { get; set; }
		public DateTime? dFechaVenta { get; set; }
		public DateTime? dFechaFirma { get; set; }
		public string? sFirma { get; set; }
		public string? sFirmaConyugue { get; set; }
        public int nIdUsuario_crea { get; set; }
		public string? sUsuario_crea { get; set; }
		public DateTime? dFecha_crea { get; set; }
		public string? sFecha_crea { get; set; }
		public int? nIdUsuario_mod { get; set; }
		public string? sUsuario_mod { get; set; }
		public DateTime? dFecha_mod { get; set; }
		public string? sFecha_mod { get; set; }
		public decimal? nTipoInteresCuotaAplicado { get; set; }
        public int? nIdTipoInteresCuotaAplicado { get; set; }
        public int? nIdMonedaTipoInteresCuotaAplicado { get; set; }
        public decimal? nValorOriInteres { get; set; }
        public string? sSimboloInteres { get; set; }

    }

	public class ContratoFiltrosDTO
	{
		public int nIdCompania { get; set; }
		public int? nIdProyecto { get; set; }
		public int? nIdSector { get; set; }
		public int? nIdManzana { get; set; }
		public int? nIdLote { get; set; }
		public string? sCodigo { get; set; }
		public string? sDocumento { get; set; }
        public int? nIdCondicionPago { get; set; }
		public int? nIdEstado { get; set; }
		public bool? bEditable { get; set; }
    }

    public class OrdenPagoPreContratoDTO
    {
        public DateTime dFecha_crea { get; set; }
        public string sFecha_crea { get; set; }
        public string sItem { get; set; }
        public int nIdMoneda { get; set; }
        public string sMoneda { get; set; }
        public string sSimbolo { get; set; }
        public decimal nValorTotal { get; set; }
        public string sEstado { get; set; }
        public DateTime dFecha_pago { get; set; }
        public string sFecha_pago { get; set; }
        public int nIdComprobante { get; set; }
        public string sComprobante { get; set; }
        public int nIdProyecto { get; set; }
    }

    public class ContratoByIdClientDTO
    {
        public int nIdContrato { get; set; }
        public string? sLote { get; set; }
        public string? sManzana { get; set; }
        public string? sProyecto { get; set; }
    }

    public class ListInicialByContrato
    {
        public int nIdContrato { get; set; }
        public string? sCodigoContrato { get; set; }
        public string nIdOrdenPago { get; set; }
        public string estadoOrdenPago { get; set; }
		public string nIdOrdenPagoDet { get; set; }
        public string mInicial { get; set; }
        public int? nIdComprobante { get; set; }
        public string? sComprobante { get; set; }
        public string? nIdCronograma { get; set; }
        public string? descripEstado { get; set; }
        public string? fechaPago { get; set; }
    }

	public class DocumentosContratoDTO
	{ 
		public int nIdDocumento { get; set; }
		public string sCodigo { get; set; }
        public string sDescripcion { get; set; }
		public bool? bFirmaDigital { get; set; }
        public int nIdFormato { get; set; }
		public int? nIdAdjunto { get; set; }
		public int? nIdContrato { get; set; }
		public string? sRutaFTP { get; set; }
        public string? sFile { get; set; }
    }

    public class UpdConyugueDTO
    {
        public int nIdContrato { get; set; }
        public int nIdUsuario { get; set; }
        public int? nIdBeneficiario { get; set; }
    }

    public class UpdFirmaContratoDTO
    {
        public int nIdContrato { get; set; }
        public int nIdUsuario { get; set; }
        public string sFirma { get; set; }
    }

    public class PreContratoChartDTO
    {
        public int nIdContrato { get; set; }
        public int nIdItem { get; set; }
        public int? nIdReferido { get; set; }
        public int? nIdAsesor { get; set; }
        public string? sNombreAsesor { get; set; }
        public DateTime? dFecha { get; set; }
        public int? nCountPreContrato { get; set; }
    }
}
