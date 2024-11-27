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
    public class ReporteDealerController : ControllerBase
    {
        public readonly IReporteDealerBL service;

        public ReporteDealerController(IReporteDealerBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ProveedorDTO>>>> getListProveedorDealer(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<ProveedorDTO>> response = new ApiResponse<List<ProveedorDTO>>();

            try
            {
                var result = await service.getListProveedorDealer(nIdUsuario, nIdCompania);

                response.success = true;
                response.data = (List<ProveedorDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<AgenteDealerDTO>>>> getListAgenteDealerByProveedor(int nIdUsuario, int nIdCompania, int nIdProveedor)
        {
            ApiResponse<List<AgenteDealerDTO>> response = new ApiResponse<List<AgenteDealerDTO>>();

            try
            {
                var result = await service.getListAgenteDealerByProveedor(nIdUsuario, nIdCompania, nIdProveedor);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<rdReporteDataDiaDTO>>>> getListReferenciasxDiaByAD([FromBody] rdSelectReporteDealerDTO rdSelectReporte)
        {
            ApiResponse<List<rdReporteDataDiaDTO>> response = new ApiResponse<List<rdReporteDataDiaDTO>>();

            try
            {
                var result = await service.getListReferenciasxDiaByAD(rdSelectReporte);

                response.success = true;
                response.data = (List<rdReporteDataDiaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<rdReporteDataDiaDTO>>>> getListPrecontratoxDiaByAD([FromBody] rdSelectReporteDealerDTO rdSelectReporte)
        {
            ApiResponse<List<rdReporteDataDiaDTO>> response = new ApiResponse<List<rdReporteDataDiaDTO>>();

            try
            {
                var result = await service.getListPrecontratoxDiaByAD(rdSelectReporte);

                response.success = true;
                response.data = (List<rdReporteDataDiaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<rdReporteDataDiaDTO>>>> getListVentaxDiaByAD([FromBody] rdSelectReporteDealerDTO rdSelectReporte)
        {
            ApiResponse<List<rdReporteDataDiaDTO>> response = new ApiResponse<List<rdReporteDataDiaDTO>>();

            try
            {
                var result = await service.getListVentaxDiaByAD(rdSelectReporte);

                response.success = true;
                response.data = (List<rdReporteDataDiaDTO>)result;
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
