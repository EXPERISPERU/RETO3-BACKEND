using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.businesslogic.Comercial;
using backend.services.Utils;
using System.Globalization;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacionBL service;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CotizacionController(ICotizacionBL _service, IWebHostEnvironment hostingEnvironment)
        {
            this.service = _service;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectCuotaLote(int nIdLote, int? nIdInicialLote, int? nIdDescuentoLote)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectCuotaLote(nIdLote, nIdInicialLote, nIdDescuentoLote);

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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListInicialLote(int nIdLote, int? nIdInicialLote, int? nIdDescuentoLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListInicialLote(nIdLote, nIdInicialLote, nIdDescuentoLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoContLote(int nIdLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoContLote(nIdLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoFinLote(int nIdLote, int? nIdInicialLote, int? nIdCuotaLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoFinLote(nIdLote, nIdInicialLote, nIdCuotaLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<CotizacionDTO>>> postCalculateCotizacion([FromBody] CotizacionDTO cotizacion)
        {
            ApiResponse<CotizacionDTO> response = new ApiResponse<CotizacionDTO>();

            try
            {
                var result = await service.calculateCotizacion(cotizacion);

                response.success = true;
                response.data = (CotizacionDTO) result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCotizacion([FromBody] CotizacionDTO cotizacion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCotizacion(cotizacion);

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
        public async Task<ActionResult> getCotizacionFormato(int nIdCotizacion)
        {
            try
            {
                CultureInfo ci_PE = new CultureInfo("es-PE");
                CotizacionDTO cotizacion = await service.getCotizacionById(nIdCotizacion);
                var sCuerpo = await service.formatoCotizacion(nIdCotizacion);
                var sLogo = "";

                if (cotizacion.nCodigoProyecto == 4)
                {
                    sLogo = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_villa_azul.png"));
                }
                else if (cotizacion.nCodigoProyecto == 7)
                {
                    sLogo = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_leon_beach.png"));
                }
                else if (cotizacion.nCodigoProyecto == 1 || cotizacion.nCodigoProyecto == 2 || cotizacion.nCodigoProyecto == 3)
                {
                    sLogo = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_psvds.png"));
                }
                else
                {
                    sLogo = new ImagesData().GetImage(System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "Images", "logo_inmobitec.png"));
                }

                var html = "<style>.page-break { page-break-after: always; }</style>";

                html += "<div class=\"page-break\">";
                html += sCuerpo
                        .Replace("#sLogoData#", sLogo)
                        .Replace("#sCorrelativo#", cotizacion.sCorrelativo)
                        .Replace("#sFecha#", cotizacion.sFecha_crea.Substring(0,10))
                        .Replace("#sNombreCliente#", cotizacion.sNombreCliente)
                        .Replace("#sDocumentoCliente#", cotizacion.sDocumentoCliente)
                        .Replace("#sProyecto#", cotizacion.sProyecto)
                        .Replace("#sSector#", cotizacion.sSector)
                        .Replace("#sManzana#", cotizacion.sManzana)
                        .Replace("#sLote#", cotizacion.sLote)
                        .Replace("#nMetraje#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nMetraje))
                        .Replace("#sTerreno#", cotizacion.sTerreno)
                        .Replace("#sZonificacion#", cotizacion.sZonificacion)
                        .Replace("#sUbicacion#", cotizacion.sUbicacion)
                        .Replace("#sDescripcion#", cotizacion.sDescripcion)
                        .Replace("#sEstado#", cotizacion.sEstado)
                        .Replace("#sSimbolo#", cotizacion.sSimbolo)
                        .Replace("#nPrecioVenta#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nPrecioVenta))
                        .Replace("#sValorInicial#", cotizacion.sSimboloIni + " " + string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorOriIni))
                        .Replace("#nInicial#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nInicial))
                        .Replace("#sValorDescuentoFin#", cotizacion.sSimboloDescuentoFin + " " + string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorOriDescuentoFin))
                        .Replace("#nDescuentoFin#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nDescuentoFin))
                        .Replace("#sValorDescuentoCon#", cotizacion.sSimboloDescuentoCon + " " + string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorOriDescuentoCon))
                        .Replace("#nDescuentoCon#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nDescuentoCon))
                        .Replace("#nValorFinanciado#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorFinanciado))
                        .Replace("#nCuotas#", string.Format(ci_PE, "{0:0}", cotizacion.nCuotas))
                        .Replace("#nValorCuota#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorCuota))
                        .Replace("#sInteresFijo#", cotizacion.sInteresCuota)
                        .Replace("#nValorContado#", string.Format(ci_PE, "{0:0,0.00}", cotizacion.nValorContado))
                        .Replace("#sUsuario_crea#", cotizacion.sUsuario_crea)
                        .Replace("#sFecha_crea#", cotizacion.sFecha_crea);
                html += "</div>";

                if (cotizacion.sInteresCuota != "")
                {
                    html = html
                        .Replace("#iniInteresFijo#", "")
                        .Replace("#finInteresFijo#", "");
                }
                else
                {
                    while (html.Contains("#iniInteresFijo#"))
                    {
                        string sIniInteresFijo = "#iniInteresFijo#";
                        string sFinInteresFijo = "#finInteresFijo#";
                        string sInteresFijo = html.Substring(html.IndexOf(sIniInteresFijo), (html.IndexOf(sFinInteresFijo) + sFinInteresFijo.Length) - html.IndexOf(sIniInteresFijo));
                        html = html.Replace(sInteresFijo, "");
                    }
                }


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
        public async Task<ActionResult<ApiResponse<ClienteDTO>>> getClienteReservaByLote(int nIdLote)
        {
            ApiResponse<ClienteDTO> response = new ApiResponse<ClienteDTO>();

            try
            {
                var result = await service.getClienteReservaByLote(nIdLote);

                response.success = true;
                response.data = (ClienteDTO)result;
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
        public async Task<ActionResult<ApiResponse<ClienteDTO>>> getClientePreContratoByLote(int nIdLote)
        {
            ApiResponse<ClienteDTO> response = new ApiResponse<ClienteDTO>();

            try
            {
                var result = await service.getClientePreContratoByLote(nIdLote);

                response.success = true;
                response.data = (ClienteDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<ReporteCotizacionesDTO>>>> getListReporteCotizaciones([FromBody] ReporteCotizacionesFiltrosDTO filtros)
        {
            ApiResponse<List<ReporteCotizacionesDTO>> response = new ApiResponse<List<ReporteCotizacionesDTO>>();

            try
            {
                var result = await service.getListReporteCotizaciones(filtros);

                response.success = true;
                response.data = (List<ReporteCotizacionesDTO>)result;
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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SqlRspDTO>>>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato)
        {
            ApiResponse<List<SqlRspDTO>> response = new ApiResponse<List<SqlRspDTO>>();

            try
            {
                var result = await service.getSelectValidaCuotaInteres(nIdProyecto, nIdCuota, nIdContrato);

                response.success = true;
                response.data = (List<SqlRspDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectInteresDTO>>>> getListInteresLote(int nIdLote, int? nIdInicial, int? nIdDescuento, int? nIdCuotaLote)
        {
            ApiResponse<List<SelectInteresDTO>> response = new ApiResponse<List<SelectInteresDTO>>();

            try
            {
                var result = await service.getListInteresLote(nIdLote, nIdInicial, nIdDescuento, nIdCuotaLote);

                response.success = true;
                response.data = (List<SelectInteresDTO>)result;
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
        public async Task<ActionResult<ApiResponse<TipoCambioDTO>>> getTipoCambio([FromBody] int nIdLote, int nIdMonedaOri, int? nIdMonedaDest)
        {
            ApiResponse<TipoCambioDTO> response = new ApiResponse<TipoCambioDTO>();

            try
            {
                var result = await service.getTipoCambio(nIdLote, nIdMonedaOri, nIdMonedaDest);

                response.success = true;
                response.data = (TipoCambioDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<CotizacionChartDTO>>>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter)
        {
            ApiResponse<List<CotizacionChartDTO>> response = new ApiResponse<List<CotizacionChartDTO>>();

            try
            {
                var result = await service.postListCotizacionChart(cotizacionChartFilter);

                response.success = true;
                response.data = (List<CotizacionChartDTO>)result;
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