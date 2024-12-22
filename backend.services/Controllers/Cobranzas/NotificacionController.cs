using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Cobranzas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacionBL service;

        public NotificacionController(INotificacionBL _service)
        {
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<NotificacionDTO>>>> getListNotificacion([FromBody] NotificacionFilterDTO filtroNotificacion)
        {
            ApiResponse<List<NotificacionDTO>> response = new ApiResponse<List<NotificacionDTO>>();

            try
            {
                var result = await service.getListNotificacion(filtroNotificacion);

                response.success = true;
                response.data = (List<NotificacionDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> posInsNotificacion([FromBody] NotificacionDataDTO notificacionData)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.posInsNotificacion(notificacionData);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> posEnviarNotificacion(int nIdNotificacion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.posEnviarNotificacion(nIdNotificacion);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<PlantillaNotificacionDTO>>>> getListPlantillaNotificacion()
        {
            ApiResponse<List<PlantillaNotificacionDTO>> response = new ApiResponse<List<PlantillaNotificacionDTO>>();

            try
            {
                var result = await service.getListPlantillaNotificacion();

                Console.WriteLine(result);

                response.success = true;
                response.data = (List<PlantillaNotificacionDTO>)result;
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
