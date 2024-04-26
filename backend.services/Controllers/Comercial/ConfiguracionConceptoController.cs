using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfiguracionConceptoController : ControllerBase
    {
        private readonly IConfiguracionConceptoBL service;

        public ConfiguracionConceptoController(IConfiguracionConceptoBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<tipoComprobante>>>> getListTipoComprante()
        {
            ApiResponse<List<tipoComprobante>> response = new ApiResponse<List<tipoComprobante>>();

            try
            {
                var result = await service.getListTipoComprante();
                response.success = true;
                response.data = (List<tipoComprobante>)result;
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
        public async Task<ActionResult<ApiResponse<List<ConfiguracionConceptoDTO>>>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto)
        {
            ApiResponse<List<ConfiguracionConceptoDTO>> response = new ApiResponse<List<ConfiguracionConceptoDTO>>();
            try
            {
                var result = await service.ListConfiguracionConceptoByIdProyecto(nIdproyecto);

                response.success = true;
                response.data = (List<ConfiguracionConceptoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListMedioPago()
        {
            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListMedioPago();
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


        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsConfiguracionConcepto([FromBody] ConfiguracionConceptoDTO configuracion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.postInsConfiguracionConcepto(configuracion);

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
        public async Task<ActionResult<ApiResponse<List<ConfiguracionConceptoDTO>>>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdproyecto, int nIdConceptoVenta)
        {
            ApiResponse<List<ConfiguracionConceptoDTO>> response = new ApiResponse<List<ConfiguracionConceptoDTO>>();
            try
            {
                var result = await service.GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(nIdproyecto, nIdConceptoVenta);

                response.success = true;
                response.data = (List<ConfiguracionConceptoDTO>)result;
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
