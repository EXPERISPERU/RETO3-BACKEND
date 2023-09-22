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
    public class EmpresaDealerController : ControllerBase
    {
        public readonly IEmpresaDealerBL service;

        public EmpresaDealerController(IEmpresaDealerBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<EmpresaDealerDTO>>>> getListEmpresaDealer()
        {

            ApiResponse<List<EmpresaDealerDTO>> response = new ApiResponse<List<EmpresaDealerDTO>>();

            try
            {
                var result = await service.getListEmpresaDealer();

                response.success = true;
                response.data = (List<EmpresaDealerDTO>)result;
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
        public async Task<ActionResult<ApiResponse<EmpresaDealerDTO>>> getEmpresaDealerByID(int nIdEmpresaDealer)
        {
            ApiResponse<EmpresaDealerDTO> response = new ApiResponse<EmpresaDealerDTO>();

            try
            {
                var result = await service.getEmpresaDealerByID(nIdEmpresaDealer);

                response.success = (result == null ? false : true);
                response.data = (EmpresaDealerDTO) result;
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
        public async Task<ActionResult<ApiResponse<EmpresaDealerDTO>>> findEmpresaByRUC(string sRUC)
        {
            ApiResponse<EmpresaDealerDTO> response = new ApiResponse<EmpresaDealerDTO>();

            try
            {
                var result = await service.findEmpresaByRUC(sRUC);

                response.success = (result == null ? false : true);
                response.data = (EmpresaDealerDTO) result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsEmpresaDealer([FromBody] EmpresaDealerDTO empresa)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsEmpresaDealer(empresa);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdEmpresaDealer([FromBody] EmpresaDealerDTO empresa)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdEmpresaDealer(empresa);

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
