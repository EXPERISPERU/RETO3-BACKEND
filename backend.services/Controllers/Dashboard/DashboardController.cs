using backend.businesslogic.Interfaces.Dashboard;
using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        public readonly IDashboardBL service;

        public DashboardController(IDashboardBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListUsuarios(int nIdProveedor, int nIdCompania, int nIdUsuario)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListUsuarios(nIdProveedor, nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListProveedores(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListProveedores(nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListTipoUsuario()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListTipoUsuario();

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
        public async Task<ActionResult<ApiResponse<List<TrazabilidadVentasDTO>>>> postTrazabilidadVentas(TrazabilidadVentasFilterChartDTO trazabilidadVentasFilter)
        {
            ApiResponse<List<TrazabilidadVentasDTO>> response = new ApiResponse<List<TrazabilidadVentasDTO>>();

            try
            {
                var result = await service.postTrazabilidadVentas(trazabilidadVentasFilter);

                response.success = true;
                response.data = (List<TrazabilidadVentasDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<TrazabilidadPreContratosDTO>>>> postTrazabilidadPreContratos(TrazabilidadPreContratosFilterChartDTO trazabilidadPreContratosFilter)
        {
            ApiResponse<List<TrazabilidadPreContratosDTO>> response = new ApiResponse<List<TrazabilidadPreContratosDTO>>();

            try
            {
                var result = await service.postTrazabilidadPreContratos(trazabilidadPreContratosFilter);

                response.success = true;
                response.data = (List<TrazabilidadPreContratosDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<AgendamientoChartDTO>>>> postListAgendamientoChart(AgendamientoChartFilterDTO agendamientoChartFilter)
        {
            ApiResponse<List<AgendamientoChartDTO>> response = new ApiResponse<List<AgendamientoChartDTO>>();

            try
            {
                var result = await service.postListAgendamientoChart(agendamientoChartFilter);

                response.success = true;
                response.data = (List<AgendamientoChartDTO>)result;
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
