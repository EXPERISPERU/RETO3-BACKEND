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
using backend.repository.Interfaces.Cobranzas;

namespace backend.repository.Cobranzas
{
    public class GestionSeguimientoRepository : IGestionSeguimientoRepository
    {
        private readonly IConfiguration _configuration;

        public GestionSeguimientoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado)
        {
            IEnumerable<GestionClienteDTO> list = new List<GestionClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 1);
                parameters.Add("nIdEmpleado", nIdEmpleado);

                list = await connection.QueryAsync<GestionClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

    }
}
