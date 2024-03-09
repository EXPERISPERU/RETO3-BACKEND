using backend.businesslogic.Interfaces.Cobranzas;
using backend.businesslogic.Interfaces.Contacto;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contacto
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioContactoController : ControllerBase
    {
        private readonly IFormularioContactoBL service;
        public FormularioContactoController(IFormularioContactoBL _service)
        {
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> InsFormularioContactoPortal([FromBody] FormularioContactoPortalDTO formulario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsFormularioContactoPortal(formulario);
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
