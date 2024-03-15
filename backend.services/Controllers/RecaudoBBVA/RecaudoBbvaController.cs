using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.RecaudoBBVA
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudoBbvaController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<string>>> postConsulta()
        {
            ApiResponse<string> response = new ApiResponse<string>();

            try
            {
                var result = "";

                response.success = true;
                response.data = (string) result;
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
        public async Task<ActionResult<ApiResponse<string>>> postPago()
        {
            ApiResponse<string> response = new ApiResponse<string>();

            try
            {
                var result = "";

                response.success = true;
                response.data = (string)result;
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
        public async Task<ActionResult<ApiResponse<string>>> postExtorno()
        {
            ApiResponse<string> response = new ApiResponse<string>();

            try
            {
                var result = "";

                response.success = true;
                response.data = (string)result;
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
