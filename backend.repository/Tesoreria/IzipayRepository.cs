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
    public class IzipayRepository : IIzipayRepository
    {
        private readonly IConfiguration _configuration;

        public IzipayRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<IzipayComercioDTO>> getListComerciosByCompania(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<IzipayComercioDTO> list = new List<IzipayComercioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_comercio]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<IzipayComercioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IzipayComercioDTO> getComerciosById(int nIdComercio)
        {
            IzipayComercioDTO res = new IzipayComercioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_comercio]", 2);
                parameters.Add("nIdComercio", nIdComercio);

                res = await connection.QuerySingleAsync<IzipayComercioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_comercio]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsIzipayComercio(IzipayComercioDTO comercio)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_comercio]", 4);
                parameters.Add("nNroComercio", comercio.nNroComercio);
                parameters.Add("nNroComercioEstatico", comercio.nNroComercioEstatico);
                parameters.Add("nIdProyecto", comercio.nIdProyecto);
                parameters.Add("bActivo", comercio.bActivo);
                parameters.Add("nIdUsuario", comercio.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdIzipayComercio(IzipayComercioDTO comercio)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_comercio]", 5);
                parameters.Add("nIdComercio", comercio.nIdComercio);
                parameters.Add("nNroComercio", comercio.nNroComercio);
                parameters.Add("nNroComercioEstatico", comercio.nNroComercioEstatico);
                parameters.Add("nIdProyecto", comercio.nIdProyecto);
                parameters.Add("bActivo", comercio.bActivo);
                parameters.Add("nIdUsuario", comercio.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<IzipayVoucherDTO>> getListVouchersByCompania(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<IzipayVoucherDTO> list = new List<IzipayVoucherDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<IzipayVoucherDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IzipayVoucherDTO> getVoucherById(int nIdVoucher)
        {
            IzipayVoucherDTO res = new IzipayVoucherDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 2);
                parameters.Add("nIdVoucher", nIdVoucher);

                res = await connection.QuerySingleAsync<IzipayVoucherDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectVoucherTipo()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectVoucherProyectoByCompania(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 4);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectVoucherComercioByTipoProyecto(int nIdUsuario, int nIdProyecto, int nIdTipoVoucher)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 5);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdTipoVoucher", nIdTipoVoucher);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectVoucherMoneda(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 6);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsIzipayVoucher(IzipayVoucherDTO voucher)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 7);
                parameters.Add("nIdComercio", voucher.nIdComercio);
                parameters.Add("nIdTipoVoucher", voucher.nIdTipoVoucher);
                parameters.Add("nReferencia", voucher.nReferencia);
                parameters.Add("nLote", voucher.nLote);
                parameters.Add("nAutorizacion", voucher.nAutorizacion);
                parameters.Add("nBilletera", voucher.nBilletera);
                parameters.Add("dFecha", voucher.dFecha);
                parameters.Add("nIdMoneda", voucher.nIdMoneda);
                parameters.Add("nMonto", voucher.nMonto);
                parameters.Add("nIdUsuario_crea", voucher.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdIzipayVoucher(IzipayVoucherDTO voucher)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[tesoreria].[pa_izipay_voucher]", 8);
                parameters.Add("nIdVoucher", voucher.nIdVoucher);
                parameters.Add("nReferencia", voucher.nReferencia);
                parameters.Add("nLote", voucher.nLote);
                parameters.Add("nAutorizacion", voucher.nAutorizacion);
                parameters.Add("nBilletera", voucher.nBilletera);
                parameters.Add("nIdEstado", voucher.nIdEstado);
                parameters.Add("dFecha", voucher.dFecha);
                parameters.Add("nIdUsuario_crea", voucher.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
