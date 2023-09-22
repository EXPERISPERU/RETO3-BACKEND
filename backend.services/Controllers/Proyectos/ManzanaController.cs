using backend.businesslogic.Interfaces.Proyectos;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Proyectos
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManzanaController : ControllerBase
    {
        public readonly IManzanaBL service;

        public ManzanaController(IManzanaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ManzanaDTO>>>> getListManzanaBySector(int nIdSector)
        {
            ApiResponse<List<ManzanaDTO>> response = new ApiResponse<List<ManzanaDTO>>();

            try
            {
                var result = await service.getListManzanaBySector(nIdSector);

                response.success = true;
                response.data = (List<ManzanaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsManzana([FromBody] ManzanaDTO manzana)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsManzana(manzana);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdManzana([FromBody] ManzanaDTO manzana)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdManzana(manzana);

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
