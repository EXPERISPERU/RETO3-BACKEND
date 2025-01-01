﻿using backend.businesslogic.Interfaces.Cobranzas;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Contratos;
using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Cobranzas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificacionController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly INotificacionBL service;
        private readonly IContratoBL contratoService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public NotificacionController(IConfiguration _configuration, INotificacionBL _service, IContratoBL _contratoService, IWebHostEnvironment hostingEnvironment)
        {
            this.configuration = _configuration;
            this.contratoService = _contratoService;
            this.hostingEnvironment = hostingEnvironment;
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<NotificacionDTO>>>> getListNotificacion([FromBody] NotificacionFilterDTO filtroNotificacion)
        {
            ApiResponse<List<NotificacionDTO>> response = new ApiResponse<List<NotificacionDTO>>();

            try
            {
                var result = await service.getListNotificacion(filtroNotificacion);

                response.success = true;
                response.data = (List<NotificacionDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> posInsNotificacion([FromBody] NotificacionDataDTO notificacionData)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.posInsNotificacion(notificacionData);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> posEnviarNotificacion(int nIdNotificacion)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                NotificacionDTO notificacion = await service.getNotificacionByID(nIdNotificacion);

                IList<CronogramaDeudaDTO> deudaCrono = null;

                FormatoDTO formatoCarta = new FormatoDTO();

                if (notificacion.nIdFormato.HasValue)
                {
                    formatoCarta = await service.getFormatoCartaByID(notificacion.nIdFormato.Value);
                }

                PlantillaNotificacionDTO plantilla = await service.getPlantillaNotificacionByID(notificacion.nIdPlantilla);

                ContratoDTO contrato = await contratoService.getContratoById(notificacion.nIdContrato);

                if (contrato.nCuotasPendientes > 0)
                {
                    deudaCrono = await service.getList4CronogramaDeuda(contrato.nIdContrato, notificacion.nIdSeguimiento);
                }

                NotificacionResponseDTO res = await new UltraMsg(configuration!, hostingEnvironment).enviarNotificacion(notificacion, contrato, plantilla, formatoCarta, deudaCrono);

                var message = res.sent ? "SENT" : "ERROR";

                await service.updNotificacionEstado(nIdNotificacion, message);

                response.success = res.sent;
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
        public async Task<ActionResult<ApiResponse<List<PlantillaNotificacionDTO>>>> getListPlantillaNotificacion()
        {
            ApiResponse<List<PlantillaNotificacionDTO>> response = new ApiResponse<List<PlantillaNotificacionDTO>>();

            try
            {
                var result = await service.getListPlantillaNotificacion();

                Console.WriteLine(result);

                response.success = true;
                response.data = (List<PlantillaNotificacionDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListFormatoCartas()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListFormatoCartas();

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
