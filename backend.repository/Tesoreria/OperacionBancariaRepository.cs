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
    public class OperacionBancariaRepository : IOperacionBancariaRepository
    {
        private readonly IConfiguration _configuration;

        public OperacionBancariaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<OperacionBancariaDTO>> getAllOperacionBancaria(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<OperacionBancariaDTO> list = new List<OperacionBancariaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 1);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<OperacionBancariaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getAllProyectosByCompania(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 2);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<CuentaDTO>> getAllCuentasByProyecto(int nIdCompania, int nIdUsuario, int nIdProyecto, int? nIdMoneda)
        {
            IEnumerable<CuentaDTO> list = new List<CuentaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 3);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdMoneda", nIdMoneda == 0 ? null : nIdMoneda);

                list = await connection.QueryAsync<CuentaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 4);
                parameters.Add("nIdCuenta", operacionBancaria.nIdCuenta);
                parameters.Add("sReferencia", operacionBancaria.sReferencia);
                parameters.Add("nMovimiento", operacionBancaria.nMovimiento);
                parameters.Add("dFechaOperacion", operacionBancaria.dFechaOperacion);
                parameters.Add("nImporte", operacionBancaria.nImporte);
                parameters.Add("nITF", operacionBancaria.nITF);
                parameters.Add("nIdUsuario_crea", operacionBancaria.nIdUsuario_crea);
                parameters.Add("nIdCompania", nIdCompania);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 5);
                parameters.Add("nIdOperacionBancaria", operacionBancaria.nIdOperacionBancaria);
                parameters.Add("sReferencia", operacionBancaria.sReferencia);
                parameters.Add("dFechaOperacion", operacionBancaria.dFechaOperacion);
                parameters.Add("nIdEstado", operacionBancaria.nIdEstado);
                parameters.Add("nIdUsuario_mod", operacionBancaria.nIdUsuario_mod);
                parameters.Add("nIdCompania", nIdCompania);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<OperacionBancariaDTO> getOperacionBancariaByCuentaMovimiento(int nIdCompania, int nIdUsuario, int nIdCuenta, int nMovimiento)
        {
            OperacionBancariaDTO resp = new OperacionBancariaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 6);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCuenta", nIdCuenta);
                parameters.Add("nMovimiento", nMovimiento);

                resp = await connection.QuerySingleOrDefaultAsync<OperacionBancariaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsOperacionBancariaRecaudoBBVA(InsOperacionBancariaRecaudoBBVA operacionBancariaRecaudoBBVA)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[bancos].[pa_operacion_bancaria]", 7);
                parameters.Add("nConvenio", operacionBancariaRecaudoBBVA.nConvenio);
                parameters.Add("sReferencia", operacionBancariaRecaudoBBVA.sReferencia);
                parameters.Add("nMovimiento", operacionBancariaRecaudoBBVA.nMovimiento);
                parameters.Add("dFechaOperacion", operacionBancariaRecaudoBBVA.dFechaOperacion);
                parameters.Add("nImporte", operacionBancariaRecaudoBBVA.nImporte);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

    }
}
