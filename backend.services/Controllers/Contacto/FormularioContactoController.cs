using backend.businesslogic.Interfaces.Cobranzas;
using backend.businesslogic.Interfaces.Contacto;
using backend.domain;
using backend.services.Utils;
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
                string formato = await service.getFormatoContactoById(18);

                var formatoParse = new FormatosContacto().EmailGetFormatoPortalSauces(formulario, formato);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;

                if (response.success)
                {
                    new EmailSender().SendEmailGmail("contacto@psviviendasdelsur.pe", "Formulario Contacto", formulario, formatoParse); // contacto@psviviendasdelsur.pe
                } 
                return StatusCode(200, formatoParse);
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
