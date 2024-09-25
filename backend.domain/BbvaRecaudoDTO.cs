namespace backend.domain
{
    public class bbvaRequest
    {
        public bbvaRecaudo recaudosRq { get; set; }
    }

    public class bbvaResponse
    {
        public bbvaRecaudo recaudosRs { get; set; }
    }

    public class bbvaRecaudo
    { 
        public bbvaCabecera cabecera { get; set; }
        public bbvaDetalle detalle { get; set; }
    }

    public class bbvaCabecera
    { 
        public bbvaOperacion operacion {  get; set; }  
    }

    public class bbvaDetalle
    { 
        public bbvaRespuesta? respuesta { get; set; }
        public bbvaTransaccion? transaccion { get; set; }
    }

    public class bbvaOperacion
    {
        public int codigoOperacion { get; set; }
        public int numeroOperacion { get; set; }
        public int codigoBanco { get; set; }
        public int codigoConvenio { get; set; }
        public string canalOperacion { get; set; }
        public string codigoOficina { get; set; }
        public string fechaOperacion { get; set; }
        public string horaOperacion { get; set; }
    }

    public class bbvaTransaccion
    { 
        public string numeroReferenciaDeuda { get; set; }
        public string? datosEmpresa { get; set; }

        #region Request
        public decimal? importeDeudaPagada { get; set; }
        public decimal? numeroOperacionRecaudos { get; set; }
        public string? formaPago { get; set; }
        public string? codigoMoneda { get; set; }
        public string? otrosDatosEmpresa { get; set; }
        #endregion

        #region Response
        public string? nombreCliente { get; set; }
        public string? numeroOperacionEmpresa { get; set; }
        public int? indMasDeuda { get; set; }
        public int? cantidadDocsDeuda { get; set; }
        public string? numeroDocumento { get; set; }
        public bbvaListaDocumento? listaDocumentos { get; set; }
        #endregion
    }

    public class bbvaListaDocumento
    {
        public bbvaDocumento[] documento { get; set; }
    }

    public class bbvaDocumento 
    {
        public string numero { get; set; }
        public string descripcion { get; set; }
        public string fechaEmision { get; set; }
        public string fechaVencimiento { get; set; }
        public string importeDeuda { get; set; }
        public string importeDeudaMinima { get; set; }
        public string indicadorRestriccPago { get; set; }
        public string cantidadSubconceptos { get; set; }
    }

    public class bbvaRespuesta
    { 
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class bbvaConsultarDeudaRq
    {
        public bbvaRequest ConsultarDeuda { get; set; }
    }

    public class bbvaConsultarDeudaRs
    {
        public bbvaResponse ConsultarDeudaResponse { get; set; }
    }

    public class bbvaNotificarPagoRq
    {
        public bbvaRequest NotificarPago { get; set; }
    }

    public class bbvaNotificarPagoRs
    {
        public bbvaResponse NotificarPagoResponse { get; set; }
    }
}
