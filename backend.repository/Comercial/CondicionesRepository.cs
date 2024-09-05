using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class CondicionesRepository : ICondicionesRepository
    {
        private readonly IConfiguration _configuration;

        public CondicionesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<CondicionesDTO> list = new List<CondicionesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 1);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<CondicionesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 2);
                parameters.Add("nIdCompania", condiciones.nIdCompania);
                parameters.Add("sDescripcion", condiciones.sDescripcion);
                parameters.Add("bActivo", condiciones.bActivo);
                parameters.Add("nIdUsuario_crea", condiciones.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 3);
                parameters.Add("nIdCondicion", condiciones.nIdCondicion);
                parameters.Add("sDescripcion", condiciones.sDescripcion);
                parameters.Add("bActivo", condiciones.bActivo);
                parameters.Add("nIdUsuario_mod", condiciones.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> SelectTipoCondiciones()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 4);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }
    }
}
