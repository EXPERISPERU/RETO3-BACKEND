using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ComprobanteMedioPagoController : ControllerBase
    {
        public readonly IComprobanteMedioPagoBL service;

        public ComprobanteMedioPagoController(IComprobanteMedioPagoBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ComprobanteMedioPagoDTO>>>> getListComprobanteMedioPagoByCompania(int nIdCompania)
        {

            ApiResponse<List<ComprobanteMedioPagoDTO>> response = new ApiResponse<List<ComprobanteMedioPagoDTO>>();

            try
            {
                var result = await service.getListComprobanteMedioPagoByCompania(nIdCompania);

                response.success = true;
                response.data = (List<ComprobanteMedioPagoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListMaestroMedioPago()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListMaestroMedioPago();

                response.success = true;
                response.data = (List<ElementoSistemaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListMaestroTipoComprobantes()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListMaestroTipoComprobantes();

                response.success = true;
                response.data = (List<ElementoSistemaDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        //FUNCION AGREGAR CONFIGURACION
        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsComprobanteMedioPago([FromBody] ComprobanteMedioPagoDTO comprobanteMedioPagoDTO)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsComprobanteMedioPago(comprobanteMedioPagoDTO);

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
