using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Cobranzas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GestionSeguimientoController : ControllerBase
    {
        private readonly IGestionSeguimientoBL service;
        public GestionSeguimientoController(IGestionSeguimientoBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<GestionClienteDTO>>>> getListClientesAsignados(int nIdCompania, int nIdEmpleado)
        {
            ApiResponse<List<GestionClienteDTO>> response = new ApiResponse<List<GestionClienteDTO>>();

            try
            {
                var result = await service.getListClientesAsignados(nIdCompania, nIdEmpleado);

                response.success = true;
                response.data = (List<GestionClienteDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ContratosDeudaDTO>>>> getListContratosDeuda(int nIdCompania, int nIdCliente)
        {
            ApiResponse<List<ContratosDeudaDTO>> response = new ApiResponse<List<ContratosDeudaDTO>>();

            try
            {
                var result = await service.getListContratosDeuda(nIdCompania, nIdCliente);

                response.success = true;
                response.data = (List<ContratosDeudaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<CronogramaDeudaDTO>>>> getListCronogramaDeuda(int nIdContrato, int nIdSeguimiento)
        {
            ApiResponse<List<CronogramaDeudaDTO>> response = new ApiResponse<List<CronogramaDeudaDTO>>();

            try
            {
                var result = await service.getListCronogramaDeuda(nIdContrato, nIdSeguimiento);

                response.success = true;
                response.data = (List<CronogramaDeudaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsSeguimiento([FromBody] SeguimientoDTO seguimiento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsSeguimiento(seguimiento);

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
        public async Task<ActionResult<ApiResponse<GestionClienteDTO>>> getDatosCliente(int nIdUsuario, int nIdCliente, int nIdTipoSeguimiento)
        {
            ApiResponse<GestionClienteDTO> response = new ApiResponse<GestionClienteDTO>();

            try
            {
                var result = await service.getDatosCliente(nIdUsuario, nIdCliente, nIdTipoSeguimiento);

                response.success = true;
                response.data = (GestionClienteDTO) result;
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
        public async Task<ActionResult<ApiResponse<List<ClienteSearchDTO>>>> getListClientSearchByName(int nIdUsuario, int nIdTipoDocumento, string termino )
        {

            ApiResponse<List<ClienteSearchDTO>> response = new ApiResponse<List<ClienteSearchDTO>>();

            try
            {
                var result = await service.getListClientSearchByName(nIdUsuario, nIdTipoDocumento, termino);

                response.success = true;
                response.data = (List<ClienteSearchDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoContacto()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getSelectTipoContacto();
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectMedioContacto()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getSelectMedioContacto();

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsSeguimientoDetalle([FromBody] SeguimientoDetalleDTO detalle)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsSeguimientoDetalle(detalle);

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
        public async Task<ActionResult<ApiResponse<List<SeguimientoDetalleDTO>>>> getListDetalleSeguimiento(int nIdSeguimiento)
        {
            ApiResponse<List<SeguimientoDetalleDTO>> response = new ApiResponse<List<SeguimientoDetalleDTO>>();

            try
            {
                var result = await service.getListDetalleSeguimiento(nIdSeguimiento);

                response.success = true;
                response.data = (List<SeguimientoDetalleDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectResultado(int bRespuesta, int nIdTipoSeguimiento)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectResultado(bRespuesta, nIdTipoSeguimiento);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsAgendamiento([FromBody] AgendamientoDTO agendamiento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsAgendamiento(agendamiento);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoAgendamiento(int nIdTipoSeguimiento)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoAgendamiento(nIdTipoSeguimiento);

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
        public async Task<ActionResult<ApiResponse<List<AgendamientoDTO>>>> getListAgendamiento(int nIdSeguimiento)
        {
            ApiResponse<List<AgendamientoDTO>> response = new ApiResponse<List<AgendamientoDTO>>();

            try
            {
                var result = await service.getListAgendamiento(nIdSeguimiento);

                response.success = true;
                response.data = (List<AgendamientoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsSeguimientoCuota([FromBody] SeguimientoCuotaDTO seguimientoCuotaDTO)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsSeguimientoCuota(seguimientoCuotaDTO);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> UpdTerminarSeguimiento([FromBody] SeguimientoDTO seguimiento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdTerminarSeguimiento(seguimiento);

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
        public async Task<ActionResult<ApiResponse<List<SeguimientoHistoricoDTO>>>> getListSeguimientoByFilters([FromBody] SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            ApiResponse<List<SeguimientoHistoricoDTO>> response = new ApiResponse<List<SeguimientoHistoricoDTO>>();

            try
            {
                var result = await service.getListSeguimientoByFilters(SeguimientoFiltros);
                response.success = true;
                response.data = (List<SeguimientoHistoricoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoDocumento()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoDocumento();

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
        public async Task<ActionResult<ApiResponse<List<SeguimientoDTO>>>> getSeguimiento(int nIdSeguimiento)
        {
            ApiResponse<List<SeguimientoDTO>> response = new ApiResponse<List<SeguimientoDTO>>();

            try
            {
                var result = await service.getSeguimiento(nIdSeguimiento);

                response.success = true;
                response.data = (List<SeguimientoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SeguimientoCuotaDTO>>>> getListSeguimientoCuotaBySeguimiento(int nIdSeguimiento)
        {
            ApiResponse<List<SeguimientoCuotaDTO>> response = new ApiResponse<List<SeguimientoCuotaDTO>>();

            try
            {
                var result = await service.getListSeguimientoCuotaBySeguimiento(nIdSeguimiento);

                response.success = true;
                response.data = (List<SeguimientoCuotaDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getInfoContactoByMedioOfCliente(int nIdCliente, int nIdMedioContacto)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getInfoContactoByMedioOfCliente(nIdCliente, nIdMedioContacto);
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectAsesorSeguimiento(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectAsesorSeguimiento(nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> InsAgendamientoByFechaCompromiso([FromBody] AgendamientoDTO agendamiento)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsAgendamientoByFechaCompromiso(agendamiento);

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
        public async Task<ActionResult<ApiResponse<List<SeguimientoHistoricoDTO>>>> getListSeguimientoVentasByFilters([FromBody] SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            ApiResponse<List<SeguimientoHistoricoDTO>> response = new ApiResponse<List<SeguimientoHistoricoDTO>>();
            try
            {
                var result = await service.getListSeguimientoVentasByFilters(SeguimientoFiltros);
                response.success = true;
                response.data = (List<SeguimientoHistoricoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SeguimientoHistoricoDTO>>>> getListSeguimientoAtencionCliente([FromBody] SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            ApiResponse<List<SeguimientoHistoricoDTO>> response = new ApiResponse<List<SeguimientoHistoricoDTO>>();
            try
            {
                var result = await service.getListSeguimientoAtencionCliente(SeguimientoFiltros);
                response.success = true;
                response.data = (List<SeguimientoHistoricoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SeguimientoProspectoHistoricoDTO>>>> postListSeguimientoProspectoByFilters([FromBody] SeguimientoProspectoFiltrosDTO SeguimientoFiltros)
        {
            ApiResponse<List<SeguimientoProspectoHistoricoDTO>> response = new ApiResponse<List<SeguimientoProspectoHistoricoDTO>>();
            try
            {
                var result = await service.postListSeguimientoProspectoByFilters(SeguimientoFiltros);
                response.success = true;
                response.data = (List<SeguimientoProspectoHistoricoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectAsesorSeguimientoProspecto(int nIdCompania, int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectAsesorSeguimientoProspecto(nIdCompania, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getInfoContactoByMedioOfProspecto(int nIdProspecto, int nIdMedioContacto)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();
            try
            {
                var result = await service.getInfoContactoByMedioOfProspecto(nIdProspecto, nIdMedioContacto);
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
