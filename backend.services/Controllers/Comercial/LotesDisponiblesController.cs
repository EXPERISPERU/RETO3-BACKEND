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
        public async Task<ActionResult<ApiResponse<List<LotesDisponiblesDTO>>>> getListLotesDisponibles()
        {
            ApiResponse<List<LotesDisponiblesDTO>> response = new ApiResponse<List<LotesDisponiblesDTO>>();

            try
            {
                var result = await service.getListLotesDisponibles();

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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListInicialLote()
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListInicialLote();

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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoContLote()
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoContLote();

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
        public async Task<ActionResult<ApiResponse<List<InicialDescuentoDTO>>>> getListDescuentoFinLote()
        {
            ApiResponse<List<InicialDescuentoDTO>> response = new ApiResponse<List<InicialDescuentoDTO>>();

            try
            {
                var result = await service.getListDescuentoFinLote();

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
    }
}
