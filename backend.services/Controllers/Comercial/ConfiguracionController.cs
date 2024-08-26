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
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionBL service;

        public ConfiguracionController(IConfiguracionBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ConfiguracionDTO>>>> getConfiguracionByIdProyecto(int nIdproyecto)
        {

            ApiResponse<List<ConfiguracionDTO>> response = new ApiResponse<List<ConfiguracionDTO>>();

            try
            {
                var result = await service.getConfiguracionByIdProyecto(nIdproyecto);

                response.success = true;
                response.data = (List<ConfiguracionDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsConfiguracion([FromBody] ConfiguracionDTO configuracion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsConfiguracion(configuracion);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsConfiguracionConcepto([FromBody] ConfiguracionConceptoDTO configuracionConcepto)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsSistemaConfiguracionConcepto(configuracionConcepto);

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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListInteres()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListInteres();

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
        public async Task<ActionResult<ApiResponse<List<ItemCompaniaDTO>>>> getListConceptoVenta(int nIdCompania)
        {
            ApiResponse<List<ItemCompaniaDTO>> response = new ApiResponse<List<ItemCompaniaDTO>>();

            try
            {
                var result = await service.getListConceptoVenta(nIdCompania);
                response.success = true;
                response.data = (List<ItemCompaniaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListDocumentoVenta()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListDocumentoVenta();

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
        public async Task<ActionResult<ApiResponse<List<CompaniaMonedaDTO>>>> getListMonedaByCompania(int nIdCompania)
        {

            ApiResponse<List<CompaniaMonedaDTO>> response = new ApiResponse<List<CompaniaMonedaDTO>>();

            try
            {
                var result = await service.getListMonedaByCompania(nIdCompania);

                response.success = true;
                response.data = (List<CompaniaMonedaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ImpuestosVentaDTO>>>> getListImpuestoVenta(int nIdCompania)
        {

            ApiResponse<List<ImpuestosVentaDTO>> response = new ApiResponse<List<ImpuestosVentaDTO>>();

            try
            {
                var result = await service.getListImpuestoVenta(nIdCompania);

                response.success = true;
                response.data = (List<ImpuestosVentaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListMaestroDocumentos()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListMaestroDocumentos();

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
        public async Task<ActionResult<ApiResponse<List<ProyectoDocumentoContratoDTO>>>> getListDocumentosContratoConfigByProyecto(int nIdproyecto)
        {
            ApiResponse<List<ProyectoDocumentoContratoDTO>> response = new ApiResponse<List<ProyectoDocumentoContratoDTO>>();

            try
            {
                var result = await service.getListDocumentosContratoConfigByProyecto(nIdproyecto);

                response.success = true;
                response.data = (List<ProyectoDocumentoContratoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getConceptosIGVnoAplicado()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getConceptosIGVnoAplicado();

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


    }
}
