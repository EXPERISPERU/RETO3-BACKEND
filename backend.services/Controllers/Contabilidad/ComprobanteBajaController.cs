using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprobanteBajaController : ControllerBase
    {

        private readonly IConfiguration configuration;
        private readonly IComprobanteBajaBL service;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ComprobanteBajaController(IConfiguration _configuration, IComprobanteBajaBL _service, IWebHostEnvironment _hostingEnvironment)
        {
            this.configuration = _configuration;
            this.service = _service;
            this.hostingEnvironment = _hostingEnvironment;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteDTO>>>> getComprobanteById(int nIdComprobante)
        {
            ApiResponse<List<ComprobanteDTO>> response = new ApiResponse<List<ComprobanteDTO>>();

            try
            {
                var result = await service.getComprobanteById(nIdComprobante);

                response.success = true;
                response.data = (List<ComprobanteDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoMotivos()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoMotivos();

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsComprobanteCaja([FromBody] ComprobanteBajaDTO comprobanteBaja)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsComprobanteCaja(comprobanteBaja);

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
        public async Task<ActionResult<ApiResponse<List<LoginDTO>>>> getAuthUserSuperAnulaCompro(string sUsuario, string sContrasena)
        {
            ApiResponse<List<LoginDTO>> response = new ApiResponse<List<LoginDTO>>();

            try
            {
                var result = await service.AuthUserSuperAnulaCompro(sUsuario, sContrasena);

                response.success = true;
                response.data = (List<LoginDTO>)result;
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
