﻿using backend.businesslogic.Interfaces.Cobranzas;
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
        public async Task<ActionResult<ApiResponse<List<GestionClienteDTO>>>> getListClientesAsignados(int nIdEmpleado)
        {
            ApiResponse<List<GestionClienteDTO>> response = new ApiResponse<List<GestionClienteDTO>>();

            try
            {
                var result = await service.getListClientesAsignados(nIdEmpleado);

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
        public async Task<ActionResult<ApiResponse<List<ContratosDeudaDTO>>>> getListContratosDeuda(int nIdCliente)
        {
            ApiResponse<List<ContratosDeudaDTO>> response = new ApiResponse<List<ContratosDeudaDTO>>();

            try
            {
                var result = await service.getListContratosDeuda(nIdCliente);

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
        public async Task<ActionResult<ApiResponse<List<CronogramaDeudaDTO>>>> getListCronogramaDeuda(int nIdContrato)
        {
            ApiResponse<List<CronogramaDeudaDTO>> response = new ApiResponse<List<CronogramaDeudaDTO>>();

            try
            {
                var result = await service.getListCronogramaDeuda(nIdContrato);

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
        public async Task<ActionResult<ApiResponse<GestionClienteDTO>>> getDatosCliente(int nIdCliente)
        {
            ApiResponse<GestionClienteDTO> response = new ApiResponse<GestionClienteDTO>();

            try
            {
                var result = await service.getDatosCliente(nIdCliente);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListClientSearchByName( string termino )
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListClientSearchByName(termino);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectResultado(int bRespuesta)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectResultado(bRespuesta);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectTipoAgendamiento()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectTipoAgendamiento();

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

    }
}
