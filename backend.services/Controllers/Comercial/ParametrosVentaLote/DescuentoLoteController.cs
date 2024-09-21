using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial.ParametrosVentaLote
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DescuentoLoteController : ControllerBase
    {
        private readonly IDescuentoLoteBL service;

        public DescuentoLoteController(IDescuentoLoteBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<DescuentoLoteDTO>>>> getListDescuentoLote()
        {
            ApiResponse<List<DescuentoLoteDTO>> response = new ApiResponse<List<DescuentoLoteDTO>>();

            try
            {
                var result = await service.getListDescuentoLote();

                response.success = true;
                response.data = (List<DescuentoLoteDTO>)result;
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
        public async Task<ActionResult<ApiResponse<DescuentoLoteDTO>>> getDescuentoLoteByID(int nIdDescuentoLote)
        {
            ApiResponse<DescuentoLoteDTO> response = new ApiResponse<DescuentoLoteDTO>();

            try
            {
                var result = await service.getDescuentoLoteByID(nIdDescuentoLote);

                response.success = result != null;
                response.data = (DescuentoLoteDTO) result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoDescuento()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoDescuento();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectMoneda()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectMoneda();

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsDescuentoLote([FromBody] DescuentoLoteDTO descuentoLote)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsDescuentoLote(descuentoLote);

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
