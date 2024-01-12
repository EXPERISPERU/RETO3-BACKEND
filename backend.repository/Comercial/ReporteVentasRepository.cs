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
using backend.repository.Interfaces.Comercial;

namespace backend.repository.Comercial
{
    public class ReporteVentasRepository : IReporteVentasRepository
    {
        private readonly IConfiguration _configuration;

        public ReporteVentasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ReporteVentasDTO>> getListReporteVentas()
        {
            IEnumerable<ReporteVentasDTO> list = new List<ReporteVentasDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_reporte_ventas]", 2);

                list = await connection.QueryAsync<ReporteVentasDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
