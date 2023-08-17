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
using System.Xml.Linq;

namespace backend.repository.Maestros
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly IConfiguration _configuration;

        public UbigeoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PaisDTO>> ListPais()
        {
            IEnumerable<PaisDTO> list = new List<PaisDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 1);

                list = await connection.QueryAsync<PaisDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<UbigeoDTO>> ListUbigeoByIdPTipo(int nIdUbigeoP, int nIdTipoUbigeo, int nIdPais)
        {
            IEnumerable<UbigeoDTO> list = new List<UbigeoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 2);
                parameters.Add("nIdUbigeoP", nIdUbigeoP);
                parameters.Add("nIdTipoUbigeo", nIdTipoUbigeo);
                parameters.Add("nIdPais", nIdPais);

                list = await connection.QueryAsync<UbigeoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> ListTipoUbigeoByPais(int nIdPais)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 3);
                parameters.Add("nIdPais", nIdPais);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsPais(PaisDTO pais)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 4);
                parameters.Add("sCodigo", pais.sCodigo);
                parameters.Add("sPais", pais.sPais);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdPais(PaisDTO pais)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 5);
                parameters.Add("sCodigo", pais.sCodigo);
                parameters.Add("sPais", pais.sPais);
                parameters.Add("nIdPais", pais.nIdPais);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsUbigeo(UbigeoDTO ubigeo)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 6);
                parameters.Add("sCodigo", ubigeo.sCodigo);
                parameters.Add("sUbigeo", ubigeo.sUbigeo);
                parameters.Add("nIdUbigeoP", ubigeo.nIdUbigeoP);
                parameters.Add("nIdTipoUbigeo", ubigeo.nIdTipoUbigeo);
                parameters.Add("nIdPais", ubigeo.nIdPais);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> UpdUbigeo(UbigeoDTO ubigeo)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_ubigeo]", 7);
                parameters.Add("sCodigo", ubigeo.sCodigo);
                parameters.Add("sUbigeo", ubigeo.sUbigeo);
                parameters.Add("nIdUbigeo", ubigeo.nIdUbigeo);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }
    }
}
