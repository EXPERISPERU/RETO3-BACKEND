using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Seguridad;

namespace backend.repository.Seguridad
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
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 1);

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
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 2);
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
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 3);
                parameters.Add("nIdOpcion", perfilOpcion.nIdOpcion);
                parameters.Add("nIdPerfil", perfilOpcion.nIdPerfil);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> ListTipoOpcionByIdOpcionP(int nIdOpcion)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 4);
                parameters.Add("nIdOpcion", nIdOpcion);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> CantOpcionHijo(int nIdOpcion)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 5);
                parameters.Add("nIdOpcion", nIdOpcion);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsOpcion(OpcionDTO opcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 6);
                parameters.Add("nIdOpcionP", opcion.nIdOpcionP);
                parameters.Add("sOpcion", opcion.sOpcion);
                parameters.Add("sDescripcion", opcion.sDescripcion);
                parameters.Add("sRuta", opcion.sRuta);
                parameters.Add("nIdTipoOpcion", opcion.nIdTipoOpcion);
                parameters.Add("bActivo", opcion.bActivo);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdOpcion(OpcionDTO opcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 7);
                parameters.Add("nIdOpcion", opcion.nIdOpcion);
                parameters.Add("nIdOpcionP", opcion.nIdOpcionP);
                parameters.Add("sOpcion", opcion.sOpcion);
                parameters.Add("sDescripcion", opcion.sDescripcion);
                parameters.Add("sRuta", opcion.sRuta);
                parameters.Add("nIdTipoOpcion", opcion.nIdTipoOpcion);
                parameters.Add("bActivo", opcion.bActivo);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsOpcionUsuario(UsuarioOpcionDTO usuarioOpcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 8);
                parameters.Add("nIdUsuario", usuarioOpcion.nIdUsuario);
                parameters.Add("nIdOpcion", usuarioOpcion.nIdOpcion);
                parameters.Add("nIdCompania", usuarioOpcion.nIdCompania);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> DelOpcionUsuario(UsuarioOpcionDTO usuarioOpcion)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[seguridad].[pa_opcion]", 9);
                parameters.Add("nIdUsuario", usuarioOpcion.nIdUsuario);
                parameters.Add("nIdOpcion", usuarioOpcion.nIdOpcion);
                parameters.Add("nIdCompania", usuarioOpcion.nIdCompania);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
