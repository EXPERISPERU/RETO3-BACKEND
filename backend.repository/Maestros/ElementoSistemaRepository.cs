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
    public class ElementoSistemaRepository : IElementoSistemaRepository
    {
        private readonly IConfiguration _configuration;

        public ElementoSistemaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ElementoSistemaDTO>> ListElementoByIdP(int nIdElementoP)
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 1);
                parameters.Add("nIdElementoP", nIdElementoP);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ElementoSistemaDTO> ElementoById(int nIdElemento)
        {
            ElementoSistemaDTO result = new ElementoSistemaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 2);
                parameters.Add("nIdElemento", nIdElemento);

                result = await connection.QuerySingleAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<SqlRspDTO> InsElementoSistema(ElementoSistemaDTO elemento)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 3);
                parameters.Add("sCodigo", elemento.sCodigo);
                parameters.Add("sAbrev", elemento.sAbrev);
                parameters.Add("sDescripcion", elemento.sDescripcion);
                parameters.Add("nSubGrupo", elemento.nSubGrupo);
                parameters.Add("nTipoElemento", elemento.nTipoElemento);
                parameters.Add("nIdCompania", elemento.nIdCompania);
                parameters.Add("bActivo", elemento.bActivo);
                parameters.Add("nIdPais", elemento.nIdPais);
                parameters.Add("nIdElementoP", elemento.nIdElementoP);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdElementoSistema(ElementoSistemaDTO elemento)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 4);
                parameters.Add("nIdElemento", elemento.nIdElemento);
                parameters.Add("sCodigo", elemento.sCodigo);
                parameters.Add("sAbrev", elemento.sAbrev);
                parameters.Add("sDescripcion", elemento.sDescripcion);
                parameters.Add("nSubGrupo", elemento.nSubGrupo);
                parameters.Add("nTipoElemento", elemento.nTipoElemento);
                parameters.Add("nIdCompania", elemento.nIdCompania);
                parameters.Add("bActivo", elemento.bActivo);
                parameters.Add("nIdPais", elemento.nIdPais);
                parameters.Add("nIdElementoP", elemento.nIdElementoP);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getCompanias()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getPaises()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_elemento_sistema]", 6);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
