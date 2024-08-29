using backend.businesslogic.Maestros;
using backend.domain;
using Newtonsoft.Json;
using System.Text;

namespace backend.services.Utils
{
    public class SicFac
    {
        private string sicFacUrlBase;
        private string sicFacKey;

        public SicFac(IConfiguration configuration)
        {
            sicFacUrlBase = configuration["SicFacConfig:url"];
            sicFacKey = configuration["SicFacConfig:key"];
        }

        private ApiResponse<SqlRspDTO> consumirSevicio(string finalUrl, SicfacDocumentoElectronico sicfacDocumento)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient client = new HttpClient(clientHandler))
                {

                    var uri = new Uri(finalUrl);

                    var postJson = JsonConvert.SerializeObject(sicfacDocumento,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                            });
                    var rq = new StringContent(postJson, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(uri, rq).Result.Content.ReadAsStringAsync().Result;
                    var response = JsonConvert.DeserializeObject<SicfacResponse>(result);
                    return new ApiResponse<SqlRspDTO>()
                    {
                        success = response.Exito ?? false
                        ,
                        data = new SqlRspDTO() { nCod = response.Exito.HasValue ? 1 : 0, sMsj = response.CodigoRespuestaSunat + " - " + response.MensajeRespuestaSunat }
                        ,
                        errMsj = response.Exito.HasValue ? response.MensajeError : result.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<SqlRspDTO>() { success = false, data = new SqlRspDTO() { nCod = 0, sMsj = ""}, errMsj = ex.Message };
            }
        }

        private string TipoDocumento(string sCodigoTipoComprobante) 
        {
            if (sCodigoTipoComprobante == "14") return "01";

            if (sCodigoTipoComprobante == "3") return "03";

            if (sCodigoTipoComprobante == "18") return "07";

            return "";
        }

        public ApiResponse<SqlRspDTO> ConsultarDocumento(ComprobanteDTO comprobante) 
        {
            try
            {
                string finalUrl = this.sicFacUrlBase + "ConsultaDocumento";
                SicfacDocumentoElectronico sicfacDocumento = new SicfacDocumentoElectronico();

                sicfacDocumento.Serie = comprobante.sSerie;
                sicfacDocumento.Correlativo = comprobante.nCorrelativo.ToString();
                sicfacDocumento.TipoDocumento = this.TipoDocumento(comprobante.sCodigoTipoComprobante);

                sicfacDocumento.Emisor = new SicfacContribuyente()
                {
                    NroDocumento = comprobante.sRUC,
                    TipoDocumento = "1",
                    NombreLegal = comprobante.sCompania,
                    KeyRest = this.sicFacKey,
                };

                return this.consumirSevicio(finalUrl, sicfacDocumento);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SqlRspDTO>() { success = false, data = new SqlRspDTO() { nCod = 0, sMsj = ex.Message }, errMsj = ex.Message };
            }

        }

        public ApiResponse<SqlRspDTO> GenerarDocumento(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet)
        {
            try
            {
                string finalUrl = this.sicFacUrlBase + "GenerarDocumento";
                SicfacDocumentoElectronico sicfacDocumento = new SicfacDocumentoElectronico();

                sicfacDocumento.Emisor = new SicfacContribuyente()
                {
                    NroDocumento = comprobante.sRUCCompania,
                    TipoDocumento = "6",
                    NombreLegal = comprobante.sCompania,
                    KeyRest = this.sicFacKey,
                };

                sicfacDocumento.Receptor = new SicfacContribuyente()
                {
                    NroDocumento = !string.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sDNI : comprobante.sRUC,
                    TipoDocumento = !string.IsNullOrEmpty(comprobante.sDNI) ? "1" : "6",
                    NombreLegal = comprobante.sNombreCompleto,
                    Direccion = comprobante.sDireccion + " " + comprobante.sUbigeo.Replace(",", " -"),
                    Email = "",
                };

                sicfacDocumento.Serie = comprobante.sSerie;
                sicfacDocumento.Correlativo = comprobante.nCorrelativo.ToString();
                sicfacDocumento.TipoDocumento = this.TipoDocumento(comprobante.sCodigoTipoComprobante);
                sicfacDocumento.FechaEmision = comprobante.dFecha_crea.ToString("yyyy-MM-dd");
                sicfacDocumento.HoraEmision = comprobante.dFecha_crea.ToString("hh:mm:ss");
                sicfacDocumento.Moneda = comprobante.sSunatMoneda;
                sicfacDocumento.TipoOperacion = "0101";
                sicfacDocumento.Exoneradas = comprobante.nValorNoGravado;
                sicfacDocumento.Inafectas = comprobante.nValorInafecto;
                sicfacDocumento.Gravadas = comprobante.nValorSubTotal;
                sicfacDocumento.TotalIgv = comprobante.nValorIgv;
                sicfacDocumento.TotalVenta = comprobante.nValorTotal;
                sicfacDocumento.Exportacion = 0;
                sicfacDocumento.DescuentoGlobal = 0;
                sicfacDocumento.TotalIsc = 0;
                sicfacDocumento.TotalOtrosTributos = 0;
                sicfacDocumento.MontoPercepcion = 0;
                sicfacDocumento.MontoDetraccion = 0;
                sicfacDocumento.TasaDetraccion = 0;
                sicfacDocumento.CuentaBancoNacion = "";
                sicfacDocumento.CodigoBienOServicio = "";
                sicfacDocumento.CodigoMedioPago = "";
                sicfacDocumento.TipoDocAnticipo = "";
                sicfacDocumento.DocAnticipo = "";
                sicfacDocumento.MonedaAnticipo = "";
                sicfacDocumento.MontoAnticipo = 0;
                sicfacDocumento.NroOrdenCompra = "";
                sicfacDocumento.Observaciones = "|||";
                sicfacDocumento.OrdenCompraServicio = "";
                sicfacDocumento.PlacaVehiculo = "";
                sicfacDocumento.CondicionPago = "";
                sicfacDocumento.DescuentoPorItem = 0;
                sicfacDocumento.TipoNotaCredito = "";
                sicfacDocumento.TipoNotaDebito = "";
                sicfacDocumento.TipoDocumentoRelacionado = "";
                sicfacDocumento.NroDocumentoRelacionado = "";
                sicfacDocumento.TipoFormaPago = "";

                List<SicfacItem> items = new List<SicfacItem>();

                foreach (ComprobanteDetDTO det in comprobanteDet) 
                {
                    items.Add(new SicfacItem() {
                        Cantidad = det.nCantidad,
                        UnidadMedida = "NIU",
                        CodigoItem = "1",
                        Descripcion = det.sDescripcion.Replace("#n#", "\n"),
                        PrecioUnitario = det.nValorIgv.HasValue ? det.nValorUnitario * ((decimal) 1.18) : det.nValorUnitario,
                        ValorUnitario = det.nValorUnitario,
                        PrecioReferencial = det.nValorUnitario,
                        TipoPrecio = "01",
                        TipoImpuesto = det.nValorSubTotal.HasValue ? "10" : (det.nValorInafecto.HasValue ? "30" : "20" ),
                        Impuesto = det.nValorIgv ?? 0,
                        TotalVenta = det.nValorSubTotal ?? (det.nValorInafecto ?? det.nValorNoGravado),
                        Exonerado = det.nValorNoGravado ?? 0,
                        Inafecta = det.nValorInafecto ?? 0,
                        ImpuestoSelectivo = 0,
                        TasaImpuestoSelectivo = 0,
                        OtroImpuesto = 0,
                        Descuento = 0,
                        CodigoProductoSunat = "",
                        ValorReferencial = 0
                    });
                }

                sicfacDocumento.Items = items.ToArray();

                return this.consumirSevicio(finalUrl, sicfacDocumento);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SqlRspDTO>() { success = false, data = new SqlRspDTO() { nCod = 0, sMsj = ex.Message }, errMsj = ex.Message };            }
        }

        public ApiResponse<SqlRspDTO> GenerarBaja(ComprobanteDTO comprobante)
        {
            try
            {
                string finalUrl = this.sicFacUrlBase + "GenerarBaja";
                SicfacDocumentoElectronico sicfacDocumento = new SicfacDocumentoElectronico();

                sicfacDocumento.Serie = comprobante.sSerie;
                sicfacDocumento.Correlativo = comprobante.nCorrelativo.ToString();
                sicfacDocumento.TipoDocumento = this.TipoDocumento(comprobante.sCodigoTipoComprobante);

                sicfacDocumento.Emisor = new SicfacContribuyente()
                {
                    NroDocumento = comprobante.sRUC,
                    TipoDocumento = "1",
                    NombreLegal = comprobante.sCompania,
                    KeyRest = this.sicFacKey,
                };

                return this.consumirSevicio(finalUrl, sicfacDocumento);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SqlRspDTO>() { success = false, data = new SqlRspDTO() { nCod = 0, sMsj = ex.Message }, errMsj = ex.Message };
            }
        }
    }
}
