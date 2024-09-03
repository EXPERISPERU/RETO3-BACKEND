namespace backend.domain
{
    public class SicfacContribuyente
    {
        public string? NroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NombreLegal { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? KeyRest { get; set; }
        public string? CodigoSucusal { get; set; }
        public string? EnvioInmediatoSunat { get; set; }
        public string? FormatoPdfTicket { get; set; }
    }

    public class SicfacItem
    {
        public decimal? Cantidad { get; set; }
        public string? UnidadMedida { get; set; }
        public string? CodigoItem { get; set; }
        public string? Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? PrecioReferencial { get; set; }
        public string? TipoPrecio { get; set; }
        public string? TipoImpuesto { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? ImpuestoSelectivo { get; set; }
        public decimal? TasaImpuestoSelectivo { get; set; }
        public decimal? OtroImpuesto { get; set; }
        public decimal? Descuento { get; set; }
        public string? CodigoProductoSunat { get; set; }
        public decimal? TotalVenta { get; set; }
        public decimal? ValorReferencial { get; set; }
        public decimal? Exonerado { get; set; }
        public decimal? Inafecta { get; set; }
    }

    public class SicfacDireccion
    {
        public string? Ubigeo { get; set; }
        public string? DireccionCompleta { get; set; }
    }

    public class SicfacFormaPago
    {
        public string? FechaPago { get; set; }
        public decimal? Monto { get; set; }
    }

    public class SicfacDocumentoElectronico
    {
        public SicfacContribuyente? Emisor { get; set; }
        public SicfacContribuyente? Receptor { get; set; }
        public string? Serie { get; set; }
        public string? Correlativo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Glosa { get; set; }
        public string? FechaEmision { get; set; }
        public string? HoraEmision { get; set; }
        public string? Moneda { get; set; }
        public string? TipoOperacion { get; set; }
        public decimal? Gravadas { get; set; }
        public decimal? Gratuitas { get; set; }
        public decimal? Inafectas { get; set; }
        public decimal? Exoneradas { get; set; }
        public decimal? Exportacion { get; set; }
        public decimal? DescuentoGlobal { get; set; }
        public decimal? TotalVenta { get; set; }
        public decimal? TotalIgv { get; set; }
        public decimal? TotalIsc { get; set; }
        public decimal? TotalOtrosTributos { get; set; }
        public decimal? MontoPercepcion { get; set; }
        public decimal? MontoDetraccion { get; set; }
        public decimal? TasaDetraccion { get; set; }
        public string? CuentaBancoNacion { get; set; }
        public string? CodigoBienOServicio { get; set; }
        public string? CodigoMedioPago { get; set; }
        public string? TipoDocAnticipo { get; set; }
        public string? DocAnticipo { get; set; }
        public string? MonedaAnticipo { get; set; }
        public decimal? MontoAnticipo { get; set; }
        public string? NroOrdenCompra { get; set; }
        public string? Observaciones { get; set; }
        public string? OrdenCompraServicio { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? TipoMotivoTraslado { get; set; }
        public decimal? PesoBrutoTotal { get; set; }
        public string? TipoModalidadTraslado { get; set; }
        public string? FechaInicioTraslado { get; set; }
        public string? RucTransportista { get; set; }
        public string? RazonSocialTransportista { get; set; }
        public string? NroPlacaVehiculo { get; set; }
        public string? NroDocumentoConductor { get; set; }
        public string? CondicionPago { get; set; }
        public decimal? DescuentoPorItem { get; set; }
        public string? TipoNotaCredito { get; set; }
        public string? TipoNotaDebito { get; set; }
        public string? TipoDocumentoRelacionado { get; set; }
        public string? NroDocumentoRelacionado { get; set; }
        public string? TipoFormaPago { get; set; }
        public SicfacDireccion? DireccionPartida { get; set; }
        public SicfacDireccion? DireccionLlegada { get; set; }
        public SicfacItem[]? Items { get; set; }
        public SicfacFormaPago[]? FormaPagos { get; set; }
    }

    public class SicfacResponse
    {
        public bool? Exito { get; set; }
        public string? MensajeError { get; set; }
        public string? Pila { get; set; }
        public string? CodigoEstadoSicfac { get; set; }
        public string? CodigoRespuestaSunat { get; set; }
        public string? MensajeRespuestaSunat { get; set; }
        public string? UrlPdf { get; set; }
        public string? FileXml { get; set; }
        public string? FileCdr { get; set; }
        public string? FilePdf { get; set; }
    }
}
