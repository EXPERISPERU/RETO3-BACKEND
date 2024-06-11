using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Cobranzas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendamientoController : ControllerBase
    {
        private readonly IAgendamientoBL service;
        public AgendamientoController(IAgendamientoBL _service)
        {
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<AgendamientoDTO>>>> getListAgendamientoByFilters([FromBody] AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            ApiResponse<List<AgendamientoDTO>> response = new ApiResponse<List<AgendamientoDTO>>();

            try
            {
                var result = await service.getListAgendamientoByFilters(AgendamientoFiltros);

                response.success = true;
                response.data = (List<AgendamientoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectAsesorAgendamiento(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectAsesorAgendamiento(nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<AgendamientoDTO>>>> getListAgendamientoVentasByFilters([FromBody] AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            ApiResponse<List<AgendamientoDTO>> response = new ApiResponse<List<AgendamientoDTO>>();

            try
            {
                var result = await service.getListAgendamientoVentasByFilters(AgendamientoFiltros);

                response.success = true;
                response.data = (List<AgendamientoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<AgendamientoDTO>>>> getListAgendamientoAtencionCliente([FromBody] AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            ApiResponse<List<AgendamientoDTO>> response = new ApiResponse<List<AgendamientoDTO>>();

            try
            {
                var result = await service.getListAgendamientoAtencionCliente(AgendamientoFiltros);

                response.success = true;
                response.data = (List<AgendamientoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<AgendamientoDTO>>>> getListAgendamientoProspecto([FromBody] AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            ApiResponse<List<AgendamientoDTO>> response = new ApiResponse<List<AgendamientoDTO>>();

            try
            {
                var result = await service.getListAgendamientoProspecto(AgendamientoFiltros);

                response.success = true;
                response.data = (List<AgendamientoDTO>)result;
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
