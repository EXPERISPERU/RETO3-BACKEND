using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Dealers
{
    public class ReferidoRepository : IReferidoRepository
    {
        private readonly IConfiguration _configuration;

        public ReferidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ReferidoDTO>> getListReferido()
        {
            IEnumerable<ReferidoDTO> list = new List<ReferidoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_referido]", 1);

                list = await connection.QueryAsync<ReferidoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente)
        {
            IEnumerable<ReferidoDTO> list = new List<ReferidoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_referido]", 2);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<ReferidoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> getIdAgenteDealer(int nIdUsuario)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_referido]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsReferido(ReferidoDTO referido)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_referido]", 4);
                parameters.Add("nIdCliente", referido.nIdCliente);
                parameters.Add("nIdAgenteDealer", referido.nIdAgenteDealer);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
