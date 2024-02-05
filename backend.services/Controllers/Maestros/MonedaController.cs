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
    public class MonedaController : ControllerBase
    {
        public readonly IMonedaBL service;

        public MonedaController(IMonedaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<MonedaDTO>>>> getListMoneda()
        {

            ApiResponse<List<MonedaDTO>> response = new ApiResponse<List<MonedaDTO>>();

            try
            {
                var result = await service.getListMoneda();

                response.success = true;
                response.data = (List<MonedaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<MonedaDTO>>> getMonedaByID(int nIdMoneda)
        {
            ApiResponse<MonedaDTO> response = new ApiResponse<MonedaDTO>();

            try
            {
                var result = await service.getMonedaByID(nIdMoneda);

                response.success = true;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMoneda([FromBody] MonedaDTO moneda)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMoneda(moneda);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdMoneda([FromBody] MonedaDTO moneda)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdMoneda(moneda);

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
