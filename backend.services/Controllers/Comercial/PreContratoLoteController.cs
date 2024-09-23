﻿using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PreContratoLoteController : ControllerBase
    {
        private readonly IPreContratoLoteBL service;

        public PreContratoLoteController(IPreContratoLoteBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectPrecioPreContratoByLoteInicial(int nIdLote, decimal nValorInicial, int nIdMoneda)
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectPrecioPreContratoByLoteInicial(nIdLote, nValorInicial, nIdMoneda);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsPreContratoLote([FromBody] InsPreContratoLoteDTO insPreContratoLote)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsPreContratoLote(insPreContratoLote);

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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getSelectMedioPago(int nIdUsuario)
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getSelectMedioPago(nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<ContratoDTO>>> getDataPreContratoByLote(int nIdLote, int nIdProyecto, int nIdUsuario)
        {
            ApiResponse<ContratoDTO> response = new ApiResponse<ContratoDTO>();

            try
            {
                var result = await service.getDataPreContratoByLote(nIdLote, nIdProyecto, nIdUsuario);

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
        public async Task<ActionResult<ApiResponse<List<OrdenPagoPreContratoDTO>>>> getListOPsPreContratoByContrato(int nIdContrato, int nIdMoneda)
        {
            ApiResponse<List<OrdenPagoPreContratoDTO>> response = new ApiResponse<List<OrdenPagoPreContratoDTO>>();

            try
            {
                var result = await service.getListOPsPreContratoByContrato(nIdContrato, nIdMoneda);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsAdicPreContratoLote([FromBody] InsPreContratoLoteDTO insPreContratoLote)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.postInsAdicPreContratoLote(insPreContratoLote);

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
        public async Task<ActionResult<ApiResponse<List<PreContratoChartDTO>>>> postListPreContratoChart(PreContratoFilterDTO preContratoFilter)
        {
            ApiResponse<List<PreContratoChartDTO>> response = new ApiResponse<List<PreContratoChartDTO>>();

            try
            {
                var result = await service.postListPreContratoChart(preContratoFilter);

                response.success = true;
                response.data = (List<PreContratoChartDTO>)result;
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
