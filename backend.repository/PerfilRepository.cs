using backend.domain;
using backend.repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly IConfiguration _configuration;

        public PerfilRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PerfilDTO>> ListPerfil()
        {
            IEnumerable<PerfilDTO> list = new List<PerfilDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_perfil]", 1);

                list = await connection.QueryAsync<PerfilDTO>(storedProcedure, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<OpcionDTO>> ListOpcionByIdPerfil(int nIdPerfil)
        {
            IEnumerable<OpcionDTO> list = new List<OpcionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_perfil]", 2);
                parameters.Add("nIdPerfil", nIdPerfil);

                list = await connection.QueryAsync<OpcionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsertPerfil(PerfilDTO perfil)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_perfil]", 3);
                parameters.Add("sNombre", perfil.sNombre);
                parameters.Add("sDescripcion", perfil.sDescripcion);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdatePerfil(PerfilDTO perfil)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_perfil]", 4);
                parameters.Add("nIdPerfil", perfil.nIdPerfil);
                parameters.Add("sNombre", perfil.sNombre);
                parameters.Add("sDescripcion", perfil.sDescripcion);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
