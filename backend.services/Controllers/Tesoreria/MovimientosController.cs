using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Tesoreria
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
        public readonly IMovimientosBL service;
        public MovimientosController (IMovimientosBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<MovimientosDTO>>>> getAllListMovimientosByCaja(int nIdCaja, int nIdUsuario)
        {
            ApiResponse<List<MovimientosDTO>> response = new ApiResponse<List<MovimientosDTO>>();

            try
            {
                var result = await service.getAllListMovimientosByCaja(nIdCaja, nIdUsuario);

                response.success = true;
                response.data = (List<MovimientosDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        //[HttpPost("[action]")]
        //public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientos([FromBody] MovimientosDTO movimiento)
        //{
        //    ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

        //    try
        //    {
        //        var result = await service.InsMovimientos(movimiento);

        //        response.success = result.nCod == 0 ? false : true;
        //        response.data = result;
        //        return StatusCode(200, response);
        //    }
        //    catch (Exception ex)
        //    {
        //        response.success = false;
        //        response.errMsj = ex.Message;
        //        return StatusCode(500, response);
        //    }
        //}

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getAllTipoMovimiento()
        {
            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getAllTipoMovimiento();

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
        public async Task<ActionResult<ApiResponse<List<ItemDTO>>>> getAllItem()
        {
            ApiResponse<List<ItemDTO>> response = new ApiResponse<List<ItemDTO>>();

            try
            {
                var result = await service.getAllItem();

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
        public async Task<ActionResult<ApiResponse<List<ConfiguracionConceptoDTO>>>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdCompania, int nIdConceptoVenta)
        {
            ApiResponse<List<ConfiguracionConceptoDTO>> response = new ApiResponse<List<ConfiguracionConceptoDTO>>();
            try
            {
                var result = await service.GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(nIdCompania, nIdConceptoVenta);

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
        public async Task<ActionResult<ApiResponse<List<MovimientosDTO>>>> getAllListMovimientosById(int nIdMovimiento)
        {
            ApiResponse<List<MovimientosDTO>> response = new ApiResponse<List<MovimientosDTO>>();

            try
            {
                var result = await service.getAllListMovimientosById(nIdMovimiento);

                response.success = true;
                response.data = (List<MovimientosDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<LotesDisponiblesDTO>>>> getListLotesDisponibles(int nIdCompania, int nIdProyecto, int nIdSector, int nIdManzana, int nIdLote)
        {
            ApiResponse<List<LotesDisponiblesDTO>> response = new ApiResponse<List<LotesDisponiblesDTO>>();

            try
            {
                var result = await service.getListLotesDisponibles(nIdCompania, nIdProyecto, nIdSector, nIdManzana, nIdLote);

                response.success = true;
                response.data = (List<LotesDisponiblesDTO>)result;
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
        public async Task<ActionResult<ApiResponse<List<ItemDTO>>>> getAllItemCompania(int nIdCompania)
        {
            ApiResponse<List<ItemDTO>> response = new ApiResponse<List<ItemDTO>>();

            try
            {
                var result = await service.getAllItemCompania(nIdCompania);

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

        //INSERTAR TIPOS MOVIMIENTOS

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientosVenta([FromBody] MovVentaLoteDTO ventaLote)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosVenta(ventaLote);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientosCuota([FromBody] MovCuotaDTO cuota)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosCuota(cuota);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientosPreContrato([FromBody] MovPreContratoDTO preContrato)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosPrecontrato(preContrato);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientosReserva([FromBody] MovReservaDTO reserva)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosReserva(reserva);

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
        public async Task<ActionResult<ApiResponse<List<MovReporteArqueoDTO>>>> getAllReporteArqueoCaja(int nIdCompania, int nIdCaja, int nIdUsuario)
        {
            ApiResponse<List<MovReporteArqueoDTO>> response = new ApiResponse<List<MovReporteArqueoDTO>>();

            try
            {
                var result = await service.getAllReporteArqueoCaja(nIdCompania, nIdCaja, nIdUsuario);

                response.success = true;
                response.data = (List<MovReporteArqueoDTO>)result;
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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsAdicPreContratoLote([FromBody] MovPreContratoDTO preContrato)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosAdicionPrecontrato(preContrato);

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
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsMovimientosEgreso([FromBody] MovEgresoDTO movEgreso)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsMovimientosEgreso(movEgreso);

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
        public async Task<ActionResult<ApiResponse<List<ItemDTO>>>> getAllItemProductos(int nIdCompania)
        {
            ApiResponse<List<ItemDTO>> response = new ApiResponse<List<ItemDTO>>();

            try
            {
                var result = await service.getAllItemProductos(nIdCompania);

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

    }
}
