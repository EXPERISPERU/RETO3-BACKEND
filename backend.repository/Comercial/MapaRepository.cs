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

        public async Task<string> getListManzanas()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(manzanas.*)::json)) FROM manzanas";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListParques()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_verde.*)::json)) FROM area_verde";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListEducacion()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_educacion.*)::json)) FROM aporte_educacion";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListOtrosFines()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_otros_fines.*)::json)) FROM aporte_otros_fines";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListRecreacion()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_recreacion_publica.*)::json)) FROM aporte_recreacion_publica";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListComercial()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_comercial.*)::json)) FROM area_comercial";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListServicios()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_servicio.*)::json)) FROM area_servicio";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListBermas()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(bermas.*)::json)) FROM bermas";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListSectores()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(sectores.*)::json)) FROM sectores";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListVias()
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(vias.*)::json)) FROM vias";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }
    }
}
