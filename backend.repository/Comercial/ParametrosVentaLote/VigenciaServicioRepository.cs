using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class VigenciaServicioRepository : IVigenciaServicioRepository
    {
        private readonly IConfiguration _configuration;

        public VigenciaServicioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<VigenciaServicioDTO> getListVigenciaServicioById(int nIdVigenciaServicio)
        {
            VigenciaServicioDTO res = new VigenciaServicioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_vigencia_servicio]", 1);
                parameters.Add("nIdVigenciaServicio", nIdVigenciaServicio);

                res = await connection.QuerySingleAsync<VigenciaServicioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsUpdVigenciaServicio(VigenciaServicioDTO vigenciaServicio)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_vigencia_servicio]", 2);

                parameters.Add("nIdVigenciaServicio", vigenciaServicio.nIdVigenciaServicio);
                parameters.Add("nIdPrecioServicio", vigenciaServicio.nIdPrecioServicio);
                parameters.Add("nVigencia", vigenciaServicio.nVigencia);
                parameters.Add("bActivo", vigenciaServicio.bActivo);
                parameters.Add("nIdUsuario_crea", vigenciaServicio.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", vigenciaServicio.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
