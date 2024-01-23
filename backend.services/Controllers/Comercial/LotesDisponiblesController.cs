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
    public class LotesDisponiblesController : ControllerBase
    {
        private readonly ILotesDisponiblesBL service;

        public LotesDisponiblesController(ILotesDisponiblesBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<LotesDisponiblesDTO>>>> getListLotesDisponibles(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<LotesDisponiblesDTO>> response = new ApiResponse<List<LotesDisponiblesDTO>>();

            try
            {
                var result = await service.getListLotesDisponibles(nIdCompania, nIdUsuario);

                response.success = true;
                response.data = (List<LotesDisponiblesDTO>)result;
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
