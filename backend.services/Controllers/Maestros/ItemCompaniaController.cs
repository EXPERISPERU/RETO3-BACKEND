using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ItemCompaniaController : ControllerBase
    {
        public readonly IItemCompaniaBL service;

        public ItemCompaniaController(IItemCompaniaBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ItemCompaniaDTO>>>> getListConceptoPagoTipoComprobanteByCompania(int nIdCompania)
        {

            ApiResponse<List<ItemCompaniaDTO>> response = new ApiResponse<List<ItemCompaniaDTO>>();

            try
            {
                var result = await service.getListConceptoPagoTipoComprobanteByCompania(nIdCompania);

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
        public async Task<ActionResult<ApiResponse<List<ItemDTO>>>> getListMaestroConceptoPagos()
        {

            ApiResponse<List<ItemDTO>> response = new ApiResponse<List<ItemDTO>>();

            try
            {
                var result = await service.getListMaestroConceptoPagos();

                response.success = true;
                response.data = (List<ItemDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ElementoSistemaDTO>>>> getListMaestroTipoComprobantes()
        {

            ApiResponse<List<ElementoSistemaDTO>> response = new ApiResponse<List<ElementoSistemaDTO>>();

            try
            {
                var result = await service.getListMaestroTipoComprobantes();

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

        //FUNCION AGREGAR CONFIGURACION
        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsItemCompania([FromBody] ItemCompaniaDTO itemCompaniaDTO)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsItemCompania(itemCompaniaDTO);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsItemCompania_Terminologia([FromBody] ItemCompaniaDTO itemCompaniaDTO)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsItemCompania_Terminologia(itemCompaniaDTO);

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
        public async Task<ActionResult<ApiResponse<List<ItemCompaniaDTO>>>> getListConceptoPagoTerminologiaByCompania(int nIdCompania)
        {

            ApiResponse<List<ItemCompaniaDTO>> response = new ApiResponse<List<ItemCompaniaDTO>>();

            try
            {
                var result = await service.getListConceptoPagoTerminologiaByCompania(nIdCompania);

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


    }
}
