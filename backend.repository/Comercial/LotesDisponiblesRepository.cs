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

        public async Task<IList<LotesDisponiblesFiltrosDTO>> getListFiltros(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<LotesDisponiblesFiltrosDTO> list = new List<LotesDisponiblesFiltrosDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 3);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario); 

                list = await connection.QueryAsync<LotesDisponiblesFiltrosDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(SelectLotesDisponiblesDTO select)
        {
            IEnumerable<LotesDisponiblesDTO> list = new List<LotesDisponiblesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lotes_disponibles]", 2);
                parameters.Add("nIdCompania", select.nIdCompania);
                parameters.Add("nIdUsuario", select.nIdUsuario);
                parameters.Add("nIdProyecto", select.nIdProyecto);
                parameters.Add("nIdSector", select.nIdSector);
                parameters.Add("nIdManzana", select.nIdManzana);
                parameters.Add("nIdLote", select.nIdLote);
                parameters.Add("PageNumber", select.PageNumber);
                parameters.Add("RowspPage", select.RowspPage);

                list = await connection.QueryAsync<LotesDisponiblesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();   
        }
    }
}
