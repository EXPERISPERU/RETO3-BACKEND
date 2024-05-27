using backend.domain;
using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.businesslogic.Interfaces.Contabilidad;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprobanteController : ControllerBase
    {
        private readonly IComprobanteBL service;

        public ComprobanteController(IComprobanteBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> getFormatoComprobante(int nIdCompania, int nIdProyecto, int nIdComprobante)
        {
            try
            {
                ComprobanteDTO comprobante = await service.getComprobanteById(nIdComprobante);
                List<ComprobanteDetDTO> listComprobanteDet = await service.getComprobanteDetById(nIdComprobante);
                byte[] file;

                if (comprobante.nIdAdjunto == null)
                {
                    var sCuerpo = await service.formatoComprobanteByIdComprobante(nIdCompania, nIdProyecto, nIdComprobante);

                    var html = "";

                    var logoCompania = "";
                    if (nIdCompania == 1)
                    {
                        logoCompania = dataImages.psViviendasDelSur;
                    }
                    else if (nIdCompania == 5)
                    {
                        logoCompania = dataImages.psVillaAzul;
                    }

                    if (comprobante.sCodigoTipoComprobante == "4")
                    {
                        html = "<style>.page-break { page-break-after: always; }</style>";
                        
                        html += "<div class=\"page-break\">";
                        html += sCuerpo
                                .Replace("#sLogoData#", logoCompania)
                                .Replace("#sCorrelativo#", comprobante.sComprobante)
                                .Replace("#sNombreCliente#", comprobante.sNombreCompleto)
                                .Replace("#sDocumentoCliente#", String.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sCE : comprobante.sDNI)
                                .Replace("#sDireccionCliente#", comprobante.sDireccion)
                                .Replace("#sCelularCliente#", comprobante.sCelular)
                                .Replace("#sTelefonoCliente#", comprobante.sTelefono)
                                .Replace("#sFecha#", comprobante.sFecha_crea.Split(" ")[0])
                                .Replace("#sSimbolo#", comprobante.sSimbolo)
                                .Replace("#sTotal#", comprobante.nValorTotal.ToString("0.00"));
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
                            .Replace("#sTotalItem#", listComprobanteDet[i].nValorTotal.ToString("0.00"))
                            .Replace(sFinItems, "");
                        }

                        html = html.Replace(slistaItems, slistaItemsFinal);

                    }

                    if (comprobante.sCodigoTipoComprobante == "3")
                    {
                        html = "<style>.page-break { page-break-after: always; } @page { margin: 0pt; margin-top: 15pt }</style>";
                        html += "<div class=\"page-break\">";
                        html += sCuerpo
                        .Replace("ComprobanteHeader.png", dataImages.headerBoleta)
                        .Replace("BbvaLogo.png", dataImages.bbvaLogo)
                        .Replace("facebookIcon.png", dataImages.facebookIcon)
                        .Replace("youtubeIcon.png", dataImages.youtubeIcon)
                        .Replace("linkIcon.png", dataImages.linkIcon)
                        .Replace("ComprobanteFooter.png", dataImages.footerBoleta)                
                        .Replace("#sComprobante#", comprobante.sComprobante)
                        .Replace("#sNombreCompleto#", comprobante.sNombreCompleto)
                        .Replace("#sDocumento#", String.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sCE : comprobante.sDNI)
                        .Replace("#sDireccion#", comprobante.sDireccion)
                        .Replace("#sUbigeo#", comprobante.sUbigeo)
                        .Replace("#sMoneda#", comprobante.sMoneda.ToUpper())
                        .Replace("#sIGV#", "18.00 %")
                        .Replace("#sFechaEmision#", comprobante.sFecha_crea.Split(" ")[0])
                        .Replace("#sCondicionPago#", "")
                        .Replace("#sOrdenPago#", "")
                        .Replace("#sFechaVencimiento#", "")
                        .Replace("#sGuiaRemision#", "")
                        .Replace("#sOPGravadas#", comprobante.sSimbolo + " " + comprobante.nValorSubTotal.ToString("0.00"))
                        .Replace("#sOPInafecta#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPExonerada#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPExportacion#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sOPGratuitas#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sDescuentosTotales#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sSubTotal#", comprobante.sSimbolo + " " + comprobante.nValorSubTotal.ToString("0.00"))
                        .Replace("#sIcbPer#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sIsc#", comprobante.sSimbolo + " 0.00")
                        .Replace("#sValorIGV#", comprobante.sSimbolo + " " + comprobante.nValorIgv.ToString("0.00"))
                        .Replace("#sTotal#", comprobante.sSimbolo + " " + comprobante.nValorTotal.ToString("0.00"))
                        .Replace("#sLogoData#", logoCompania)
                        .Replace("#sCorrelativo#", comprobante.sComprobante)
                        .Replace("#sNombreCliente#", comprobante.sNombreCompleto)
                        .Replace("#sDocumentoCliente#", String.IsNullOrEmpty(comprobante.sDNI) ? comprobante.sCE : comprobante.sDNI)
                        .Replace("#sDireccionCliente#", comprobante.sDireccion)
                        .Replace("#sCelularCliente#", comprobante.sCelular)
                        .Replace("#sTelefonoCliente#", comprobante.sTelefono)
                        .Replace("#sFecha#", comprobante.sFecha_crea.Split(" ")[0])
                        .Replace("#sSimbolo#", "")
                        .Replace("#sTotal#", comprobante.nValorTotal.ToString("0.00"))
                        .Replace("#sMONTOLETRAS#", new NumerosLetras().sConvertir(Math.Round(comprobante.nValorTotal, 2)));

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
                            .Replace("#sItemDescripcion#", listComprobanteDet[i].sDescripcion.Replace("#n#","<br>"))
                            .Replace("#sItemValor#", listComprobanteDet[i].nValorSubTotal.ToString("0.00"))
                            .Replace("#sItemDscto#", "0.00")
                            .Replace("#sItemTotal#", listComprobanteDet[i].nValorSubTotal.ToString("0.00"))
                            .Replace("#nroItem#", (i + 1).ToString())
                            .Replace("#sSimboloItem#", listComprobanteDet[i].sSimbolo)
                            .Replace("#sTotalItem#", listComprobanteDet[i].nValorTotal.ToString("0.00"))
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

                    ApiResponse<string> resFtp = new FtpClient().UploadFile(new imbFile { sRutaFile = sRutaFile, data = file });

                    if (resFtp.success)
                    {
                        await service.InsComprobanteAdjunto(nIdComprobante, sRutaFile);
                    }
                }
                else
                {
                    file = new FtpClient().DownloadFile(comprobante.sRutaFtp);
                }

                return File(file, "application/pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
