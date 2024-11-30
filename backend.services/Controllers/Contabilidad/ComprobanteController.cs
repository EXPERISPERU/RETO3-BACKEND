using backend.domain;
using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.businesslogic.Interfaces.Contabilidad;
using System.Globalization;
using QRCoder;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprobanteController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IComprobanteBL service;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ComprobanteController(IConfiguration _configuration, IComprobanteBL _service, IWebHostEnvironment _hostingEnvironment)
        {
            this.configuration = _configuration;
            this.service = _service;
            this.hostingEnvironment = _hostingEnvironment;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteDTO>>>> getListComprobante([FromBody] FilterComprobanteDTO filtroComprobante)
        {
            ApiResponse<List<ComprobanteDTO>> response = new ApiResponse<List<ComprobanteDTO>>();

            try
            {
                var result = await service.getListComprobante(filtroComprobante);

                response.success = true;
                response.data = (List<ComprobanteDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> getFormatoComprobante(int nIdComprobante)
        {
            try
            {
                CultureInfo ci_PE = new CultureInfo("es-PE");

                ComprobanteDTO comprobante = await service.getComprobanteById(nIdComprobante);
                List<ComprobanteDetDTO> listComprobanteDet = await service.getComprobanteDetById(nIdComprobante);
                List<ComprobanteMetodoPagoDTO> metodosPago = await service.getMetodoPagoById(nIdComprobante);
                byte[] file;

                if (comprobante.nIdAdjunto == null)
                {
                    var sCuerpo = await service.formatoComprobanteByIdComprobante(nIdComprobante);

                    var html = "";

                    var logoCompania = "";
                    var logoNC = "";

                    var metodos = "";

                    if (metodosPago.Count() > 0)
                    {
                        for (int i = 0; i < metodosPago.Count(); i++)
                        {
                            metodos += $"{metodosPago[i].sAbrev} ";
                            if (metodosPago[i].sAbrev != "Efectivo")
                            {
                                metodos += $"- {metodosPago[i].sDetalle}";
                            }
                        }
                    }

                    if (comprobante.sCodigoTipoComprobante == "4")
                    {
                        if (comprobante.nCodigoCompania == 1 || comprobante.nCodigoCompania == 4)
                        {
                            logoCompania = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_psvds.png"));
                        }
                        else if (comprobante.nCodigoCompania == 3)
                        {
                            logoCompania = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_villa_azul.png"));
                        }

                        html = "<style>.page-break { page-break-after: always; }</style>";

                        html += "<div class=\"page-break\">";
                        html += sCuerpo
                                .Replace("#sLogoData#", logoCompania)
                                .Replace("#sLogoDataBack#", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "background_recibo_psvds.png")))
                                .Replace("#sCorrelativo#", comprobante.sComprobante)
                                .Replace("#sNombreCliente#", comprobante.sNombreCompleto)
                                .Replace("#sDocumentoCliente#", String.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sCE : comprobante.sDNI)
                                .Replace("#sDireccionCliente#", comprobante.sDireccion)
                                .Replace("#sCelularCliente#", comprobante.sCelular)
                                .Replace("#sTelefonoCliente#", comprobante.sTelefono)
                                .Replace("#sFecha#", comprobante.sFecha_crea.Split(" ")[0])
                                .Replace("#sSimbolo#", comprobante.sSimbolo)
                                .Replace("#sTotal#", string.Format(ci_PE, "{0:0,0.00}", comprobante.nValorTotal));
                        html += "</div>";

                        string sIniItems = "#iniItems#";
                        string sFinItems = "#finItems#";

                        string slistaItems = sCuerpo.Substring(sCuerpo.IndexOf(sIniItems), (sCuerpo.IndexOf(sFinItems) + sFinItems.Length) - sCuerpo.IndexOf(sIniItems));
                        string slistaItemsFinal = "";

                        for (int i = 0; i < listComprobanteDet.Count; i++)
                        {
                            string sItem = "#sItemDescripcion#";
                            if (sCuerpo.Contains("#iniItem#"))
                            {
                                string sIniItem = "#iniItem#";
                                string sFinItem = "#finItem#";
                                sItem = sCuerpo.Substring(sCuerpo.IndexOf(sIniItem), (sCuerpo.IndexOf(sFinItem) + sFinItem.Length) - sCuerpo.IndexOf(sIniItem));
                            }

                            slistaItemsFinal += slistaItems
                            .Replace(sIniItems, "")
                            .Replace("#nroItem#", (i + 1).ToString())
                            .Replace(sItem, listComprobanteDet[i].sDescripcion.Replace("#n#", "<br>"))
                            .Replace("#sSimboloItem#", listComprobanteDet[i].sSimbolo)
                            .Replace("#sTotalItem#", string.Format(ci_PE, "{0:0,0.00}", listComprobanteDet[i].nValorTotal))
                            .Replace(sFinItems, "");
                        }

                        html = html.Replace(slistaItems, slistaItemsFinal);

                    }

                    if (comprobante.sCodigoTipoComprobante == "3" || comprobante.sCodigoTipoComprobante == "18")
                    {
                        if (comprobante.nCodigoCompania == 1)
                        {
                            logoNC = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_inmobitec_nc.png"));
                        }

                        if (comprobante.nCodigoCompania == 2)
                        {
                            logoCompania = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_leon_beach.png"));
                        }
                        else if (comprobante.nCodigoCompania == 3)
                        {
                            logoCompania = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_psvds.png"));
                        }

                        string qrContent = comprobante.sRUCCompania
                                            + "|" + new Sunat().TipoDocumento(comprobante.sCodigoTipoComprobante)
                                            + "|" + comprobante.sSerie
                                            + "|" + comprobante.nCorrelativo.ToString()
                                            + "|" + string.Format(ci_PE, "{0:0.00}", comprobante.nValorIgv)
                                            + "|" + string.Format(ci_PE, "{0:0.00}", comprobante.nValorTotal)
                                            + "|" + comprobante.dFecha_crea.ToString("dd/MM/yyyy")
                                            + "|" + (!string.IsNullOrEmpty(comprobante.sDNI) ? "1" : "6")
                                            + "|" + (!string.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sDNI : comprobante.sRUC);

                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q);
                        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                        var qrImage = "data:image/png; base64," + Convert.ToBase64String(qrCode.GetGraphic(20));

                        html = "<style>.page-break { page-break-after: always; } @page { margin: 0pt; margin-top: 15pt }</style>";
                        html += "<div class=\"page-break\">";
                        html += sCuerpo
                        .Replace("#sLogoNotaCredito#", logoNC)
                        .Replace("#sLogoData#", logoCompania)
                        .Replace("ComprobanteHeader.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "header_boleta_inmobitec.png")))
                        .Replace("BbvaLogo.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_bbva.png")))
                        .Replace("facebookIcon.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "ico_facebook.png")))
                        .Replace("youtubeIcon.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "ico_youtube.png")))
                        .Replace("linkIcon.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "ico_link.png")))
                        .Replace("ComprobanteFooter.png", new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "footer_boleta_inmobitec.png")))
                        .Replace("#sRUCCompania#", comprobante.sRUCCompania)
                        .Replace("#sTipoComprobante#", comprobante.sTipoComprobante)
                        .Replace("#sComprobante#", comprobante.sComprobante)
                        .Replace("#sNombreCompleto#", comprobante.sNombreCompleto)
                        .Replace("#sDocumento#", String.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sCE : comprobante.sDNI)
                        .Replace("#sDireccion#", comprobante.sDireccion)
                        .Replace("#sMetodosPago#", metodos)
                        .Replace("#sUbigeo#", comprobante.sUbigeo)
                        .Replace("#sMoneda#", comprobante.sMoneda.ToUpper())
                        .Replace("#sIGV#", "18.00 %")
                        .Replace("#sFechaEmision#", comprobante.sFecha_crea.Split(" ")[0])
                        .Replace("#sCondicionPago#", "")
                        .Replace("#sOrdenPago#", "")
                        .Replace("#sFechaVencimiento#", "")
                        .Replace("#sGuiaRemision#", "")
                        .Replace("#sTipoComprobanteOrigen#", string.IsNullOrEmpty(comprobante.sTipoComprobanteOrigen) ? "" : comprobante.sTipoComprobanteOrigen)
                        .Replace("#sComprobanteOrigen#", string.IsNullOrEmpty(comprobante.sComprobanteOrigen) ? "" : comprobante.sComprobanteOrigen)
                        .Replace("#sTipoNCD#", String.IsNullOrEmpty(comprobante.sTipoOperacionNcd) ? "" : comprobante.sTipoOperacionNcd)
                        .Replace("#sMotivoNCD#", String.IsNullOrEmpty(comprobante.sMotivoNotaCd) ? "" : comprobante.sMotivoNotaCd)
                        .Replace("#sOPGravadas#", comprobante.sSimbolo + " " + string.Format(ci_PE, "{0:0,0.00}", comprobante.nValorSubTotal))
                        .Replace("#sOPInafecta#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPExonerada#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPExportacion#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPGratuitas#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sDescuentosTotales#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sSubTotal#", comprobante.sSimbolo + " " + string.Format(ci_PE, "{0:0,0.00}", comprobante.nValorSubTotal))
                        .Replace("#sIcbPer#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sIsc#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sValorIGV#", comprobante.sSimbolo + " " + string.Format(ci_PE, "{0:0,0.00}", comprobante.nValorIgv))
                        .Replace("#sTotal#", comprobante.sSimbolo + " " + string.Format(ci_PE, "{0:0,0.00}", comprobante.nValorTotal))
                        .Replace("#sMONTOLETRAS#", new NumerosLetras().sConvertir(Math.Round(comprobante.nValorTotal, 2)))
                        .Replace("#sQRData#", qrImage)
                        .Replace("#sDatosAdicionales#", "");

                        string sIniItems = "#iniItems#";
                        string sFinItems = "#finItems#";

                        string slistaItems = sCuerpo.Substring(sCuerpo.IndexOf(sIniItems), (sCuerpo.IndexOf(sFinItems) + sFinItems.Length) - sCuerpo.IndexOf(sIniItems));
                        string slistaItemsFinal = "";

                        for (int i = 0; i < listComprobanteDet.Count; i++)
                        {
                            slistaItemsFinal += slistaItems
                            .Replace(sIniItems, "")
                            .Replace("#sItemCodigo#", (i + 1).ToString())
                            .Replace("#sItemCant#", "1")
                            .Replace("#sItemUnd#", "UNIDAD")
                            .Replace("#sItemDescripcion#", listComprobanteDet[i].sDescripcion.Replace("#n#", "<br>"))
                            .Replace("#sItemValor#", string.Format(ci_PE, "{0:0,0.00}", listComprobanteDet[i].nValorSubTotal))
                            .Replace("#sItemDscto#", "0.00")
                            .Replace("#sItemTotal#", string.Format(ci_PE, "{0:0,0.00}", listComprobanteDet[i].nValorSubTotal))
                            .Replace(sFinItems, "");
                        }

                        html = html.Replace(slistaItems, slistaItemsFinal);
                    }
                    html += "</div>";

                    string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                    ConverterProperties properties = new ConverterProperties();
                    properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                    pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                    HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                    file = System.IO.File.ReadAllBytes(path);

                    string sRutaFile = string.Format("comprobantes/{0}.pdf", nIdComprobante);

                    ApiResponse<string> resFtp = new FtpClient(configuration).UploadFile(new imbFile { sRutaFile = sRutaFile, data = file });

                    if (resFtp.success)
                    {
                        await service.InsComprobanteAdjunto(nIdComprobante, sRutaFile);
                    }
                }
                else
                {
                    file = new FtpClient(configuration).DownloadFile(comprobante.sRutaFtp);
                }

                return File(file, "application/pdf");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> certificarComprobante(int nIdComprobante)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                ComprobanteDTO comprobante = await service.getComprobanteById(nIdComprobante);
                List<ComprobanteDetDTO> listComprobanteDet = await service.getComprobanteDetById(nIdComprobante);
                ComprobanteDTO comprobanteOrigen = new ComprobanteDTO();
                List<ComprobanteMetodoPagoDTO> metodosPago = await service.getMetodoPagoById(nIdComprobante);



                if (comprobante.sCodigoTipoComprobante == "18")
                {
                    comprobanteOrigen = await service.getComprobanteById(comprobante.nIdComprobanteOrigen.Value);
                }

                if (comprobante.nCodigoCompania == 1)
                {

                    efactResponseDTO res = await new Efact(configuration).GenerarDocumento(comprobante, listComprobanteDet, comprobanteOrigen, metodosPago);

                    service.InsCertificacionComprobante(nIdComprobante, res.code, res.description, null, null, res.code == "0" ? res.description : null, res.code == "0");
                }

                if (comprobante.nCodigoCompania == 2)
                {
                    SicfacResponse sres = new SicFac(configuration).GenerarDocumento(comprobante, listComprobanteDet);

                    response.success = sres.Exito ?? false;
                    response.errMsj = sres.MensajeError;
                    response.data = new SqlRspDTO() { nCod = (sres.Exito == true ? int.Parse(sres.CodigoEstadoSicfac) : 0), sMsj = "" };

                    service.InsCertificacionComprobante(nIdComprobante, sres.CodigoEstadoSicfac, sres.MensajeError, sres.CodigoRespuestaSunat, sres.MensajeRespuestaSunat, null, sres.Exito ?? false);
                }

                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<int>>>> getComprobantesPendientesCertByCompania(int nCodigoCompania)
        {
            ApiResponse<List<int>> response = new ApiResponse<List<int>>();

            try
            {
                var result = await service.getComprobantesPendientesCertByCompania(nCodigoCompania);

                response.success = true;
                response.data = (List<int>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> posInsNotaCredito([FromBody] NotaCreditoDTO notaCredito)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.posInsNotaCredito(notaCredito);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListTipoNotaCredito()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListTipoNotaCredito();

                response.success = true;
                response.data = (List<SelectDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoMotivoBaja()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoMotivoBaja();

                response.success = true;
                response.data = (List<SelectDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsComprobanteBaja([FromBody] ComprobanteBajaDTO comprobanteBaja)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsComprobanteBaja(comprobanteBaja);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<LoginDTO>>>> getAuthUserBaja(string sUsuario, string sContrasena)
        {
            ApiResponse<List<LoginDTO>> response = new ApiResponse<List<LoginDTO>>();

            try
            {
                var result = await service.AuthUserBaja(sUsuario, sContrasena);

                response.success = true;
                response.data = (List<LoginDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<ComprobanteDTO>>> getComprobanteById(int nIdComprobante)
        {
            ApiResponse<ComprobanteDTO> response = new ApiResponse<ComprobanteDTO>();

            try
            {
                var result = await service.getComprobanteById(nIdComprobante);

                response.success = true;
                response.data = (ComprobanteDTO)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteDetDTO>>>> getComprobanteDetyId(int nIdComprobante)
        {
            ApiResponse<List<ComprobanteDetDTO>> response = new ApiResponse<List<ComprobanteDetDTO>>();

            try
            {
                var result = await service.getComprobanteDetById(nIdComprobante);

                response.success = true;
                response.data = (List<ComprobanteDetDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> certificarComprobanteBaja(int nIdComprobanteBaja)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                ComprobanteBajaDTO comprobanteBaja = await service.getComprobanteBajaById(nIdComprobanteBaja);

                efactResponseDTO res = await new Efact(configuration).BajaDocumento(comprobanteBaja);

                // if (comprobante.sCodigoTipoComprobante == "18")
                // {
                //     comprobanteOrigen = await service.getComprobanteById(comprobante.nIdComprobanteOrigen.Value);
                // }

                // if (comprobante.nCodigoCompania == 1)
                // {

                //     efactResponseDTO res = await new Efact(configuration).GenerarDocumento(comprobante, listComprobanteDet, comprobanteOrigen, metodosPago);

                //     service.InsCertificacionComprobante(nIdComprobante, res.code, res.description, null, null, res.code == "0" ? res.description : null, res.code == "0");
                // }

                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteDTO>>>> getListComprobanteEgresosCaja([FromBody] SelectComprobanteEgresoCajaDTO selectComprobanteEgresoCaja)
        {
            ApiResponse<List<ComprobanteDTO>> response = new ApiResponse<List<ComprobanteDTO>>();

            try
            {
                var result = await service.getListComprobanteEgresosCaja(selectComprobanteEgresoCaja);

                response.success = true;
                response.data = (List<ComprobanteDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
