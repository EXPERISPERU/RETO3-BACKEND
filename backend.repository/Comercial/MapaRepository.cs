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

        public async Task<string> getListLotes(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(lote.*)::json)) FROM lote where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListManzanas(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(manzanas.*)::json)) FROM manzanas where proyectoid = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListParques(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_verde.*)::json)) FROM area_verde where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListEducacion(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_educacion.*)::json)) FROM aporte_educacion where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListOtrosFines(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_otros_fines.*)::json)) FROM aporte_otros_fines where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListRecreacion(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(aporte_recreacion_publica.*)::json)) FROM aporte_recreacion_publica where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListComercial(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_comercial.*)::json)) FROM area_comercial where idproyecto = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListServicios(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(area_servicio.*)::json)) FROM area_servicio where idproyecto = @idproyecto";
                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListBermas(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(bermas.*)::json)) FROM bermas where proyectoid = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListSectores(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(sectores.*)::json)) FROM sectores where proyectoid = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }

        public async Task<string> getListVias(int nIdProyecto)
        {
            string res;

            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("cnPsql")))
            {
                DynamicParameters parameters = new();
                parameters.Add("idproyecto", nIdProyecto);
                string query = "SELECT json_build_object('type', 'FeatureCollection', 'features', json_agg(ST_AsGeoJSON(vias.*)::json)) FROM vias where proyectoid = @idproyecto";

                res = await connection.QuerySingleAsync<string>(query, parameters, commandType: CommandType.Text);
            }

            return res;
        }
    }
}
