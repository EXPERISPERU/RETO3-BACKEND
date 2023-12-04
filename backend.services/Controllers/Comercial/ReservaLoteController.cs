using backend.businesslogic.Comercial;
using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaLoteController : ControllerBase
    {
        private readonly IReservaLoteBL service;

        public ReservaLoteController(IReservaLoteBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectPrecioReservaByLote(int nIdLote)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectPrecioReservaByLote(nIdLote);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsReserva([FromBody] InsReservaDTO insReserva)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsReserva(insReserva);

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
