using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial.ParametrosVentaLote
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VigenciaServicioController : Controller
    {
        private readonly IVigenciaServicioBL service;

        public VigenciaServicioController(IVigenciaServicioBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<VigenciaServicioDTO>>> getListVigenciaServicioById(int nIdVigenciaServicio)
        {
            ApiResponse<VigenciaServicioDTO> response = new ApiResponse<VigenciaServicioDTO>();

            try
            {
                var result = await service.getListVigenciaServicioById(nIdVigenciaServicio);

                response.success = true;
                response.data = (VigenciaServicioDTO)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> InsUpdVigenciaServicio([FromBody] VigenciaServicioDTO vigenciaServicio)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsUpdVigenciaServicio(vigenciaServicio);

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

    }
}
