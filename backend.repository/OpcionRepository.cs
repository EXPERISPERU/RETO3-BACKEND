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
    public class OpcionRepository : IOpcionRepository
    {
        private readonly IConfiguration _configuration;

        public OpcionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<OpcionDTO>> ListOpcion()
        {
            IEnumerable<OpcionDTO> list = new List<OpcionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_opcion]", 1);

                list = await connection.QueryAsync<OpcionDTO>(storedProcedure, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_opcion]", 2);
                parameters.Add("nIdOpcion", perfilOpcion.nIdOpcion);
                parameters.Add("nIdPerfil", perfilOpcion.nIdPerfil);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = String.Format("{0};{1}", "[seguridad].[pa_opcion]", 3);
                parameters.Add("nIdOpcion", perfilOpcion.nIdOpcion);
                parameters.Add("nIdPerfil", perfilOpcion.nIdPerfil);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
