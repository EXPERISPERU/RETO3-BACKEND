using backend.businesslogic.Comercial;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Contratos;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contratos
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoBL service;

        public ContratoController(IContratoBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectCompania()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectCompania();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectProyectoByCompania(int nIdCompania)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectProyectoByCompania(nIdCompania);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectSectorByProyecto(int nIdProyecto)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectSectorByProyecto(nIdProyecto);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectManzanaBySector(int nIdSector)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectManzanaBySector(nIdSector);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectLoteByManzana(int nIdManzana)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectLoteByManzana(nIdManzana);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectCondicionPago()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectCondicionPago();

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectEstadoContrato()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectEstadoContrato();

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
        public async Task<ActionResult<ApiResponse<List<ContratoDTO>>>> postListContratoByFilters([FromBody] ContratoFiltrosDTO contratoFiltros)
        {
            ApiResponse<List<ContratoDTO>> response = new ApiResponse<List<ContratoDTO>>();

            try
            {
                var result = await service.getListContratoByFilters(contratoFiltros);

                response.success = true;
                response.data = (List<ContratoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<ContratoDTO>>> getContratoById(int nIdContrato)
        {
            ApiResponse<ContratoDTO> response = new ApiResponse<ContratoDTO>();

            try
            {
                var result = await service.getContratoById(nIdContrato);

                response.success = true;
                response.data = (ContratoDTO)result;
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
        public async Task<ActionResult<ApiResponse<List<CronogramaDTO>>>> getListCronogramaByContrato(int nIdContrato)
        {
            ApiResponse<List<CronogramaDTO>> response = new ApiResponse<List<CronogramaDTO>>();

            try
            {
                var result = await service.getListCronogramaByContrato(nIdContrato);

                response.success = true;
                response.data = (List<CronogramaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<OrdenPagoPreContratoDTO>>>> getListOrdenPagoByContrato(int nIdContrato)
        {
            ApiResponse<List<OrdenPagoPreContratoDTO>> response = new ApiResponse<List<OrdenPagoPreContratoDTO>>();

            try
            {
                var result = await service.getListOrdenPagoByContrato(nIdContrato);

                response.success = true;
                response.data = (List<OrdenPagoPreContratoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ContratoDTO>>>> getContratosByIdCliente(int nIdCliente)
        {
            ApiResponse<List<ContratoByIdClientDTO>> response = new ApiResponse<List<ContratoByIdClientDTO>>();

            try
            {
                var result = await service.getContratosByIdCliente(nIdCliente);

                response.success = true;
                response.data = (List<ContratoByIdClientDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ListInicialByContrato>>>> getListInicialByContrato(int nIdContrato)
        {
            ApiResponse<List<ListInicialByContrato>> response = new ApiResponse<List<ListInicialByContrato>>();

            try
            {
                var result = await service.getListInicialByContrato(nIdContrato);

                response.success = true;
                response.data = (List<ListInicialByContrato>)result;
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
        public async Task<ActionResult<ApiResponse<List<DocumentosContratoDTO>>>> getListDocumentosByContrato(int nIdContrato)
        {
            ApiResponse<List<DocumentosContratoDTO>> response = new ApiResponse<List<DocumentosContratoDTO>>();

            try
            {
                var result = await service.getListDocumentosByContrato(nIdContrato);

                response.success = true;
                response.data = (List<DocumentosContratoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<BeneficiarioClienteDTO>>> getConyugueByCliente(int nIdCliente)
        {
            ApiResponse<BeneficiarioClienteDTO> response = new ApiResponse<BeneficiarioClienteDTO>();

            try
            {
                var result = await service.getConyugueByCliente(nIdCliente);

                response.success = true;
                response.data = (BeneficiarioClienteDTO)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdConyugueContrato([FromBody] BeneficiarioClienteDTO beneficiario, int nIdContrato)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdConyugueContrato(beneficiario, nIdContrato);

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
