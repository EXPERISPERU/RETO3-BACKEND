using backend.businesslogic.Dealers;
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
    public class AgenteDealerController : ControllerBase
    {
        public readonly IAgenteDealerBL service;

        public AgenteDealerController(IAgenteDealerBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<AgenteDealerDTO>>>> getListAgenteDealer()
        {

            ApiResponse<List<AgenteDealerDTO>> response = new ApiResponse<List<AgenteDealerDTO>>();

            try
            {
                var result = await service.getListAgenteDealer();

                response.success = true;
                response.data = (List<AgenteDealerDTO>)result;
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
        public async Task<ActionResult<ApiResponse<AgenteDealerDTO>>> getAgenteDealerByID(int nIdAgenteDealer, int nIdCompania)
        {
            ApiResponse<AgenteDealerDTO> response = new ApiResponse<AgenteDealerDTO>();

            try
            {
                var result = await service.getAgenteDealerByID(nIdAgenteDealer, nIdCompania);

                response.success = (result == null ? false : true);
                response.data = (AgenteDealerDTO) result;
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
        public async Task<ActionResult<ApiResponse<AgenteDealerDTO>>> findAgenteDealer(string? sDNI, string? sCE)
        {
            ApiResponse<AgenteDealerDTO> response = new ApiResponse<AgenteDealerDTO>();

            try
            {
                var result = await service.findAgenteDealer(sDNI, sCE);

                response.success = (result == null ? false : true);
                response.data = (AgenteDealerDTO) result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListGeneros()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListGeneros();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListEstadoCivil()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListEstadoCivil();

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsAgenteDealer([FromBody] AgenteDealerDTO agenteDealer)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsAgenteDealer(agenteDealer);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdAgenteDealer([FromBody] AgenteDealerDTO agenteDealer)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdAgenteDealer(agenteDealer);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListPerfilDealer()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListPerfilDealer();

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
