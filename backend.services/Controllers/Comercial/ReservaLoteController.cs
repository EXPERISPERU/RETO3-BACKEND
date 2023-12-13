using backend.businesslogic.Comercial;
using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaLoteController : ControllerBase
    {
        private readonly IReservaLoteBL service;

        public ReservaLoteController(IReservaLoteBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectPrecioReservaByLote(int nIdLote)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectPrecioReservaByLote(nIdLote);

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
        public async Task<ActionResult> getFormatoReciboIngresoReserva(int nIdReservaLote)
        {
            try
            {
                DataReservaDTO reciboIngresoReserva = await service.getDataReserva(nIdReservaLote);
                var sCuerpo = await service.formatoReciboIngresoReserva();

                var html = "<style>.page-break { page-break-after: always; }</style>";

                html += "<div class=\"page-break\">";
                html += sCuerpo
                        .Replace("#sLogoData#", dataLogoCompania.psViviendasDelSur)
                        .Replace("#sCorrelativo#", reciboIngresoReserva.sCorrelativo)
                        .Replace("#sNombreCliente#", reciboIngresoReserva.sNombreCliente)
                        .Replace("#sDocumentoCliente#", reciboIngresoReserva.sDocumento)
                        .Replace("#sDireccionCliente#", reciboIngresoReserva.sDireccion)
                        .Replace("#sCelularCliente#", reciboIngresoReserva.sCelular)
                        .Replace("#sFecha#", reciboIngresoReserva.sFecha)
                        .Replace("#sProyecto#", reciboIngresoReserva.sProyecto)
                        .Replace("#sSector#", reciboIngresoReserva.sSector)
                        .Replace("#sManzana#", reciboIngresoReserva.sManzana)
                        .Replace("#sLote#", reciboIngresoReserva.sLote)
                        .Replace("#sArea#", reciboIngresoReserva.nMetraje.ToString("N"))
                        .Replace("#sFechaFin#", reciboIngresoReserva.sFechaFinReserva)
                        .Replace("#sNombrePromotor#", reciboIngresoReserva.sNombrePromotor)
                        .Replace("#sSimbolo#", reciboIngresoReserva.sSimbolo)
                        .Replace("#sTotal#", reciboIngresoReserva.sTotal);
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
    }
}
