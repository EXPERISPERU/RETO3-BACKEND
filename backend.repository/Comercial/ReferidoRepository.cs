using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class ReferidoRepository : IReferidoRepository
    {
        private readonly IConfiguration _configuration;

        public ReferidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ReferidoDTO>> getListReferido(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<ReferidoDTO> list = new List<ReferidoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ReferidoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente)
        {
            IEnumerable<ReferidoDTO> list = new List<ReferidoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 2);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<ReferidoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 4);
                parameters.Add("nIdCliente", nIdCliente);
                parameters.Add("nIdUsuario", nIdUsuario);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<PersonaDTO> findPersona(string? sDNI, string? sCE)
        {
            PersonaDTO resp = new PersonaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 5);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);

                resp = await connection.QuerySingleOrDefaultAsync<PersonaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 6);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 7);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> getCantReferenciaActivaByPersona(int nIdPersona)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 8);
                parameters.Add("nIdPersona", nIdPersona);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
        public async Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_referido]", 9);
                parameters.Add("nIdPersona", persona.nIdPersona);
                parameters.Add("sPriNombre", persona.sPriNombre);
                parameters.Add("sSegNombre", persona.sSegNombre);
                parameters.Add("sApePaterno", persona.sApePaterno);
                parameters.Add("sApeMaterno", persona.sApeMaterno);
                parameters.Add("sNombreCompleto", persona.sNombreCompleto);
                parameters.Add("dFechaNac", persona.dFechaNac);
                parameters.Add("nIdUbigeoNac", persona.nIdUbigeoNac);
                parameters.Add("nIdGenero", persona.nIdGenero);
                parameters.Add("nIdEstadoCivil", persona.nIdEstadoCivil);
                parameters.Add("sCorreo", persona.sCorreo);
                parameters.Add("sCelular", persona.sCelular);
                parameters.Add("sDNI", persona.sDNI);
                parameters.Add("sCE", persona.sCE);
                parameters.Add("sRUC", persona.sRUC);
                parameters.Add("nIdDireccion", persona.nIdDireccion);
                parameters.Add("sDireccion", persona.sDireccion);
                parameters.Add("nIdUbigeoDir", persona.nIdUbigeoDir);
                parameters.Add("nIdUsuario_crea", persona.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
