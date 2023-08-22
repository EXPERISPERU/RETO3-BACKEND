using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OficinaController : ControllerBase
    {
        public readonly IOficinaBL service;

        public OficinaController(IOficinaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<OficinaDTO>>>> getListOficinaByCompania(int nIdCompania)
        {

            ApiResponse<List<OficinaDTO>> response = new ApiResponse<List<OficinaDTO>>();

            try
            {
                var result = await service.getListOficinaByCompania(nIdCompania);

                response.success = true;
                response.data = (List<OficinaDTO>)result;
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
