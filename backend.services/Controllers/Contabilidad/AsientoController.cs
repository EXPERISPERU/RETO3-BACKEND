using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoBL service;

        public AsientoController(IAsientoBL _service)
        {
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<AsientoCajaDTO>>>> getAsientoCaja(AsientoFilterDTO filter)
        {
            ApiResponse<List<AsientoCajaDTO>> response = new ApiResponse<List<AsientoCajaDTO>>();

            try
            {
                var result = await service.getAsientoCaja(filter);

                Console.WriteLine(result);

                response.success = true;
                response.data = (List<AsientoCajaDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }

        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<AsientoBancoDTO>>>> getAsientoBancos(AsientoFilterDTO filter)
        {
            ApiResponse<List<AsientoBancoDTO>> response = new ApiResponse<List<AsientoBancoDTO>>();

            try
            {
                var result = await service.getAsientoBancos(filter);

                Console.WriteLine(result);

                response.success = true;
                response.data = (List<AsientoBancoDTO>)result;
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
