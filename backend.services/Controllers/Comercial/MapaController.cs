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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>>>> getListLotes(int nIdCompania, int nIdUsuario, int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListLotes(nIdCompania, nIdUsuario, nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>>>> getListManzanas(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListManzanas(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>>>> getListParques(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListParques(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>>>> getListEducacion(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListEducacion(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>>>> getListOtrosFines(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListOtrosFines(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>>>> getListRecreacion(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListRecreacion(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>>>> getListComercial(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListComercial(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>>>> getListServicios(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListServicios(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>>>> getListBermas(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>>();

            try
            {
                var result = await service.getListBermas(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>>>> getListSectores(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>>();

            try
            {
                var result = await service.getListSectores(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>>>> getListVias(int nIdProyecto)
        {
            ApiResponse<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>> response = new ApiResponse<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>>();

            try
            {
                var result = await service.getListVias(nIdProyecto);

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
