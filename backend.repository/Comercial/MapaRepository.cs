using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class MapaRepository : IMapaRepository
    {
        private readonly IConfiguration _configuration;

        public MapaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> getListLotes()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(lote.*)::json)) FROM lote";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }
    }
}
