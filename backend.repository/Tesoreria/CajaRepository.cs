using backend.domain;
using backend.repository.Interfaces.Tesoreria;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Tesoreria
{
    public class CajaRepository : ICajaRepository
    {
        private readonly IConfiguration _configuration;

        public CajaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CajaDTO>> getListValoresCaja(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<CajaDTO> list = new List<CajaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 1);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<CajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> getValidaAperturaCaja(int nIdCompania, int nIdUsuario)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 2);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsCaja(CajaDTO caja)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 3);
                parameters.Add("nIdCaja", caja.nIdCaja);
                parameters.Add("nIdUsuario", caja.nIdUsuario_apertura);
                parameters.Add("nMonto", caja.nMontoApertura);
                parameters.Add("nIdTipoMovimiento", caja.nIdTipoMovimiento);
                parameters.Add("nIdCompania", caja.nIdCompania);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> getValidaPerfil(int nIdCompania, int nIdUsuario)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 4);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdCaja(CajaDTO caja)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 5);
                parameters.Add("nIdCaja", caja.nIdCaja);
                parameters.Add("nIdUsuario", caja.nIdUsuario_apertura);
                parameters.Add("nIdEstado", caja.nIdEstado);
                parameters.Add("nMontoCierre", caja.nMontoCierre);
                parameters.Add("sObservacion", caja.sObservacion);
                

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<CajaDTO>> getListadoCaja(CajaFiltroDTO cajaFiltroDTO)
        {
            IEnumerable<CajaDTO> list = new List<CajaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 6);
                parameters.Add("nIdCompania", cajaFiltroDTO.nIdCompania);
                parameters.Add("nFecIni", cajaFiltroDTO.nFecIni);
                parameters.Add("nFecFin", cajaFiltroDTO.nFecFin);
                parameters.Add("nIdUsuario", cajaFiltroDTO.nIdUsuario);

                list = await connection.QueryAsync<CajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getAllCajeros(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 7);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<CajaDTO>> getListValoresCajaById(int nIdCaja)
        {
            IEnumerable<CajaDTO> list = new List<CajaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_caja]", 8);
                parameters.Add("nIdCaja", nIdCaja);

                list = await connection.QueryAsync<CajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }
    }
}
