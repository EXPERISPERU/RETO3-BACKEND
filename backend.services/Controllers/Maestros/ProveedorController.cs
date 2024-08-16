using backend.businesslogic.Interfaces.Dealers;
using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        public readonly IProveedorBL service;

        public ProveedorController(IProveedorBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ProveedorDTO>>>> getListProveedor()
        {

            ApiResponse<List<ProveedorDTO>> response = new ApiResponse<List<ProveedorDTO>>();

            try
            {
                var result = await service.getListProveedor();

                response.success = true;
                response.data = (List<ProveedorDTO>)result;
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
        public async Task<ActionResult<ApiResponse<ProveedorDTO>>> getProveedorByID(int nIdProveedor)
        {
            ApiResponse<ProveedorDTO> response = new ApiResponse<ProveedorDTO>();

            try
            {
                var result = await service.getProveedorByID(nIdProveedor);

                response.success = (result == null ? false : true);
                response.data = (ProveedorDTO)result;
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
        public async Task<ActionResult<ApiResponse<ProveedorDTO>>> findProveedorByRUC(string? sDNI, string? sRUC)
        {
            ApiResponse<ProveedorDTO> response = new ApiResponse<ProveedorDTO>();

            try
            {
                var result = await service.findProveedorByRUC(sDNI, sRUC);

                response.success = (result == null ? false : true);
                response.data = (ProveedorDTO) result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsProveedor([FromBody] ProveedorDTO empresa)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsProveedor(empresa);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdProveedor([FromBody] ProveedorDTO empresa)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdProveedor(empresa);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsJefeComercialProveedor([FromBody] JefeComercialDTO jefeComercial)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsJefeComercialProveedor(jefeComercial);

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
        public async Task<ActionResult<ApiResponse<List<JefeComercialDTO>>>> getJefesComercialesByProveedor(int nIdProveedor)
        {
            ApiResponse<List<JefeComercialDTO>> response = new ApiResponse<List<JefeComercialDTO>>();
            try
            {
                var result = await service.getJefesComercialesByProveedor(nIdProveedor);

                response.success = true;
                response.data = (List<JefeComercialDTO>) result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectJefesComerciales(int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getSelectJefesComerciales(nIdCompania);
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoPersona()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getSelectTipoPersona();
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
