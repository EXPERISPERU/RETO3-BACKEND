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
    public class ProveedorAgenteDealerController : ControllerBase
    {
        public readonly IProveedorAgenteDealerBL service;

        public ProveedorAgenteDealerController(IProveedorAgenteDealerBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ProveedorAgenteDealerDTO>>>> getListProveedorAgente(int nIdAgenteDealer)
        {

            ApiResponse<List<ProveedorAgenteDealerDTO>> response = new ApiResponse<List<ProveedorAgenteDealerDTO>>();

            try
            {
                var result = await service.getListProveedorAgente(nIdAgenteDealer);

                response.success = true;
                response.data = (List<ProveedorAgenteDealerDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getProveedoresDealer()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getProveedoresDealer();

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
        public async Task<ActionResult<ApiResponse<int>>> getCantActivePADByAgente(int nIdAgenteDealer)
        {

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.CantActivePADByAgente(nIdAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsProvAgenDealer([FromBody] ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsProvAgenDealer(proveedorAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdProvAgenDealer([FromBody] ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdProvAgenDealer(proveedorAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getJefesDealer(int nIdProveedor, int nIdAgenteDealer)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getJefesDealer(nIdProveedor, nIdAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> InsJefeDealer([FromBody] JefeAgenteDealerDTO jefeAgenteDealer)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsJefeDealer(jefeAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<List<JefeAgenteDealerDTO>>>> getJefesDealerByAgenteDealer(int nIdAgenteDealer)
        {

            ApiResponse<List<JefeAgenteDealerDTO>> response = new ApiResponse<List<JefeAgenteDealerDTO>>();
            try
            {
                var result = await service.getJefesDealerByAgenteDealer(nIdAgenteDealer);

                response.success = true;
                response.data = (List<JefeAgenteDealerDTO>)result;
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
