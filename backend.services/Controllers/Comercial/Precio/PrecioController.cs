using backend.domain;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.businesslogic.Interfaces.Comercial.Precio;

namespace backend.services.Controllers.Comercial.Precio
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {
        private readonly IPrecioBL service;

        public PrecioController(IPrecioBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<PrecioDTO>>>> getListPrecio()
        {
            ApiResponse<List<PrecioDTO>> response = new ApiResponse<List<PrecioDTO>>();

            try
            {
                var result = await service.getListPrecio();

                response.success = true;
                response.data = (List<PrecioDTO>)result;
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
