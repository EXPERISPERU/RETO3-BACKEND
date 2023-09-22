using backend.domain;
using backend.repository.Interfaces.Proyectos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Proyectos
{
    public class ManzanaRepository : IManzanaRepository
    {
        private readonly IConfiguration _configuration;

        public ManzanaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ManzanaDTO>> getListManzanaBySector(int nIdSector)
        {
            IEnumerable<ManzanaDTO> list = new List<ManzanaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_manzana]", 1);
                parameters.Add("nIdSector", nIdSector);

                list = await connection.QueryAsync<ManzanaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsManzana(ManzanaDTO manzana)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_manzana]", 2);
                parameters.Add("nIdSector", manzana.nIdSector);
                parameters.Add("sManzana", manzana.sManzana);
                parameters.Add("nLotes", manzana.nLotes);
                parameters.Add("bActivo", manzana.bActivo);
                parameters.Add("nIdUsuario_crea", manzana.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdManzana(ManzanaDTO manzana)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_manzana]", 3);
                parameters.Add("nIdManzana", manzana.nIdManzana);
                parameters.Add("nIdSector", manzana.nIdSector);
                parameters.Add("sManzana", manzana.sManzana);
                parameters.Add("nLotes", manzana.nLotes);
                parameters.Add("bActivo", manzana.bActivo);
                parameters.Add("nIdUsuario_mod", manzana.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
