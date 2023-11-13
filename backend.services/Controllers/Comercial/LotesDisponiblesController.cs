using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LotesDisponiblesController : ControllerBase
    {
        private readonly ILotesDisponiblesBL service;

        public LotesDisponiblesController(ILotesDisponiblesBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<LotesDisponiblesDTO>>>> getListLotesDisponibles(int nIdCompania)
        {
            ApiResponse<List<LotesDisponiblesDTO>> response = new ApiResponse<List<LotesDisponiblesDTO>>();

            try
            {
                var result = await service.getListLotesDisponibles(nIdCompania);

                response.success = true;
                response.data = (List<LotesDisponiblesDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectCuotaLote(int nIdLote)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectCuotaLote(nIdLote);

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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListInicialLote(int nIdLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListInicialLote(nIdLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoContLote(int nIdLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoContLote(nIdLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoFinLote(int nIdLote)
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoFinLote(nIdLote);

                response.success = true;
                response.data = (List<InicialDescuentoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<LotesDisponiblesDTO>>> postCalculateCotizacion([FromBody] LotesDisponiblesDTO loteDisponible, int nIdCompania)
        {
            ApiResponse<LotesDisponiblesDTO> response = new ApiResponse<LotesDisponiblesDTO>();

            try
            {
                var result = await service.calculateCotizacion(loteDisponible, nIdCompania);

                response.success = true;
                response.data = (LotesDisponiblesDTO)result;
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
