using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapaController : ControllerBase
    {
        private readonly IMapaBL service;

        public MapaController(IMapaBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaLoteDTO>>>> getListLotes()
        {
            ApiResponse<FeatureCollectionDTO<MapaLoteDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaLoteDTO>>();

            try
            {
                var result = await service.getListLotes();

                response.success = true;
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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaManzanaDTO>>>> getListManzanas ()
        {
            ApiResponse<FeatureCollectionDTO<MapaManzanaDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaManzanaDTO>>();

            try
            {
                var result = await service.getListManzanas();

                response.success = true;
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
