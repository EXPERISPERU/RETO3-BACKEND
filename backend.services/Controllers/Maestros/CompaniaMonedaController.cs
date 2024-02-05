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
    public class CompaniaMonedaController : ControllerBase
    {
        public readonly ICompaniaMonedaBL service;

        public CompaniaMonedaController(ICompaniaMonedaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<CompaniaMonedaDTO>>>> getListMonedaByCompania(int nIdCompania)
        {

            ApiResponse<List<CompaniaMonedaDTO>> response = new ApiResponse<List<CompaniaMonedaDTO>>();

            try
            {
                var result = await service.getListMonedaByCompania(nIdCompania);

                response.success = true;
                response.data = (List<CompaniaMonedaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<MonedaDTO>>>> getListMonedaDispByCompania(int nIdCompania)
        {

            ApiResponse<List<MonedaDTO>> response = new ApiResponse<List<MonedaDTO>>();

            try
            {
                var result = await service.getListMonedaDispByCompania(nIdCompania);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCompaniaMoneda([FromBody] CompaniaMonedaDTO companiaMoneda)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCompaniaMoneda(companiaMoneda);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postDesActMoneda([FromBody] CompaniaMonedaDTO companiaMoneda)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.DesActMoneda(companiaMoneda);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdMonedaPrincipal([FromBody] CompaniaMonedaDTO companiaMoneda)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdMonedaPrincipal(companiaMoneda);

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
