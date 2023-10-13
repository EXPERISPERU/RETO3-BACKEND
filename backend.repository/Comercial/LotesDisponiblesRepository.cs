using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial
{
    public class LotesDisponiblesRepository : ILotesDisponiblesRepository
    {
        private readonly IConfiguration _configuration;

        public LotesDisponiblesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles()
        {
            IEnumerable<LotesDisponiblesDTO> list = new List<LotesDisponiblesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 1);

                list = await connection.QueryAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote()
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 2);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote()
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 3);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote()
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 4);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
