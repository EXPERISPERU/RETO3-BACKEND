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

        public async Task<IList<UsuarioDTO>> GetUsersAll()
        {
            IEnumerable<UsuarioDTO> list = new List<UsuarioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnPostulacion")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[dbo].[pa_registrar]", 1);
                //parameters.Add("nIdEmp", nIdEmp);

                list = await connection.QueryAsync<UsuarioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
