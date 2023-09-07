using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Dealers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReferidoController : ControllerBase
    {
        public readonly IReferidoBL service;

        public ReferidoController(IReferidoBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ReferidoDTO>>>> getListReferido()
        {
            ApiResponse<List<ReferidoDTO>> response = new ApiResponse<List<ReferidoDTO>>();

            try
            {
                var result = await service.getListReferido();

                response.success = true;
                response.data = (List<ReferidoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ReferidoDTO>>>> getListReferidoByCliente(int nIdCliente)
        {
            ApiResponse<List<ReferidoDTO>> response = new ApiResponse<List<ReferidoDTO>>();

            try
            {
                var result = await service.getListReferidoByCliente(nIdCliente);

                response.success = true;
                response.data = (List<ReferidoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<int>>> getIdAgenteDealer(int nIdUsuario)
        {
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.getIdAgenteDealer(nIdUsuario);

                response.success = true;
                response.data = (int)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsReferido([FromBody] ReferidoDTO referido)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsReferido(referido);

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
