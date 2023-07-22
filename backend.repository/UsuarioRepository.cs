using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.domain;
using backend.repository.Interfaces;

namespace backend.repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PerfilDTO>> GetPerfilAll()
        {
            IEnumerable<PerfilDTO> list = new List<PerfilDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_registrar_usuario]", 1);
                //parameters.Add("nIdEmp", nIdEmp);

                list = await connection.QueryAsync<PerfilDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
