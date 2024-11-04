using backend.businesslogic.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Tesoreria
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IzipayController : ControllerBase
    {
        public readonly IIzipayBL service;

        public IzipayController(IIzipayBL _service)
        {
            service = _service;
        }

        #region COMERCIOS

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<IzipayComercioDTO>>>> getListComerciosByCompania(int nIdUsuario, int nIdCompania)
        {

            ApiResponse<List<IzipayComercioDTO>> response = new ApiResponse<List<IzipayComercioDTO>>();

            try
            {
                var result = await service.getListComerciosByCompania(nIdUsuario, nIdCompania);

                response.success = true;
                response.data = (List<IzipayComercioDTO>)result;
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
        public async Task<ActionResult<ApiResponse<IzipayComercioDTO>>> getComerciosById(int nIdComercio)
        {

            ApiResponse<IzipayComercioDTO> response = new ApiResponse<IzipayComercioDTO>();

            try
            {
                var result = await service.getComerciosById(nIdComercio);

                response.success = true;
                response.data = (IzipayComercioDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectProyectoByCompania(nIdUsuario, nIdCompania);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsIzipayComercio([FromBody] IzipayComercioDTO comercio)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsIzipayComercio(comercio);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdIzipayComercio([FromBody] IzipayComercioDTO comercio)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdIzipayComercio(comercio);

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

        #endregion

        #region VOUCHERS

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<IzipayVoucherDTO>>>> getListVouchersByCompania(int nIdUsuario, int nIdCompania)
        {

            ApiResponse<List<IzipayVoucherDTO>> response = new ApiResponse<List<IzipayVoucherDTO>>();

            try
            {
                var result = await service.getListVouchersByCompania(nIdUsuario, nIdCompania);

                response.success = true;
                response.data = (List<IzipayVoucherDTO>)result;
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
        public async Task<ActionResult<ApiResponse<IzipayVoucherDTO>>> getVoucherById(int nIdVoucher)
        {

            ApiResponse<IzipayVoucherDTO> response = new ApiResponse<IzipayVoucherDTO>();

            try
            {
                var result = await service.getVoucherById(nIdVoucher);

                response.success = true;
                response.data = (IzipayVoucherDTO) result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectVoucherTipo()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectVoucherTipo();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectVoucherProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectVoucherProyectoByCompania(nIdUsuario, nIdCompania);

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
        public async Task<ActionResult<ApiResponse<List<IzipayComercioDTO>>>> getSelectVoucherComercioByTipoProyecto(int nIdUsuario, int nIdProyecto, int nIdTipoVoucher)
        {
            ApiResponse<List<IzipayComercioDTO>> response = new ApiResponse<List<IzipayComercioDTO>>();

            try
            {
                var result = await service.getSelectVoucherComercioByTipoProyecto(nIdUsuario, nIdProyecto, nIdTipoVoucher);

                response.success = true;
                response.data = (List<IzipayComercioDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectVoucherMoneda(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectVoucherMoneda(nIdUsuario, nIdCompania);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsIzipayVoucher([FromBody] IzipayVoucherDTO voucher)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsIzipayVoucher(voucher);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdIzipayVoucher([FromBody] IzipayVoucherDTO voucher)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdIzipayVoucher(voucher);

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
        public async Task<ActionResult<ApiResponse<IzipayVoucherDTO>>> getVoucherByReferenciaLote(int nIdCompania, int nIdUsuario, int nIdComercio, int nReferencia, int nLote)
        {
            ApiResponse<IzipayVoucherDTO> response = new ApiResponse<IzipayVoucherDTO>();

            try
            {
                var result = await service.getVoucherByReferenciaLote(nIdCompania, nIdUsuario, nIdComercio, nReferencia, nLote);

                response.success = true;
                response.data = (IzipayVoucherDTO)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }
        #endregion

    }
}
