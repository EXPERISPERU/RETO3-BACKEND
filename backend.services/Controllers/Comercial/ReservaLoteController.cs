using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservaLoteController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IReservaLoteBL service;

        public ReservaLoteController(IConfiguration _configuration, IReservaLoteBL _service)
        {
            this.configuration = _configuration;
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectPrecioReservaByLote(int nIdLote, int nIdMonedaP)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectPrecioReservaByLote(nIdLote, nIdMonedaP);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsReserva([FromBody] InsReservaDTO insReserva)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsReserva(insReserva);

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
        public async Task<ActionResult> getFormatoReciboIngresoReserva(int nIdReservaLote) /* YA NO SE USA */
        {
            try
            {
                DataReservaDTO dataReserva = await service.getDataReserva(nIdReservaLote);
                byte[] file;

                if (dataReserva.nIdAdjunto == null)
                {
                    var sCuerpo = await service.formatoReciboIngresoReserva();

                    var html = "<style>.page-break { page-break-after: always; }</style>";

                    html += "<div class=\"page-break\">";
                    html += sCuerpo
                            .Replace("#iniItems#", "")
                            .Replace("#finItems#", "")
                            .Replace("#iniItem#", "")
                            .Replace("#finItem#", "")
                            .Replace("#sLogoData#", dataImages.psViviendasDelSur)
                            .Replace("#sCorrelativo#", dataReserva.sComprobante)
                            .Replace("#sNombreCliente#", dataReserva.sNombreCliente)
                            .Replace("#sDocumentoCliente#", dataReserva.sDocumento)
                            .Replace("#sDireccionCliente#", dataReserva.sDireccion)
                            .Replace("#sCelularCliente#", dataReserva.sCelular)
                            .Replace("#sFecha#", dataReserva.sFecha)
                            .Replace("#nroItem#", "1")
                            .Replace("#sProyecto#", dataReserva.sProyecto)
                            .Replace("#sSector#", dataReserva.sSector)
                            .Replace("#sManzana#", dataReserva.sManzana)
                            .Replace("#sLote#", dataReserva.sLote)
                            .Replace("#sArea#", dataReserva.nMetraje.ToString("N"))
                            .Replace("#sFechaFin#", dataReserva.sFechaFinReserva)
                            .Replace("#sNombrePromotor#", dataReserva.sNombrePromotor)
                            .Replace("#sTotalItem#", dataReserva.sTotal)
                            .Replace("#sSimbolo#", dataReserva.sSimbolo)
                            .Replace("#sTotal#", dataReserva.sTotal);
                    html += "</div>";

                    string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                    ConverterProperties properties = new ConverterProperties();
                    properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                    pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                    HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                    file = System.IO.File.ReadAllBytes(path);

                    string sRutaFile = string.Format("comprobantes/{0}.pdf", dataReserva.nIdComprobante);

                    ApiResponse<string> resFtp = new FtpClient(configuration).UploadFile(new imbFile { sRutaFile = sRutaFile, data = file });

                    if (resFtp.success)
                    {
                        await service.InsComprobanteAdjunto(dataReserva.nIdComprobante.GetValueOrDefault(), sRutaFile);
                    }

                }
                else
                {
                    file = new FtpClient(configuration).DownloadFile(dataReserva.sRutaFtp);
                }

                return File(file, "application/pdf");
            }
            catch (Exception)
            {
      
                throw;
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<DataReservaDTO>>> getDataReservaByLote(int nIdLote)
        {

            ApiResponse<DataReservaDTO> response = new ApiResponse<DataReservaDTO>();

            try
            {
                var result = await service.getDataReservaByLote(nIdLote);

                response.success = true;
                response.data = (DataReservaDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectMonedaByCompania(int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectMonedaByCompania(nIdCompania);

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
    }
}
