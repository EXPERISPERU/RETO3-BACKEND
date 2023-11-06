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

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania)
        {
            IEnumerable<LotesDisponiblesDTO> list = new List<LotesDisponiblesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 2);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 3);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote)
        {
            IEnumerable<InicialDescuentoDTO> list = new List<InicialDescuentoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 4);
                parameters.Add("nIdLote", nIdLote);

                list = await connection.QueryAsync<InicialDescuentoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<LotesDisponiblesDTO> calculateCotizacion(LotesDisponiblesDTO loteDisponible, int nIdCompania)
        {
            LotesDisponiblesDTO res = new LotesDisponiblesDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 5);
                parameters.Add("nIdLote", loteDisponible.nIdLote);
                parameters.Add("nIdAsignacionPrecio", loteDisponible.nIdAsignacionPrecio);
                parameters.Add("nIdInicial", loteDisponible.nIdInicial);
                parameters.Add("nIdDescuentoFin", loteDisponible.nIdDescuentoFin);
                parameters.Add("nIdDescuentoCon", loteDisponible.nIdDescuentoCon);
                parameters.Add("nIdCompania", nIdCompania);

                res = await connection.QuerySingleAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
