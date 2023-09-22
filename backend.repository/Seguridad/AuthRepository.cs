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
using backend.repository.Interfaces.Seguridad;

namespace backend.repository.Seguridad
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlRspDTO> AuthUser(authLoginDTO authLogin)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_autentication]", 1);
                parameters.Add("sUsuario", authLogin.sUsuario);
                parameters.Add("sPassword", authLogin.sPassword);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<OpcionDTO>> ListOpcionByIdUsuario(int nIdUsuario, int nIdCompania)
        {
            IEnumerable<OpcionDTO> list = new List<OpcionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_autentication]", 2);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<OpcionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<CompaniaDTO>> ListCompaniaByIdUsuario(int nIdUsuario)
        {
            IEnumerable<CompaniaDTO> list = new List<CompaniaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_autentication]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<CompaniaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
