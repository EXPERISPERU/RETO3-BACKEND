using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionBL service;

        public ConfiguracionController(IConfiguracionBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ConfiguracionDTO>>>> getConfiguracionByIdProyecto(int nIdproyecto)
        {

            ApiResponse<List<ConfiguracionDTO>> response = new ApiResponse<List<ConfiguracionDTO>>();

            try
            {
                var result = await service.getConfiguracionByIdProyecto(nIdproyecto);

                response.success = true;
                response.data = (List<ConfiguracionDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }



        //FUNCION AGREGAR CONFIGURACION


        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListInteres()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListInteres();

                response.success = true;
                response.data = (List<ElementoSistemaDTO>)result;
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
