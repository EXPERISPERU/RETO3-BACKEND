using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjuntoController : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<string>>> UploadFile([FromBody] imbFile file)
        {
            FtpClient ftpClient = new FtpClient();
            var rsp = ftpClient.UploadFile(file);

            return StatusCode(StatusCodes.Status200OK, rsp);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> DownloadFile(string sRutaFile)
        {
            try
            {
                FtpClient client = new FtpClient();
                byte[] file = client.DownloadFile(sRutaFile);
                var extension = sRutaFile.Split('/')
                                            .Last()
                                            .Split('.')
                                            .Last()
                                            .ToLower();
                return File(file, client.sContentType(extension), sRutaFile.Split('/').Last());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet("[action]")]
        public async Task<ActionResult> GetFormato()
        {
            try
            {
                var sCuerpo = "<!DOCTYPE html>\r\n<html>\r\n    <head>\r\n        <title></title>\r\n    </head>\r\n    <body>\r\n        <h1>#sNombres#</h1>\r\n        <p>This is my first web page.</p>\r\n        <p>It contains a \r\n             <strong>main heading</strong> and <em> paragraph </em>.\r\n        </p>\r\n    <img src=\"https://www.w3schools.com/html/img_chania.jpg\"\r\nwidth=\"460\" height=\"345\" /></body>\r\n</html>";

                var html = "<style>.page-break { page-break-after: always; }</style>";

                html += "<div class=\"page-break\">";
                html += sCuerpo.Replace("#sNombres#", "Mario Robles");
                html += "</div>";

                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                string path2 = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                PdfDocument pdfDoc = new PdfDocument(new PdfReader(path), new PdfWriter(path2));
                Document doc = new Document(pdfDoc);

                int numberOfPages = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph(i + "/" + numberOfPages), 570, 20, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
                }

                doc.Close();

                byte[] file = System.IO.File.ReadAllBytes(path2);
                return File(file, "application/pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
