using backend.businesslogic.Interfaces;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioBL service;

        public UsuarioController(IUsuarioBL _service)
        { 
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<UsuarioDTO>>>> GetUsersAll()
        {
            ApiResponse<List<UsuarioDTO>> response = new ApiResponse<List<UsuarioDTO>>();

            try
            {
                var result = await service.GetUsersAll();

                response.success = true;
                response.data = (List<UsuarioDTO>)result;
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
