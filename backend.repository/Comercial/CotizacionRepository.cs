﻿using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class CotizacionRepository : ICotizacionRepository
    {
        private readonly IConfiguration _configuration;

        public CotizacionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectCuotaLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 1);
                parameters.Add("nIdLote", selectCotizacionDTO.nIdLote);
                parameters.Add("nIdInicialLote", selectCotizacionDTO.nIdInicialLote);
                parameters.Add("nIdDescuentoLote", selectCotizacionDTO.nIdDescuentoLote);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 2);
                parameters.Add("nIdLote", selectCotizacionDTO.nIdLote);
                parameters.Add("nIdDescuentoLote", selectCotizacionDTO.nIdDescuentoLote);
                parameters.Add("nIdCuotaLote", selectCotizacionDTO.nIdCuotaLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 3);
                parameters.Add("nIdLote", selectCotizacionDTO.nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 4);
                parameters.Add("nIdLote", selectCotizacionDTO.nIdLote);
                parameters.Add("nIdInicialLote", selectCotizacionDTO.nIdInicialLote);
                parameters.Add("nIdCuotaLote", selectCotizacionDTO.nIdCuotaLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion)
        {
            CotizacionDTO res = new CotizacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 5);
                parameters.Add("nIdLote", cotizacion.nIdLote);
                parameters.Add("nIdAsignacionPrecio", cotizacion.nIdAsignacionPrecio);
                parameters.Add("nIdCuota", cotizacion.nIdCuota);
                parameters.Add("nIdInicial", cotizacion.nIdInicial);
                parameters.Add("nIdDescuentoFin", cotizacion.nIdDescuentoFin);
                parameters.Add("nIdDescuentoCon", cotizacion.nIdDescuentoCon);
                parameters.Add("nIdMoneda", cotizacion.nIdMoneda);

                res = await connection.QuerySingleAsync<CotizacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion) 
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 6);
                parameters.Add("nIdLote", cotizacion.nIdLote);
                parameters.Add("nIdCliente", cotizacion.nIdCliente);
                parameters.Add("nIdMoneda", cotizacion.nIdMoneda);
                parameters.Add("nIdAsignacionPrecio", cotizacion.nIdAsignacionPrecio);
                parameters.Add("nPrecioVenta", cotizacion.nPrecioVenta);
                parameters.Add("nIdInicial", cotizacion.nIdInicial);
                parameters.Add("nInicial", cotizacion.nInicial);
                parameters.Add("nIdDescuentoFin", cotizacion.nIdDescuentoFin);
                parameters.Add("nDescuentoFin", cotizacion.nDescuentoFin);
                parameters.Add("nIdInteresCuota", cotizacion.nIdInteresCuota);
                parameters.Add("nInteresCuota", cotizacion.nInteresCuota);
                parameters.Add("nValorFinanciado", cotizacion.nValorFinanciado);
                parameters.Add("nIdCuota", cotizacion.nIdCuota);
                parameters.Add("nCuotas", cotizacion.nCuotas);
                parameters.Add("nValorCuota", cotizacion.nValorCuota);
                parameters.Add("nIdDescuentoCon", cotizacion.nIdDescuentoCon);
                parameters.Add("nDescuentoCon", cotizacion.nDescuentoCon);
                parameters.Add("nValorContado", cotizacion.nValorContado);
                parameters.Add("nIdUsuario_crea", cotizacion.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<CotizacionDTO> getCotizacionById(int nIdCotizacion)
        {
            CotizacionDTO res = new CotizacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 7);
                parameters.Add("nIdCotizacion", nIdCotizacion);

                res = await connection.QuerySingleAsync<CotizacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<string> formatoCotizacion(int nIdCotizacion)
        {
            string res;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 8);
                parameters.Add("nIdCotizacion", nIdCotizacion);

                res = await connection.QuerySingleAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<ClienteDTO> getClienteReservaByLote(int nIdLote)
        {
            ClienteDTO resp = new ClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 9);
                parameters.Add("nIdLote", nIdLote);

                resp = await connection.QuerySingleAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<ClienteDTO> getClientePreContratoByLote(int nIdLote)
        {
            ClienteDTO resp = new ClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 10);
                parameters.Add("nIdLote", nIdLote);

                resp = await connection.QuerySingleOrDefaultAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros)
        {
            IEnumerable<ReporteCotizacionesDTO> list = new List<ReporteCotizacionesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 12);

                parameters.Add("sCorrelativo", filtros.sCorrelativo);
                parameters.Add("nIdTipoDocumento", filtros.nIdTipoDocumento);
                parameters.Add("sDocumento", filtros.sDocumento);
                parameters.Add("nNombreCompleto", filtros.nNombreCompleto);
                parameters.Add("nIdProyecto", filtros.nIdProyecto);
                parameters.Add("nIdSector", filtros.nIdSector);
                parameters.Add("nIdManzana", filtros.nIdManzana);
                parameters.Add("nIdLote", filtros.nIdLote);
                parameters.Add("dFechaCreacion", filtros.dFechaCreacion);
                parameters.Add("nNombreUsuario", filtros.nNombreUsuario);
                parameters.Add("nIdCompania", filtros.nIdCompania);
                parameters.Add("nIdUsuario", filtros.nIdUsuario);

                list = await connection.QueryAsync<ReporteCotizacionesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 13);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato)
        {
            IEnumerable<SqlRspDTO> list = new List<SqlRspDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 14);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdCuota", nIdCuota);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectInteresDTO>> getListInteresLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            IEnumerable<SelectInteresDTO> list = new List<SelectInteresDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 15);
                parameters.Add("nIdLote", selectCotizacionDTO.nIdLote);
                parameters.Add("nIdInicialLote", selectCotizacionDTO.nIdInicialLote);
                parameters.Add("nIdDescuentoLote", selectCotizacionDTO.nIdDescuentoLote);
                parameters.Add("nIdCuotaLote", selectCotizacionDTO.nIdCuotaLote);

                list = await connection.QueryAsync<SelectInteresDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri, int? nIdMonedaDest)
        {
            TipoCambioDTO resp = new TipoCambioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 16);
                parameters.Add("nIdLote", nIdLote);
                parameters.Add("nIdMonedaOri", nIdMonedaOri);
                parameters.Add("nIdMonedaDest", nIdMonedaDest);

                resp = await connection.QuerySingleAsync<TipoCambioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<CotizacionChartDTO>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter)
        {
            IEnumerable<CotizacionChartDTO> list = new List<CotizacionChartDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cotizacion]", 17);
                parameters.Add("nIdUsuario", cotizacionChartFilter.nIdUsuario);
                parameters.Add("nIdCompania", cotizacionChartFilter.nIdCompania);
                parameters.Add("nIdProyecto", cotizacionChartFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", cotizacionChartFilter.sCodTrimestre);
                parameters.Add("sMes", cotizacionChartFilter.sMes);
                parameters.Add("sAno", cotizacionChartFilter.sAno);

                list = await connection.QueryAsync<CotizacionChartDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

    }
}
