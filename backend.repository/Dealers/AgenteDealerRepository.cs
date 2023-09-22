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
    public class AgenteDealerRepository : IAgenteDealerRepository
    {
        private readonly IConfiguration _configuration;

        public AgenteDealerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<AgenteDealerDTO>> getListAgenteDealer()
        {
            IEnumerable<AgenteDealerDTO> list = new List<AgenteDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 1);

                list = await connection.QueryAsync<AgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<AgenteDealerDTO> getAgenteDealerByID(int nIdAgenteDealer)
        {
            AgenteDealerDTO resp = new AgenteDealerDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 2);
                parameters.Add("nIdAgenteDealer", nIdAgenteDealer);

                resp = await connection.QuerySingleOrDefaultAsync<AgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<AgenteDealerDTO> findAgenteDealer(string? sDNI, string? sCE)
        {
            AgenteDealerDTO resp = new AgenteDealerDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 3);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);

                resp = await connection.QuerySingleOrDefaultAsync<AgenteDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsAgenteDealer(AgenteDealerDTO agenteDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 6);
                parameters.Add("nIdPersona", agenteDealer.nIdPersona);
                parameters.Add("sPriNombre", agenteDealer.sPriNombre);
                parameters.Add("sSegNombre", agenteDealer.sSegNombre);
                parameters.Add("sApePaterno", agenteDealer.sApePaterno);
                parameters.Add("sApeMaterno", agenteDealer.sApeMaterno);
                parameters.Add("dFechaNac", agenteDealer.dFechaNac);
                parameters.Add("nIdUbigeoNac", agenteDealer.nIdUbigeoNac);
                parameters.Add("nIdGenero", agenteDealer.nIdGenero);
                parameters.Add("nIdEstadoCivil", agenteDealer.nIdEstadoCivil);
                parameters.Add("sCorreo", agenteDealer.sCorreo);
                parameters.Add("sCelular", agenteDealer.sCelular);
                parameters.Add("sDNI", agenteDealer.sDNI);
                parameters.Add("sCE", agenteDealer.sCE);
                parameters.Add("nIdUsuario_crea", agenteDealer.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdAgenteDealer(AgenteDealerDTO agenteDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_agente_dealer]", 7);
                parameters.Add("nIdAgenteDealer", agenteDealer.nIdAgenteDealer);
                parameters.Add("nIdPersona", agenteDealer.nIdPersona);
                parameters.Add("sPriNombre", agenteDealer.sPriNombre);
                parameters.Add("sSegNombre", agenteDealer.sSegNombre);
                parameters.Add("sApePaterno", agenteDealer.sApePaterno);
                parameters.Add("sApeMaterno", agenteDealer.sApeMaterno);
                parameters.Add("dFechaNac", agenteDealer.dFechaNac);
                parameters.Add("nIdUbigeoNac", agenteDealer.nIdUbigeoNac);
                parameters.Add("nIdGenero", agenteDealer.nIdGenero);
                parameters.Add("nIdEstadoCivil", agenteDealer.nIdEstadoCivil);
                parameters.Add("sCorreo", agenteDealer.sCorreo);
                parameters.Add("sCelular", agenteDealer.sCelular);
                parameters.Add("sDNI", agenteDealer.sDNI);
                parameters.Add("sCE", agenteDealer.sCE);
                parameters.Add("nIdUsuario_mod", agenteDealer.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
