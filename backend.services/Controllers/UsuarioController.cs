using backend.businesslogic.Interfaces;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioBL service;

        public UsuarioController(IUsuarioBL _service)
        { 
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<PerfilDTO>>>> GetPerfilAll()
        {
            ApiResponse<List<PerfilDTO>> response = new ApiResponse<List<PerfilDTO>>();

            try
            {
                var result = await service.GetPerfilAll();

                response.success = true;
                response.data = (List<PerfilDTO>)result;
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
