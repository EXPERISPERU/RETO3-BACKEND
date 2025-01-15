using backend.domain;
using backend.repository.Interfaces.Tesoreria;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Tesoreria
{
    public class MovimientosRepository : IMovimientosRepository
    {
        private readonly IConfiguration _configuration;
        public MovimientosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<MovimientosDTO>> getAllListMovimientosByCaja(int nIdCaja, int nIdUsuario)
        {
            IEnumerable<MovimientosDTO> list = new List<MovimientosDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 1);
                parameters.Add("nIdCaja", nIdCaja);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<MovimientosDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getAllTipoMovimiento()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<ItemDTO>> getAllItem()
        {
            IEnumerable<ItemDTO> list = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 4);

                list = await connection.QueryAsync<ItemDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 8);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 5);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 6);
                parameters.Add("nIdSector", nIdSector);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 7);
                parameters.Add("nIdManzana", nIdManzana);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros)
        {
            IEnumerable<ContratoDTO> list = new List<ContratoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 9);
                parameters.Add("nIdCompania", contratoFiltros.nIdCompania);
                parameters.Add("sDocumento", contratoFiltros.sDocumento);
                parameters.Add("nIdCondicionPago", contratoFiltros.nIdCondicionPago);
                parameters.Add("nIdProyecto", contratoFiltros.nIdProyecto);
                parameters.Add("nIdSector", contratoFiltros.nIdSector);
                parameters.Add("nIdManzana", contratoFiltros.nIdManzana);
                parameters.Add("nIdLote", contratoFiltros.nIdLote);

                list = await connection.QueryAsync<ContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato)
        {
            IEnumerable<CronogramaDTO> list = new List<CronogramaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 10);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<CronogramaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdCompania, int nIdConceptoVenta)
        {
            IEnumerable<ConfiguracionConceptoDTO> list = new List<ConfiguracionConceptoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 11);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdConceptoVenta", nIdConceptoVenta);

                list = await connection.QueryAsync<ConfiguracionConceptoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<MovimientosDTO>> getAllListMovimientosById(int nIdMovimiento)
        {
            IEnumerable<MovimientosDTO> list = new List<MovimientosDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 13);
                parameters.Add("nIdMovimiento", nIdMovimiento);

                list = await connection.QueryAsync<MovimientosDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania, int nIdProyecto, int nIdSector, int nIdManzana, int nIdLote)
        {
            IEnumerable<LotesDisponiblesDTO> list = new List<LotesDisponiblesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 14);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdSector", nIdSector);
                parameters.Add("nIdManzana", nIdManzana);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<ItemDTO>> getAllItemCompania(int nIdCompania)
        {
            IEnumerable<ItemDTO> list = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 15);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ItemDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }



        //public async Task<SqlRspDTO> InsMovimientos(MovimientosDTO movimientos)
        //{
        //    SqlRspDTO resp = new SqlRspDTO();

        //    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
        //    {
        //        DynamicParameters parameters = new();
        //        string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 2);
        //        parameters.Add("nIdCaja", movimientos.nIdCaja);
        //        parameters.Add("nIdTipoItem", movimientos.nIdTipoItem);
        //        parameters.Add("nIdOrdenPago", movimientos.nIdOrdenPago);
        //        parameters.Add("nIdComprobante", movimientos.nIdComprobante);
        //        parameters.Add("nIdCobranza", movimientos.nIdCobranza);
        //        parameters.Add("nIdUsuario", movimientos.nIdUsuario_crea);
        //        parameters.Add("bValido", movimientos. 




        //        parameters.Add("nIdCliente", movimientos.nIdCliente);
        //        parameters.Add("nIdTipoComprobante", movimientos.nIdTipoComprobante);
        //        parameters.Add("nMedioPago", movimientos.nMedioPago);
        //        parameters.Add("nValorContrato", movimientos.nValorContrato);
        //        parameters.Add("nTipoFinanciamiento", movimientos.nTipoFinanciamiento);
        //        parameters.Add("nIdLote", movimientos.nIdLote);
        //        parameters.Add("nIdContrato", movimientos.nIdContrato);
        //        parameters.Add("nIdPrecioServicio", movimientos.nIdPrecioServicio);
        //        parameters.Add("nIdMoneda", movimientos.nIdMoneda);
        //        //parameters.Add("nIdCuota", movimientos.nIdCuota);
        //        parameters.Add("nIdCronograma", movimientos.nIdCronograma);
        //        parameters.Add("nMontoCuota", movimientos.nMontoCuota);

        //        parameters.Add("nIdUsuario", movimientos.nIdUsuario_crea);
        //        //parameters.Add("nTipoInteresCuotaAplicado", movimientos.nTipoInteresCuotaAplicado);
        //        parameters.Add("sIdOperacionBancaria", movimientos.sIdOperacionBancaria);

        //        resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        //    }

        //    return resp;
        //}

        public async Task<SqlRspDTO> InsMovimientosVenta(MovVentaLoteDTO ventaLote)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 2);
                parameters.Add("nIdLote", ventaLote.nIdLote);
                parameters.Add("nIdCliente", ventaLote.nIdCliente);
                parameters.Add("nIdContrato", ventaLote.nIdContrato);
                parameters.Add("nValorContrato", ventaLote.nValorContrato);
                parameters.Add("nIdTipoComprobante", ventaLote.nIdTipoComprobante);
                parameters.Add("nTipoFinanciamiento", ventaLote.nTipoFinanciamiento);
                parameters.Add("nIdTipoGestionComercial", ventaLote.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", ventaLote.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", ventaLote.nIdEmpleado);
                parameters.Add("nIdMoneda", ventaLote.nIdMoneda);
                parameters.Add("nIdMedioPago", ventaLote.nIdMedioPago);
                parameters.Add("nIdAsignacionPrecio", ventaLote.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", ventaLote.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", ventaLote.nIdInicialLote);
                parameters.Add("nIdInteresCuota", ventaLote.nIdInteresCuota);//NUEVO
                parameters.Add("nMontoVenta", ventaLote.nMontoVenta);
                parameters.Add("nMontoDescuento", ventaLote.nMontoDescuento);
                parameters.Add("nMontoFinal", ventaLote.nMontoFinal);
                parameters.Add("nMontoInicial", ventaLote.nMontoInicial);
                parameters.Add("nMontoInteresCuota", ventaLote.nMontoInteresCuota);//NUEVO
                parameters.Add("nMontoFinanciado", ventaLote.nMontoFinanciado);
                parameters.Add("nIdCuota", ventaLote.nIdCuota);
                parameters.Add("nValorCuota", ventaLote.nValorCuota);
                parameters.Add("nCuotas", ventaLote.nCuotas);
                parameters.Add("nIdCicloPago", ventaLote.nIdCicloPago);
                parameters.Add("nIdUsuario_crea", ventaLote.nIdUsuario_crea);
                parameters.Add("nTipoInteresCuotaAplicado", ventaLote.nTipoInteresCuotaAplicado);
                parameters.Add("sIdOperacionBancaria", ventaLote.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", ventaLote.sIdOperacionIzzipay);
                //Movimientos
                parameters.Add("nIdCaja", ventaLote.nIdCaja);
                parameters.Add("nIdCompania", ventaLote.nIdCompania);
                parameters.Add("nIdTipoItem", ventaLote.nIdTipoItem);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsMovimientosCuota(MovCuotaDTO cuota)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 12);
                parameters.Add("nIdLote", cuota.nIdLote);
                parameters.Add("nIdCliente", cuota.nIdCliente);
                parameters.Add("nIdTipoComprobante", cuota.nIdTipoComprobante);
                parameters.Add("nIdMoneda", cuota.nIdMoneda);
                parameters.Add("nIdMedioPago", cuota.nIdMedioPago);
                parameters.Add("nValorContrato", cuota.nValorContrato);
                parameters.Add("nMontoCuota", cuota.nMontoCuota);
                parameters.Add("nTipoFinanciamiento", cuota.nTipoFinanciamiento);
                parameters.Add("nIdContrato", cuota.nIdContrato);
                parameters.Add("nIdUsuario", cuota.nIdUsuario_crea);
                parameters.Add("nIdCronograma", cuota.nIdCronograma);
                parameters.Add("sIdOperacionBancaria", cuota.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", cuota.sIdOperacionIzzipay);
                //Movimientos
                parameters.Add("nIdCaja", cuota.nIdCaja);
                parameters.Add("nIdCompania", cuota.nIdCompania);
                parameters.Add("nIdTipoItem", cuota.nIdTipoItem);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsMovimientosPrecontrato(MovPreContratoDTO preContrato)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 17);
                parameters.Add("nIdLote", preContrato.nIdLote);
                parameters.Add("nValorPreContrato", preContrato.nValorPreContrato);
                parameters.Add("nVigenciaPreContrato", preContrato.nVigenciaPreContrato);
                parameters.Add("nIdCliente", preContrato.nIdCliente);
                parameters.Add("nIdTipoComprobante", preContrato.nIdTipoComprobante);
                parameters.Add("nIdTipoGestionComercial", preContrato.nIdTipoGestionComercial);
                parameters.Add("nIdAgenteDealer", preContrato.nIdAgenteDealer);
                parameters.Add("nIdEmpleado", preContrato.nIdEmpleado);
                parameters.Add("nIdMoneda", preContrato.nIdMoneda);
                //parameters.Add("nMedioPago", preContrato.nMedioPago);
                parameters.Add("nIdMedioPago", preContrato.nIdMedioPago);
                parameters.Add("nIdAsignacionPrecio", preContrato.nIdAsignacionPrecio);
                parameters.Add("nIdDescuentoLote", preContrato.nIdDescuentoLote);
                parameters.Add("nIdInicialLote", preContrato.nIdInicialLote);
                parameters.Add("nIdInteresCuota", preContrato.nIdInteresCuota);//nuevo
                parameters.Add("nMontoVenta", preContrato.nMontoVenta);
                parameters.Add("nMontoDescuento", preContrato.nMontoDescuento);
                parameters.Add("nMontoFinal", preContrato.nMontoFinal);
                parameters.Add("nMontoInicial", preContrato.nMontoInicial);
                parameters.Add("nMontoInteresCuota", preContrato.nMontoInteresCuota);//nuevo
                parameters.Add("nMontoFinanciado", preContrato.nMontoFinanciado);
                parameters.Add("nIdCuota", preContrato.nIdCuota);
                parameters.Add("nCuotas", preContrato.nCuotas);
                parameters.Add("nValorCuota", preContrato.nValorCuota);
                parameters.Add("nIdUsuario_crea", preContrato.nIdUsuario_crea);
                //parameters.Add("nTipoInteresCuotaAplicado", preContrato.nTipoInteresCuotaAplicado);
                parameters.Add("sIdOperacionBancaria", preContrato.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", preContrato.sIdOperacionIzzipay);
                //Movimientos
                parameters.Add("nIdCaja", preContrato.nIdCaja);
                parameters.Add("nIdCompania", preContrato.nIdCompania);
                parameters.Add("nIdTipoItem", preContrato.nIdTipoItem);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsMovimientosReserva(MovReservaDTO reserva)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 18);
                parameters.Add("nIdLote", reserva.nIdLote);
                parameters.Add("nIdCliente", reserva.nIdCliente);
                parameters.Add("nIdPrecioServicio", reserva.nIdPrecioServicio);
                parameters.Add("nIdUsuario_crea", reserva.nIdUsuario_crea);
                parameters.Add("nIdMonedaP", reserva.nIdMoneda);
                parameters.Add("nIdTipoComprobante", reserva.nIdTipoComprobante);
                parameters.Add("nIdMedioPago", reserva.nIdMedioPago);
                parameters.Add("sIdOperacionBancaria", reserva.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", reserva.sIdOperacionIzzipay);
                //Movimientos
                parameters.Add("nIdCaja", reserva.nIdCaja);
                parameters.Add("nIdCompania", reserva.nIdCompania);
                parameters.Add("nIdTipoItem", reserva.nIdTipoItem);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<MovReporteArqueoDTO>> getAllReporteArqueoCaja(int nIdCompania, int nIdCaja, int nIdUsuario)
        {
            IEnumerable<MovReporteArqueoDTO> list = new List<MovReporteArqueoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 19);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdCaja", nIdCaja);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<MovReporteArqueoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsMovimientosAdicionPrecontrato(MovPreContratoDTO preContrato)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 20);
                parameters.Add("nIdContrato", preContrato.nIdContrato);
                parameters.Add("nIdLote", preContrato.nIdLote);
                parameters.Add("nValorPreContrato", preContrato.nValorPreContrato);
                parameters.Add("nVigenciaPreContrato", preContrato.nVigenciaPreContrato);
                parameters.Add("nIdCliente", preContrato.nIdCliente);
                parameters.Add("nIdTipoComprobante", preContrato.nIdTipoComprobante);
                parameters.Add("nIdMoneda", preContrato.nIdMoneda);
                parameters.Add("nIdMedioPago", preContrato.nIdMedioPago);
                parameters.Add("nMontoFinal", preContrato.nMontoFinal);
                parameters.Add("nMontoInicial", preContrato.nMontoInicial);

                parameters.Add("nIdUsuario_crea", preContrato.nIdUsuario_crea);
                parameters.Add("sIdOperacionBancaria", preContrato.sIdOperacionBancaria);
                parameters.Add("sIdOperacionIzzipay", preContrato.sIdOperacionIzzipay);
                //Movimientos
                parameters.Add("nIdCaja", preContrato.nIdCaja);
                //parameters.Add("nIdCompania", preContrato.nIdCompania);
                parameters.Add("nIdTipoItem", preContrato.nIdTipoItem);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsMovimientosEgreso(MovEgresoDTO movEgreso)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 21);
                parameters.Add("nIdComprobante", movEgreso.nIdComprobante);
                parameters.Add("nIdUsuario_crea", movEgreso.nIdUsuario_crea);
                parameters.Add("nIdCaja", movEgreso.nIdCaja);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<ItemDTO>> getAllItemProductos(int nIdCompania)
        {
            IEnumerable<ItemDTO> list = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 22);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ItemDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<ListPrecioProductoDTO>> postPrecioProducto(ParamPrecioProductoDTO paramPrecioProducto)
        {
            IEnumerable<ListPrecioProductoDTO> list = new List<ListPrecioProductoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 23);
                parameters.Add("nIdConcepto", paramPrecioProducto.nIdConcepto);
                parameters.Add("nIdCompania", paramPrecioProducto.nIdCompania);
                parameters.Add("nIdCliente", paramPrecioProducto.nIdCliente);
                parameters.Add("nIdContrato", paramPrecioProducto.nIdContrato);

                list = await connection.QueryAsync<ListPrecioProductoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getContratosByCLiente(int nIdCompania, int nIdCliente)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_movimientos]", 24);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
