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
        public async Task<ActionResult> getCotizacionFormato(int nIdReservaLote)
        {
            try
            {
                ReciboIngresoReservaDTO cotizacion = await service.getReciboIngresoReserva(nIdReservaLote);
                var sCuerpo = await service.formatoReciboIngresoReserva();

                var html = "<style>.page-break { page-break-after: always; }</style>";

                html += "<div class=\"page-break\">";
                //html += sCuerpo
                //        .Replace("#sLogoData#", dataLogoCompania.psViviendasDelSur)
                //        .Replace("#sCorrelativo#", cotizacion.sCorrelativo)
                //        .Replace("#sFecha#", cotizacion.sFecha_crea.Substring(0, 10))
                //        .Replace("#sNombreCliente#", cotizacion.sNombreCliente)
                //        .Replace("#sDocumentoCliente#", cotizacion.sDocumentoCliente)
                //        .Replace("#sProyecto#", cotizacion.sProyecto)
                //        .Replace("#sSector#", cotizacion.sSector)
                //        .Replace("#sManzana#", cotizacion.sManzana)
                //        .Replace("#sLote#", cotizacion.sLote)
                //        .Replace("#nMetraje#", cotizacion.nMetraje.ToString("N"))
                //        .Replace("#sTerreno#", cotizacion.sTerreno)
                //        .Replace("#sZonificacion#", cotizacion.sZonificacion)
                //        .Replace("#sUbicacion#", cotizacion.sUbicacion)
                //        .Replace("#sDescripcion#", cotizacion.sDescripcion)
                //        .Replace("#sEstado#", cotizacion.sEstado)
                //        .Replace("#sSimbolo#", cotizacion.sSimbolo)
                //        .Replace("#nPrecioVenta#", cotizacion.nPrecioVenta?.ToString("N"))
                //        .Replace("#sValorInicial#", cotizacion.sValorInicial)
                //        .Replace("#nInicial#", cotizacion.nInicial?.ToString("N"))
                //        .Replace("#sValorDescuentoFin#", cotizacion.sValorDescuentoFin)
                //        .Replace("#nDescuentoFin#", cotizacion.nDescuentoFin?.ToString("N"))
                //        .Replace("#sValorDescuentoCon#", cotizacion.sValorDescuentoCon)
                //        .Replace("#nDescuentoCon#", cotizacion.nDescuentoCon?.ToString("N"))
                //        .Replace("#nValorFinanciado#", cotizacion.nValorFinanciado?.ToString("N"))
                //        .Replace("#nCuotas#", cotizacion.nCuotas?.ToString("N"))
                //        .Replace("#nValorCuota#", cotizacion.nValorCuota?.ToString("N"))
                //        .Replace("#nValorContado#", cotizacion.nValorContado?.ToString("N"))
                //        .Replace("#sUsuario_crea#", cotizacion.sUsuario_crea)
                //        .Replace("#sFecha_crea#", cotizacion.sFecha_crea);
                //html += "</div>";

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
