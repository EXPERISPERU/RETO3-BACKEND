using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Maestros
{
    public class CompaniaRepository : ICompaniaRepository
    {
        private readonly IConfiguration _configuration;

        public CompaniaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CompaniaDTO>> getListCompania()
        {
            IEnumerable<CompaniaDTO> list = new List<CompaniaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania]", 1);

                list = await connection.QueryAsync<CompaniaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsCompania(CompaniaDTO compania)
        { 
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania]", 2);
                parameters.Add("sRuc", compania.sRUC);
                parameters.Add("sRazonSocial", compania.sRazonSocial);
                parameters.Add("sAbrev", compania.sAbrev);
                parameters.Add("nIdUbigeo", compania.nIdUbigeo);
                parameters.Add("sDireccion", compania.sDireccion);
                parameters.Add("nIdUsuario_crea", compania.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCompania(CompaniaDTO compania)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_compania]", 3);
                parameters.Add("nIdCompania", compania.nIdCompania);
                parameters.Add("sRuc", compania.sRUC);
                parameters.Add("sRazonSocial", compania.sRazonSocial);
                parameters.Add("sAbrev", compania.sAbrev);
                parameters.Add("nIdUbigeo", compania.nIdUbigeo);
                parameters.Add("sDireccion", compania.sDireccion);
                parameters.Add("nIdUsuario_mod", compania.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
