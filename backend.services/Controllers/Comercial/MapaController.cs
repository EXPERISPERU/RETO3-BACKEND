using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult<ApiResponse<List<FeatureDTO>>>> getListLotes()
        {
            ApiResponse<List<FeatureDTO>> response = new ApiResponse<List<FeatureDTO>>();

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
    }
}
