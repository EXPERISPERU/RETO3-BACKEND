using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Seguridad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OpcionController : ControllerBase
    {
        public readonly IOpcionBL service;

        public OpcionController(IOpcionBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<OpcionDTO>>>> getListOpcion()
        {

            ApiResponse<List<OpcionDTO>> response = new ApiResponse<List<OpcionDTO>>();

            try
            {
                var result = await service.ListOpcion();

                response.success = true;
                response.data = (List<OpcionDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsOpcionPerfil([FromBody] PerfilOpcionDTO perfilOpcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsOpcionPerfil(perfilOpcion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postDelOpcionPerfil([FromBody] PerfilOpcionDTO perfilOpcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.DelOpcionPerfil(perfilOpcion);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListTipoOpcionByIdOpcionP(int nIdOpcion)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.ListTipoOpcionByIdOpcionP(nIdOpcion);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<int>>> getCantOpcionHijo(int nIdOpcion)
        {

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.CantOpcionHijo(nIdOpcion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsOpcion([FromBody] OpcionDTO opcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsOpcion(opcion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdOpcion([FromBody] OpcionDTO opcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdOpcion(opcion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsOpcionUsuario([FromBody] UsuarioOpcionDTO usuarioOpcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsOpcionUsuario(usuarioOpcion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postDelOpcionUsuario([FromBody] UsuarioOpcionDTO usuarioOpcion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.DelOpcionUsuario(usuarioOpcion);

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
        public async Task<ActionResult<ApiResponse<List<OpcionDTO>>>> getAccionesByUsuarioCompania(int nIdCompania, int nIdUsuario)
        {

            ApiResponse<List<OpcionByPerfilDTO>> response = new ApiResponse<List<OpcionByPerfilDTO>>();

            try
            {
                var result = await service.getAccionesByUsuarioCompania(nIdCompania, nIdUsuario);

                response.success = true;
                response.data = (List<OpcionByPerfilDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<PermisosDashboardDTO>>>> getPermisosDashboardByUsuarioCompania(int nIdCompania, int nIdUsuario)
        {

            ApiResponse<List<PermisosDashboardDTO>> response = new ApiResponse<List<PermisosDashboardDTO>>();

            try
            {
                var result = await service.getPermisosDashboardByUsuarioCompania(nIdCompania, nIdUsuario);

                response.success = true;
                response.data = (List<PermisosDashboardDTO>)result;
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
