using Microsoft.AspNetCore.Mvc;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using backend.domain;
using iText.Pdfa;
using System.IO;

namespace backend.services.Utils
{
    public class FormatosContrato
    {
        public byte[] GetFormatoImpreso(int nIdFormato, string sCodigo, string sFormato, ContratoDTO contrato, List<CronogramaDTO> cronogramas, List<OrdenPagoPreContratoDTO> iniciales)
        {
            try
            {
                var dFechaImp = contrato.dFechaFirma != null ? contrato.dFechaFirma : contrato.dFechaVenta;

                var sCuerpo = sFormato;

                var html = "<style>.page-break { page-break-after: always; } </style>";

                html += "<div class=\"page-break\">";
                html += sCuerpo
                        .Replace("img/firma_luis_sarango_2023.png", dataImages.firmaLuisSarango)
                        .Replace("img/firma_luis_gutierrez_2023.png", dataImages.firmaLuisGutierrez)
                        .Replace("img/logo_inmobitec.png", dataImages.logoInmobitec2023)
                        .Replace("#sCodigoContrato#", contrato.sCodigo)
                        .Replace("#sProyecto#", contrato.sProyecto)
                        .Replace("#sNombreCliente#", contrato.sNombreCompleto)
                        .Replace("#sTipoDocumento#", String.IsNullOrEmpty(contrato.sDNI) ? "CE" : "DNI")
                        .Replace("#sDocumento#", String.IsNullOrEmpty(contrato.sDNI) ? contrato.sCE : contrato.sDNI)
                        .Replace("#sDNI#", contrato.sDNI)
                        .Replace("#sCE#", contrato.sCE)
                        .Replace("#sCelular#", contrato.sCelular)
                        .Replace("#sCelular2#", "-")
                        .Replace("#sCorreo#", contrato.sCorreo)
                        .Replace("#sEstadoCivil#", contrato.sEstadoCivil)
                        .Replace("#sDireccion#", contrato.sDireccion)
                        .Replace("#sDistrito#", contrato.sUbigeo.Split(',')[2].Trim())
                        .Replace("#sProvincia#", contrato.sUbigeo.Split(',')[1].Trim())
                        .Replace("#sDepartamento#", contrato.sUbigeo.Split(',')[0].Trim())
                        .Replace("#sDireccionConyugue#", contrato.sDireccion)
                        .Replace("#sDistritoConyugue#", contrato.sUbigeo.Split(',')[2].Trim())
                        .Replace("#sProvinciaConyugue#", contrato.sUbigeo.Split(',')[1].Trim())
                        .Replace("#sDepartamentoConyugue#", contrato.sUbigeo.Split(',')[0].Trim())
                        .Replace("#sNombreConyugue#", contrato.sNombreCompletoConyugue)
                        .Replace("#sCelularConyugue#", contrato.sCelularConyugue)
                        .Replace("#sCelular2Conyugue#", "-")
                        .Replace("#sCorreoConyugue#", contrato.sCorreoConyugue)
                        .Replace("#sEstadoCivilConyugue#", contrato.sEstadoCivilConyugue)
                        .Replace("#sTipoDocumentoConyugue#", String.IsNullOrEmpty(contrato.sDNIConyugue) ? "CE" : "DNI")
                        .Replace("#sDocumentoConyugue#", String.IsNullOrEmpty(contrato.sDNIConyugue) ? contrato.sCEConyugue : contrato.sDNIConyugue)
                        .Replace("#nMetraje#", contrato.nMetraje.ToString())
                        .Replace("#sLote#", contrato.sLote)
                        .Replace("#sManzana#", contrato.sManzana)
                        .Replace("#sSector#", contrato.sSector)
                        .Replace("#sFechaFirma#", dFechaImp != null ? dFechaImp?.ToString("dd/MM/yyyy") : "")
                        .Replace("#sFechaFirmaDia#", dFechaImp != null ? dFechaImp?.ToString("dd") : "")
                        .Replace("#sFechaFirmaMes#", dFechaImp != null ? dFechaImp?.ToString("MM") : "")
                        .Replace("#sFechaFirmaAnio#", dFechaImp != null ? dFechaImp?.ToString("yyyy") : "")
                        .Replace("#sFormaPago#", contrato.sCondicionPago)
                        .Replace("#sSimbolo#", contrato.sSimbolo)
                        .Replace("#nMontoFinal#", contrato.nMontoFinal.ToString("N2"))
                        .Replace("#nMontoFinalLetras#", new NumerosLetras().sConvertir(contrato.nMontoFinal) + " " + contrato.sMoneda)
                        .Replace("#nMontoInicial#", contrato.nMontoInicial == null ? "0.00" : contrato.nMontoInicial?.ToString("N2"))
                        .Replace("#nMontoInicialLetras#", new NumerosLetras().sConvertir(contrato.nMontoInicial != null ? (decimal) contrato.nMontoInicial! : 0) + " " + contrato.sMoneda)
                        .Replace("#nMontoFinanciado#", contrato.nMontoFinanciado == null ? "0.00": contrato.nMontoFinanciado?.ToString("N2"))
                        .Replace("#nMontoFinanciadoLetras#", new NumerosLetras().sConvertir(contrato.nMontoFinanciado != null ? (decimal) contrato.nMontoFinanciado! : 0) + " " + contrato.sMoneda)
                        .Replace("#nValorCuota#", contrato.nValorCuota == null? "0.00" : contrato.nValorCuota?.ToString("N2"))
                        .Replace("#sPromotor#", contrato.sPromotor)
                        .Replace("#sHOY#", DateTime.Now.ToString("dd/MM/yyyy"))
                        ;

                if (!string.IsNullOrEmpty(contrato.sFirma))
                {
                    html = html.Replace("img/firma_beneficiario.png", contrato.sFirma);
                }
                else 
                {
                    html = html.Replace("img/firma_beneficiario.png", dataImages.firmaBlanco);
                }

                if (!string.IsNullOrEmpty(contrato.sFirmaConyugue))
                {
                    html = html.Replace("img/firma_conyugue.png", contrato.sFirmaConyugue);
                }
                else
                {
                    html = html.Replace("img/firma_conyugue.png", dataImages.firmaBlanco);
                }

                if (contrato.bConyugue == true)
                {
                    html = html
                        .Replace("#IniDatosConyugue#", "")
                        .Replace("#FinDatosConyugue#", "");
                }
                else
                {
                    while (html.Contains("#IniDatosConyugue#")) {
                        string sIniConyugue = "#IniDatosConyugue#";
                        string sFinConyugue = "#FinDatosConyugue#";
                        string sConyugue = html.Substring(html.IndexOf(sIniConyugue), (html.IndexOf(sFinConyugue) + sFinConyugue.Length) - html.IndexOf(sIniConyugue));
                        html = html.Replace(sConyugue, "");
                    }
                }

                if (html.Contains("#iniCuotas#")) {
                    string sIniCuotas = "#iniCuotas#";
                    string sFinCuotas = "#finCuotas#";

                    string sLitaCuotas = html.Substring(html.IndexOf(sIniCuotas), (html.IndexOf(sFinCuotas) + sFinCuotas.Length) - html.IndexOf(sIniCuotas));
                    string sLitaCuotasFinal = "";

                    for (int i = 0; i < cronogramas.Count; i++)
                    {
                        sLitaCuotasFinal += sLitaCuotas
                        .Replace(sIniCuotas, "")
                        .Replace("#sNroCuota#", cronogramas[i].nNroCuota.ToString())
                        .Replace("#sFecVenCuota#", cronogramas[i].dFechaVencimiento.ToString("dd/MM/yyyy"))
                        .Replace("#sSimboloCuota#", cronogramas[i].sSimbolo)
                        .Replace("#sMontoCuota#", cronogramas[i].nMontoFinal.ToString("N2"))
                        .Replace("#sMoraCuota#", cronogramas[i].nMontoMora.ToString("N2"))
                        .Replace("#sEstadoCuotaCuota#", cronogramas[i].sEstado)
                        .Replace("#sComprobanteCuota#", "")
                        .Replace("#sFormaPagoCuota#", "")
                        .Replace("#sOPCuota#", "")
                        .Replace(sFinCuotas, "");
                    }

                    html = html.Replace(sLitaCuotas, sLitaCuotasFinal);
                }

                if (html.Contains("#IniPagosInicial#"))
                {
                    string sIniPagosInicial = "#IniPagosInicial#";
                    string sFinPagosInicial = "#FinPagosInicial#";

                    string sListPagosInicial = html.Substring(html.IndexOf(sIniPagosInicial), (html.IndexOf(sFinPagosInicial) + sFinPagosInicial.Length) - html.IndexOf(sIniPagosInicial));
                    string sListPagosInicialFinal = "";

                    for (int i = 0; i < iniciales.Count; i++)
                    {
                        sListPagosInicialFinal += sListPagosInicial
                        .Replace(sIniPagosInicial, "")
                        .Replace("#sConceptoPago#", iniciales[i].sItem)
                        .Replace("#sFecPago#", iniciales[i].dFecha_pago.ToString("dd/MM/yyyy"))
                        .Replace("#sSimboloPago#", iniciales[i].sSimbolo)
                        .Replace("#nMontoPago#", iniciales[i].nValorTotal.ToString("N2"))
                        .Replace("#sEstado#", iniciales[i].sEstado)
                        .Replace("#sComprobantePago#", iniciales[i].sComprobante)
                        .Replace("#sFormaPago#", "")
                        .Replace("#sOPPago#", "")
                        .Replace(sFinPagosInicial, "");
                    }

                    html = html.Replace(sListPagosInicial, sListPagosInicialFinal);
                }

                html += "</div>";

                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                if (sCodigo.Equals("5") || sCodigo.Equals("1"))
                {
                    Byte[] imageBytes = { };

                    if (sCodigo.Equals("1") && contrato.nIdProyecto == 2)
                    {
                        imageBytes = Convert.FromBase64String(dataImages.obrasGardenias.Replace("data:image/png;base64,", ""));
                    }

                    if (sCodigo.Equals("1") && contrato.nIdProyecto == 5)
                    {
                        imageBytes = Convert.FromBase64String(dataImages.obrasSauces.Replace("data:image/png;base64,", ""));
                    }

                    if (sCodigo.Equals("5") && contrato.nIdProyecto == 2) 
                    {
                        imageBytes = Convert.FromBase64String(dataImages.cesionGardenias.Replace("data:image/png;base64,", ""));
                    }

                    if (sCodigo.Equals("5") && contrato.nIdProyecto == 5)
                    {
                        imageBytes = Convert.FromBase64String(dataImages.cesionSauces.Replace("data:image/png;base64,", ""));
                    }

                    //if (sCodigo.Equals("6"))
                    //{
                    //    imageBytes = Convert.FromBase64String(dataImages.fondoConformidadContrato.Replace("data:image/png;base64,", ""));
                    //}

                    Image image = new Image(ImageDataFactory.Create(imageBytes));
                    image.SetWidth(pdfDocument.GetDefaultPageSize().GetWidth());
                    image.SetHeight(pdfDocument.GetDefaultPageSize().GetHeight());
                    image.SetFixedPosition(0, 0);
                    image.SetOpacity(1f);
                    pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundImageHandler(image));
                }

                HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                byte[] file = SetPagination(path, pdfDocument);
                return file;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] SetPagination(String path, PdfDocument pdfDocument) {
            try
            {
                string path2 = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                PdfDocument pdfDoc = new PdfDocument(new PdfReader(path), new PdfWriter(path2));
                Document doc = new Document(pdfDoc);

                int numberOfPages = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph(i + "/" + numberOfPages).SetFontSize(10), (pdfDocument.GetDefaultPageSize().GetWidth() / 2), 20, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
                }

                doc.Close();
            
                return File.ReadAllBytes(path2);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class BackgroundImageHandler : IEventHandler
    {
        protected Image img;
        public BackgroundImageHandler(Image _img)
        {
            this.img = _img;
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            Rectangle area = page.GetPageSize();
            new Canvas(canvas, area).Add(img);
        }
    }
}
