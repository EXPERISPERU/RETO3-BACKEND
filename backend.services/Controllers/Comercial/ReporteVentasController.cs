using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReporteVentasController : ControllerBase
    {
        private readonly IReporteVentasBL service;

        public ReporteVentasController(IReporteVentasBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ReporteVentasDTO>>>> getListReporteVentas()
        {
            ApiResponse<List<ReporteVentasDTO>> response = new ApiResponse<List<ReporteVentasDTO>>();

            try
            {
                var result = await service.getListReporteVentas();

                response.success = true;
                response.data = (List<ReporteVentasDTO>)result;
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
