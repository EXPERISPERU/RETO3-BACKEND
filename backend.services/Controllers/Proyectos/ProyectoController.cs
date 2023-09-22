using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Proyectos;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Proyectos
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProyectoController : ControllerBase
    {
        public readonly IProyectoBL service;

        public ProyectoController(IProyectoBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ProyectoDTO>>>> getListProyectoByCompania(int nIdCompania)
        {
            ApiResponse<List<ProyectoDTO>> response = new ApiResponse<List<ProyectoDTO>>();

            try
            {
                var result = await service.getListProyectoByCompania(nIdCompania);

                response.success = true;
                response.data = (List<ProyectoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<ProyectoDTO>>> getProyectoByID(int nIdProyecto)
        {
            ApiResponse<ProyectoDTO> response = new ApiResponse<ProyectoDTO>();

            try
            {
                var result = await service.getProyectoByID(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectCompanias()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectCompanias();

                response.success = true;
                response.data = (List<SelectDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsProyecto([FromBody] ProyectoDTO proyecto)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsProyecto(proyecto);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdProyecto([FromBody] ProyectoDTO proyecto)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdProyecto(proyecto);

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
