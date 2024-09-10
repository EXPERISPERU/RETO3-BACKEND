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
    public class CondicionesController : ControllerBase
    {
        private readonly ICondicionesBL service;

        public CondicionesController(ICondicionesBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<CondicionesDTO>>>> getListCondiciones(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<CondicionesDTO>> response = new ApiResponse<List<CondicionesDTO>>();

            try
            {
                var result = await service.getListCondiciones(nIdCompania, nIdUsuario);

                response.success = true;
                response.data = (List<CondicionesDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCondiciones([FromBody] CondicionesDTO condiciones)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCondiciones(condiciones);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdCondiciones([FromBody] CondicionesDTO condiciones)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdCondiciones(condiciones);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoCondiciones()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.SelectTipoCondiciones();

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
        public async Task<ActionResult<ApiResponse<List<CondicionesDetDTO>>>> getListCondicionesDetByTipo(int nIdCondicion, int nIdTipoCondicionDet)
        {
            ApiResponse<List<CondicionesDetDTO>> response = new ApiResponse<List<CondicionesDetDTO>>();

            try
            {
                var result = await service.getListCondicionesDetByTipo(nIdCondicion, nIdTipoCondicionDet);

                response.success = true;
                response.data = (List<CondicionesDetDTO>)result;
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
        public async Task<ActionResult<ApiResponse<CondicionesDetDTO>>> getCondicionesDetById(int nIdCondicionesDet)
        {
            ApiResponse<CondicionesDetDTO> response = new ApiResponse<CondicionesDetDTO>();

            try
            {
                var result = await service.getCondicionesDetById(nIdCondicionesDet);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectProyectoByCompania(int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectProyectoByCompania(nIdCompania);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectSectorByProyecto(int nIdProyecto)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectSectorByProyecto(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectManzanaBySector(int nIdSector)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectManzanaBySector(nIdSector);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectLoteByManzana(int nIdManzana)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectLoteByManzana(nIdManzana);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectGrupoInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectGrupoInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectUbicacionInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectUbicacionInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectTerrenoInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectTerrenoInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectZonificacionInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectZonificacionInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectDescripcionInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectDescripcionInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectColorInmueble()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectColorInmueble();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectTipoFinanciamiento()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectTipoFinanciamiento();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectCuotaLote()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectCuotaLote();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectInicial()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectInicial();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectDescuento()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectDescuento();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> SelectInteres()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.SelectInteres();

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCondicionesDet([FromBody] CondicionesDetDTO condicionesDet)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCondicionesDet(condicionesDet);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdCondicionesDet([FromBody] CondicionesDetDTO condicionesDet)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdCondicionesDet(condicionesDet);

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
