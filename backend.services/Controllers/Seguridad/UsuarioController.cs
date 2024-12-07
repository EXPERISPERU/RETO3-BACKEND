using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace backend.services.Controllers.Seguridad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioBL service;

        public UsuarioController(IUsuarioBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<UsuarioDTO>>>> getAllUsuario()
        {
            ApiResponse<List<UsuarioDTO>> response = new ApiResponse<List<UsuarioDTO>>();

            try
            {
                var result = await service.getAllUsuario();

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getTipoUsuario()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getTipoUsuario();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getPersonaByTipoUsuario(int nIdTipoUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getPersonaByTipoUsuario(nIdTipoUsuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsUsuario([FromBody] UsuarioDTO usuario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsUsuario(usuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdUsuario([FromBody] UsuarioDTO usuario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdUsuario(usuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdUsuarioPortal([FromBody] UsuarioDTO usuario)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdUsuarioPortal(usuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsUsuPerCom([FromBody] PerfilUsuarioDTO perusu)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsUsuPerCom(perusu);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postDelUsuPerCom([FromBody] PerfilUsuarioDTO perusu)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.DelUsuPerCom
                    (perusu);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getPerfilDispByUsuComp(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getPerfilDispByUsuComp(nIdUsuario, nIdCompania);

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
        public async Task<ActionResult<ApiResponse<List<PerfilUsuarioDTO>>>> getPerfilByUsu(int nIdUsuario)
        {
            ApiResponse<List<PerfilUsuarioDTO>> response = new ApiResponse<List<PerfilUsuarioDTO>>();

            try
            {
                var result = await service.getPerfilByUsu(nIdUsuario);

                response.success = true;
                response.data = (List<PerfilUsuarioDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<OpcionDTO>>>> getOpcionByUsuComp(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<OpcionDTO>> response = new ApiResponse<List<OpcionDTO>>();

            try
            {
                var result = await service.getOpcionByUsuComp(nIdUsuario, nIdCompania);

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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<UsuarioDTO>>> getUserById( int nIdUsuario )
        {
            ApiResponse<UsuarioDTO> response = new ApiResponse<UsuarioDTO>();

            try
            {
                var result = await service.getUserById(nIdUsuario);

                response.success = true;
                response.data = (UsuarioDTO)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<string>>> generateUsuariosNuevosClientes()
        {
            ApiResponse<string> response = new ApiResponse<string>();

            try
            {
                await service.generateUsuariosNuevosClientes();
                response.success = true;
                response.data = "OK";
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
