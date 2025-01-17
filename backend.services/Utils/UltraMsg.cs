using System.Globalization;
using System.Text;
using System.Text.Json;
using backend.domain;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Layout;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backend.services.Utils
{
    public class UltraMsg
    {
        private string sUltraMsgUrl;
        private string sUltraMsgInstance;
        private string sUltraMsgToken;
        private readonly IWebHostEnvironment hostingEnvironment;

        public UltraMsg(IConfiguration configuration, IWebHostEnvironment _hostingEnvironment)
        {
            sUltraMsgUrl = configuration["UltraMsg:url"];
            sUltraMsgInstance = configuration["UltraMsg:instance"];
            sUltraMsgToken = configuration["UltraMsg:token"];
            hostingEnvironment = _hostingEnvironment;
        }

        private string estructurarMensaje(ContratoDTO contrato, PlantillaNotificacionDTO plantilla)
        {
            var layout = plantilla.sContenido ?? "";
            layout = layout.Replace("*#sNombreProyecto#*", $"*{contrato.sProyecto}*");
            return layout;
        }

        private async Task<string> crearFormato(ContratoDTO contrato, FormatoDTO formato, IList<CronogramaDeudaDTO> cronogramaDeudas, ContratosDeudaDTO contratosDeuda)
        {
            try
            {
                byte[] file;
                DateTime fechaActual = DateTime.Now;
                Byte[] imageBytes = { };

                var fechaFormat = FormatearFecha(fechaActual);
                var tablaCuotas = "";

                var montoVencido = contratosDeuda.nMontoFinalVencido ?? 0;

                var estructure = formato.sCuerpo ?? "";

                decimal? totalMonto = cronogramaDeudas.Sum(c => (c.nMonto + c.nValorMora));

                if (cronogramaDeudas.Count() > 0)
                {
                    for (int i = 0; i < cronogramaDeudas.Count(); i++)
                    {
                        tablaCuotas += $"<tr><td style='border: solid 1px black; border-collapse: collapse; text-align:center'>{cronogramaDeudas[i].nNroCuota}</td><td style='border: solid 1px black; border-collapse: collapse; text-align:center'>{cronogramaDeudas[i].dFechaVencimiento}</td><td style='border: solid 1px black; border-collapse: collapse; text-align:center'>S/. {cronogramaDeudas[i].nMonto}</td><td style='border: solid 1px black; border-collapse: collapse; text-align:center'>S/. {cronogramaDeudas[i].nValorMora}</td><td style='border: solid 1px black; border-collapse: collapse; text-align:center' rowspan='{cronogramaDeudas.Count()}'>{totalMonto}</td></tr>";
                    }
                }
                else
                {
                    tablaCuotas += $"<tr><td style='text-align: center' colspan='5'>No tiene Deudas Pendientes</td></tr>";
                }

                estructure = estructure.Replace("#sFechaCompleto#", fechaFormat)
                                .Replace("#sNombreCompleto#", contrato.sNombreCompleto)
                                .Replace("#sNombreProyecto#", contrato.sProyecto)
                                .Replace("#sManzana#", contrato.sManzana)
                                .Replace("#sLote#", contrato.sLote)
                                .Replace("#sDireccion#", contrato.sDireccion)
                                .Replace("#sCodigo#", contrato.sCodigo)
                                .Replace("#nCuotasPendientes#", contratosDeuda.nCuotasVencidas.ToString())
                                .Replace("#tablaCuotas#", tablaCuotas)
                                .Replace("#tCuotasPendientes#", Math.Round(montoVencido, 2).ToString())
                                .Replace("#sMONTOLETRAS#", new NumerosLetras().sConvertir(Math.Round(montoVencido, 2)));


                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));

                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                imageBytes = Convert.FromBase64String(new ImagesData().GetImageWithoutBase(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "membretada_notificaciones.png")));


                Image image = new Image(ImageDataFactory.Create(imageBytes));
                image.SetWidth(pdfDocument.GetDefaultPageSize().GetWidth());
                image.SetHeight(pdfDocument.GetDefaultPageSize().GetHeight());
                image.SetFixedPosition(0, 0);
                image.SetOpacity(1f);
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundImageHandler(image));

                HtmlConverter.ConvertToPdf(estructure, pdfDocument, properties);

                file = System.IO.File.ReadAllBytes(path);
                string base64File = Convert.ToBase64String(file);

                return base64File;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        private async Task<string> estructurarEnvio(NotificacionDTO notificacion, ContratoDTO contrato, PlantillaNotificacionDTO plantilla, FormatoDTO? formato, IList<CronogramaDeudaDTO>? cronogramaDeudas, ContratosDeudaDTO? contratosDeuda)
        {
            var mensaje = estructurarMensaje(contrato, plantilla);

            var structureDc = new Dictionary<string, string>
            {
                { "token", sUltraMsgToken ?? string.Empty },
                { "to", contrato?.sCelular ?? contrato?.sCelular2 ?? string.Empty },
                { "body", null },
                { "document", null },
                { "filename", null },
                { "caption", null },
                { "image", null },
            };

            if (notificacion.nIdTipoNotificacion == 317) //IMAGE
            {
                structureDc["image"] = "";
                structureDc["caption"] = "";
            }

            if (notificacion.nIdTipoNotificacion == 318) //CHAT
            {
                structureDc["body"] = mensaje;
            }

            if (notificacion.nIdTipoNotificacion == 319) //DOCUMENT
            {
                var archivo = await crearFormato(contrato, formato, cronogramaDeudas, contratosDeuda);
                structureDc["document"] = archivo;
                structureDc["filename"] = $"{contrato.sProyecto} - MZ {contrato.sManzana} LT {contrato.sLote}.pdf";
                structureDc["caption"] = mensaje;

            }

            var jsonRequest = JsonConvert.SerializeObject(
                structureDc,
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            );

            return jsonRequest;
        }

        private string estructurarUrl(string sTipoNotificacion)
        {
            var sUrlEndpoint = $"/messages/{sTipoNotificacion ?? ""}";

            return sUltraMsgUrl + sUltraMsgInstance + sUrlEndpoint;
        }

        public async Task<NotificacionResponseDTO> enviarNotificacion(NotificacionDTO? notificacion, ContratoDTO contrato, PlantillaNotificacionDTO plantilla, FormatoDTO? formato, IList<CronogramaDeudaDTO> cronogramaDeudas, ContratosDeudaDTO contratosDeuda)
        {
            try
            {

                var body = await estructurarEnvio(notificacion, contrato, plantilla, formato, cronogramaDeudas, contratosDeuda);

                var content = new StringContent(body, Encoding.UTF8, "application/json");

                string urlFinal = estructurarUrl(notificacion.sTipoNotificacion);

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(urlFinal, content);
                    int status = (int)response.StatusCode;

                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<NotificacionResponseDTO>(res);

                    if (status == 200)
                    {
                        return result;
                    }
                    else
                    {
                        return new NotificacionResponseDTO() { sent = (bool)result?.sent, message = result?.message, id = (int)result?.id };
                    }
                }
            }
            catch (Exception ex)
            {
                return new NotificacionResponseDTO() { sent = false, error = ex?.Message };
            }
        }

        public string FormatearFecha(DateTime fecha)
        {
            // Obtener el día de la semana en español
            string diaSemana = fecha.ToString("dddd", new CultureInfo("es-ES"));
            // Obtener el día del mes
            int dia = fecha.Day;
            // Obtener el mes en español
            string mes = fecha.ToString("MMMM", new CultureInfo("es-ES"));
            // Obtener el año
            int año = fecha.Year;

            // Formatear la fecha
            return $"{Capitalizar(diaSemana)} {dia} de {Capitalizar(mes)} del {año}";
        }

        static string Capitalizar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return char.ToUpper(texto[0]) + texto.Substring(1);
        }


    }
}
