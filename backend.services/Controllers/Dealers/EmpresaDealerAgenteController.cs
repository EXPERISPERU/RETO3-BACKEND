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
    public class EmpresaDealerAgenteController : ControllerBase
    {
        public readonly IEmpresaDealerAgenteBL service;

        public EmpresaDealerAgenteController(IEmpresaDealerAgenteBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<EmpresaDealerAgenteDTO>>>> getListEmpresaDealerAgente(int nIdAgenteDealer)
        {

            ApiResponse<List<EmpresaDealerAgenteDTO>> response = new ApiResponse<List<EmpresaDealerAgenteDTO>>();

            try
            {
                var result = await service.getListEmpresaDealerAgente(nIdAgenteDealer);

                response.success = true;
                response.data = (List<EmpresaDealerAgenteDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getEmpresasDealer()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getEmpresasDealer();

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
        public async Task<ActionResult<ApiResponse<int>>> getCantActiveEDAByAgente(int nIdAgenteDealer)
        {

            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.CantActiveEDAByAgente(nIdAgenteDealer);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsEmpDeaAgente([FromBody] EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsEmpDeaAgente(empresaDealerAgente);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdEmpDeaAgente([FromBody] EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdEmpDeaAgente(empresaDealerAgente);

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
