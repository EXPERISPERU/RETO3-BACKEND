using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElementoSistemaController : ControllerBase
    {
        public readonly IElementoSistemaBL service;

        public ElementoSistemaController(IElementoSistemaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getElementoSistemaByIdP(int nIdElementoP)
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.ListElementoByIdP(nIdElementoP);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<ElementoSistemaDTO>>> getElementoById(int nIdElemento)
        {

            ApiResponse<ElementoSistemaDTO> response = new ApiResponse<ElementoSistemaDTO>();

            try
            {
                var result = await service.ElementoById(nIdElemento);

                response.success = true;
                response.data = (ElementoSistemaDTO) result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsElementoSistema([FromBody] ElementoSistemaDTO elemento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsElementoSistema(elemento);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdElementoSistema([FromBody] ElementoSistemaDTO elemento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdElementoSistema(elemento);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getCompanias()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getCompanias();

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
    }
}
