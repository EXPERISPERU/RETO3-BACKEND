using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Cobranzas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GestionSeguimientoController : ControllerBase
    {
        private readonly IGestionSeguimientoBL service;
        public GestionSeguimientoController(IGestionSeguimientoBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<GestionClienteDTO>>>> getListClientesAsignados(int nIdEmpleado)
        {
            ApiResponse<List<GestionClienteDTO>> response = new ApiResponse<List<GestionClienteDTO>>();

            try
            {
                var result = await service.getListClientesAsignados(nIdEmpleado);

                response.success = true;
                response.data = (List<GestionClienteDTO>)result;
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
