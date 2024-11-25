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
using backend.repository.Interfaces.Contabilidad;

namespace backend.repository.Contabilidad
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly IConfiguration _configuration;

        public AsientoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<AsientoCajaDTO>> getAsientoCaja(AsientoFilterDTO filter)
        {
            IEnumerable<AsientoCajaDTO> list = new List<AsientoCajaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_asiento_contable]", 1);
                parameters.Add("nIdProyecto", filter.nIdProyecto);
                parameters.Add("dFechaInicio", filter.dFechaInicio);
                parameters.Add("dFechaFin", filter.dFechaFin);

                list = await connection.QueryAsync<AsientoCajaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<AsientoBancoDTO>> getAsientoBancos(AsientoFilterDTO filter)
        {
            IEnumerable<AsientoBancoDTO> list = new List<AsientoBancoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contabilidad].[pa_asiento_contable]", 2);
                parameters.Add("nIdProyecto", filter.nIdProyecto);
                parameters.Add("dFechaInicio", filter.dFechaInicio);
                parameters.Add("dFechaFin", filter.dFechaFin);

                list = await connection.QueryAsync<AsientoBancoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
