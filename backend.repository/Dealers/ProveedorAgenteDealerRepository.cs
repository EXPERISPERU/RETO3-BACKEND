using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Dealers
{
    public class ProveedorAgenteDealerRepository : IProveedorAgenteDealerRepository
    {
        private readonly IConfiguration _configuration;

        public ProveedorAgenteDealerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProveedorAgenteDealerDTO>> getListProveedorAgente(int nIdAgenteDealer)
        {
            IEnumerable<ProveedorAgenteDealerDTO> list = new List<ProveedorAgenteDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 1);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                list = await connection.QueryAsync<ProveedorAgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getProveedoresDealer()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 2);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> CantActivePADByAgente(int nIdAgenteDealer)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 3);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 4);
                parameters.Add("nIdProveedor", proveedorAgenteDealer.nIdProveedor);
                parameters.Add("nIdAgenteDealer", proveedorAgenteDealer.nIdAgenteDealer);
                parameters.Add("dFechaIni", proveedorAgenteDealer.dFechaIni);
                parameters.Add("dFechaFin", proveedorAgenteDealer.dFechaFin);
                parameters.Add("nIdUsuario_crea", proveedorAgenteDealer.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 5);
                parameters.Add("nIdProveedorAgente", proveedorAgenteDealer.nIdProveedorAgente);
                parameters.Add("nIdProveedor", proveedorAgenteDealer.nIdProveedor);
                parameters.Add("nIdAgenteDealer", proveedorAgenteDealer.nIdAgenteDealer);
                parameters.Add("dFechaIni", proveedorAgenteDealer.dFechaIni);
                parameters.Add("dFechaFin", proveedorAgenteDealer.dFechaFin);
                parameters.Add("nIdUsuario_mod", proveedorAgenteDealer.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getJefesDealer(int nIdProveedor, int nIdAgenteDealer)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 6);
                parameters.Add("nIdProveedor", nIdProveedor);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsJefeDealer(JefeAgenteDealerDTO jefeAgenteDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 7);
                parameters.Add("nIdJefeDealer", jefeAgenteDealer.nIdJefeDealer);
                parameters.Add("nIdJefe", jefeAgenteDealer.nIdJefe);
                parameters.Add("nIdAgenteDealer", jefeAgenteDealer.nIdAgenteDealer);
                parameters.Add("nIdProveedorAgente", jefeAgenteDealer.nIdProveedorAgente);
                parameters.Add("dFechaIni", jefeAgenteDealer.dFechaIni);
                parameters.Add("dFechaFin", jefeAgenteDealer.dFechaFin);
                parameters.Add("nIdUsuario_crea", jefeAgenteDealer.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", jefeAgenteDealer.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<JefeAgenteDealerDTO>> getJefesDealerByAgenteDealer(int nIdAgenteDealer)
        {
            IEnumerable<JefeAgenteDealerDTO> list = new List<JefeAgenteDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_proveedor_agente_dealer]", 8);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                list = await connection.QueryAsync<JefeAgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

    }
}
