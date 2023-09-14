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
    public class LoteRepository : ILoteRepository
    {
        private readonly IConfiguration _configuration;

        public LoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<LoteDTO>> getListLotes()
        {
            IEnumerable<LoteDTO> list = new List<LoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_lote]", 1);

                list = await connection.QueryAsync<LoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<LoteDTO>> getListLoteByManzana(int nIdManzana)
        {
            IEnumerable<LoteDTO> list = new List<LoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_lote]", 2);
                parameters.Add("nIdManzana", nIdManzana);

                list = await connection.QueryAsync<LoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
        public async Task<IList<SelectDTO>> getSelectEstadosEdicion()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_lote]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsLote(LoteDTO lote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_lote]", 4);
                parameters.Add("nIdManzana", lote.nIdManzana);
                parameters.Add("sLote", lote.sLote);
                parameters.Add("nIdEstado", lote.nIdEstado);
                parameters.Add("nMetraje", lote.nMetraje);
                parameters.Add("nIdUsuario_crea", lote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdLote(LoteDTO lote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_lote]", 5);
                parameters.Add("nIdLote", lote.nIdLote);
                parameters.Add("nIdManzana", lote.nIdManzana);
                parameters.Add("sLote", lote.sLote);
                parameters.Add("nIdEstado", lote.nIdEstado);
                parameters.Add("nMetraje", lote.nMetraje);
                parameters.Add("nIdUsuario_mod", lote.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
