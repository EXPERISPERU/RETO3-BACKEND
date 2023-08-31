using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Dealers;

namespace backend.repository.Dealers
{
    public class EmpresaDealerAgenteRepository : IEmpresaDealerAgenteRepository
    {
        private readonly IConfiguration _configuration;

        public EmpresaDealerAgenteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<EmpresaDealerAgenteDTO>> getListEmpresaDealerAgente(int nIdAgenteDealer)
        {
            IEnumerable<EmpresaDealerAgenteDTO> list = new List<EmpresaDealerAgenteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer_agente]", 1);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                list = await connection.QueryAsync<EmpresaDealerAgenteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getEmpresasDealer()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer_agente]", 2);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> CantActiveEDAByAgente(int nIdAgenteDealer)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer_agente]", 3);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer_agente]", 4);
                parameters.Add("nIdEmpresaDealer", empresaDealerAgente.nIdEmpresaDealer);
                parameters.Add("nIdAgenteDealer", empresaDealerAgente.nIdAgenteDealer);
                parameters.Add("dFechaIni", empresaDealerAgente.dFechaIni);
                parameters.Add("dFechaFin", empresaDealerAgente.dFechaFin);
                parameters.Add("nIdUsuario_crea", empresaDealerAgente.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer_agente]", 5);
                parameters.Add("nIdEmpresaDealerAgente", empresaDealerAgente.nIdEmpresaDealerAgente);
                parameters.Add("nIdEmpresaDealer", empresaDealerAgente.nIdEmpresaDealer);
                parameters.Add("nIdAgenteDealer", empresaDealerAgente.nIdAgenteDealer);
                parameters.Add("dFechaIni", empresaDealerAgente.dFechaIni);
                parameters.Add("dFechaFin", empresaDealerAgente.dFechaFin);
                parameters.Add("nIdUsuario_mod", empresaDealerAgente.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}