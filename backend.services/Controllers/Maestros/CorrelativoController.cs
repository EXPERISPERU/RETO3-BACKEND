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
    public class CorrelativoController : ControllerBase
    {
        public readonly ICorrelativoBL service;

        public CorrelativoController(ICorrelativoBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<CorrelativoDTO>>>> getListCorrelativoBySerie(int nIdSerie)
        {
            ApiResponse<List<CorrelativoDTO>> response = new ApiResponse<List<CorrelativoDTO>>();

            try
            {
                var result = await service.getListCorrelativoBySerie(nIdSerie);

                response.success = true;
                response.data = (List<CorrelativoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<int>>> getCantActiveCorrelativoBySerie(int nIdSerie)
        {
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.getCantActiveCorrelativoBySerie(nIdSerie);

                response.success = (int)result == 1;
                response.data = (int)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCorrelativo([FromBody] CorrelativoDTO correlativo)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCorrelativo(correlativo);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdCorrelativo([FromBody] CorrelativoDTO correlativo)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdCorrelativo(correlativo);

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
