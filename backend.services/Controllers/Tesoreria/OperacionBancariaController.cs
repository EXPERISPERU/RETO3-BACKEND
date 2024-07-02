using backend.businesslogic.Interfaces.Seguridad;
using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Tesoreria
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperacionBancariaController : ControllerBase
    {
        public readonly IOperacionBancariaBL service;

        public OperacionBancariaController(IOperacionBancariaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<OperacionBancariaDTO>>>> getAllOperacionBancaria(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<OperacionBancariaDTO>> response = new ApiResponse<List<OperacionBancariaDTO>>();

            try
            {
                var result = await service.getAllOperacionBancaria(nIdCompania, nIdUsuario);

                response.success = true;
                response.data = (List<OperacionBancariaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getAllProyectosByCompania(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getAllProyectosByCompania(nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<CuentaDTO>>>> getAllCuentasByProyecto(int nIdCompania, int nIdUsuario, int nIdProyecto, int? nIdMoneda)
        {
            ApiResponse<List<CuentaDTO>> response = new ApiResponse<List<CuentaDTO>>();

            try
            {
                var result = await service.getAllCuentasByProyecto(nIdCompania, nIdUsuario, nIdProyecto, nIdMoneda);

                response.success = true;
                response.data = (List<CuentaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsOperacionBancaria([FromBody] OperacionBancariaDTO operacionBancaria, int nIdCompania)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsOperacionBancaria(nIdCompania, operacionBancaria);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdOperacionBancaria([FromBody] OperacionBancariaDTO operacionBancaria, int nIdCompania)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdOperacionBancaria(nIdCompania, operacionBancaria);

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
        public async Task<ActionResult<ApiResponse<OperacionBancariaDTO>>> getOperacionBancariaByCuentaMovimiento(int nIdCompania, int nIdUsuario, int nIdCuenta, int nMovimiento)
        {
            ApiResponse<OperacionBancariaDTO> response = new ApiResponse<OperacionBancariaDTO>();

            try
            {
                var result = await service.getOperacionBancariaByCuentaMovimiento(nIdCompania, nIdUsuario, nIdCuenta, nMovimiento);

                response.success = true;
                response.data = (OperacionBancariaDTO)result;
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
