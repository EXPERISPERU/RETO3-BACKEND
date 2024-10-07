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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaManzanaDTO>>>> getListManzanas()
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

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaParqueDTO>>>> getListParques()
        {
            ApiResponse<FeatureCollectionDTO<MapaParqueDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaParqueDTO>>();

            try
            {
                var result = await service.getListParques();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaEducacionDTO>>>> getListEducacion()
        {
            ApiResponse<FeatureCollectionDTO<MapaEducacionDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaEducacionDTO>>();

            try
            {
                var result = await service.getListEducacion();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO>>>> getListOtrosFines()
        {
            ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO>>();

            try
            {
                var result = await service.getListOtrosFines();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO>>>> getListRecreacion()
        {
            ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO>>();

            try
            {
                var result = await service.getListRecreacion();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaComercialDTO>>>> getListComercial()
        {
            ApiResponse<FeatureCollectionDTO<MapaComercialDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaComercialDTO>>();

            try
            {
                var result = await service.getListComercial();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaServicioDTO>>>> getListServicios()
        {
            ApiResponse<FeatureCollectionDTO<MapaServicioDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaServicioDTO>>();

            try
            {
                var result = await service.getListServicios();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaBermaDTO>>>> getListBermas()
        {
            ApiResponse<FeatureCollectionDTO<MapaBermaDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaBermaDTO>>();

            try
            {
                var result = await service.getListBermas();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaSectorDTO>>>> getListSectores()
        {
            ApiResponse<FeatureCollectionDTO<MapaSectorDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaSectorDTO>>();

            try
            {
                var result = await service.getListSectores();

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaViaDTO>>>> getListVias()
        {
            ApiResponse<FeatureCollectionDTO<MapaViaDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaViaDTO>>();

            try
            {
                var result = await service.getListVias();

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
