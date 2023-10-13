using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> DownloadFile(string sFile, string sFileExtension)
        {
            FtpClient client = new FtpClient();
            byte[] file = client.DownloadFile(sFile);
            return File(file, client.sContentType(sFileExtension));
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
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                HtmlConverter.ConvertToPdf(html, pdfDocument, properties);
                byte[] file = System.IO.File.ReadAllBytes(path);
                return File(file, "application/pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
