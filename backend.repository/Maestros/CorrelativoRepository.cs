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
    public class CorrelativoRepository : ICorrelativoRepository
    {
        private readonly IConfiguration _configuration;

        public CorrelativoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CorrelativoDTO>> getListCorrelativoBySerie(int nIdSerie)
        {
            IEnumerable<CorrelativoDTO> list = new List<CorrelativoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_correlativo]", 1);
                parameters.Add("nIdSerie", nIdSerie);

                list = await connection.QueryAsync<CorrelativoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> getCantActiveCorrelativoBySerie(int nIdSerie)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_correlativo]", 2);
                parameters.Add("nIdSerie", nIdSerie);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsCorrelativo(CorrelativoDTO correlativo)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_correlativo]", 3);
                parameters.Add("nIdSerie", correlativo.nIdSerie);
                parameters.Add("sDescripcion", correlativo.sDescripcion);
                parameters.Add("nDesde", correlativo.nDesde);
                parameters.Add("nHasta", correlativo.nHasta);
                parameters.Add("nActual", correlativo.nActual);
                parameters.Add("nIdUsuario_crea", correlativo.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCorrelativo(CorrelativoDTO correlativo)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_correlativo]", 4);
                parameters.Add("nIdCorrelativo", correlativo.nIdCorrelativo);
                parameters.Add("sDescripcion", correlativo.sDescripcion);
                parameters.Add("nDesde", correlativo.nDesde);
                parameters.Add("nHasta", correlativo.nHasta);
                parameters.Add("nActual", correlativo.nActual);
                parameters.Add("bActivo", correlativo.bActivo);
                parameters.Add("nIdUsuario_mod", correlativo.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
