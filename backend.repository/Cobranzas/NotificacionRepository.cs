using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Cobranzas
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly IConfiguration _configuration;

        public NotificacionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO notificacionFilter)
        {
            IEnumerable<NotificacionDTO> list = new List<NotificacionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]");
                parameters.Add("nTipoNotificacion", notificacionFilter.nTipoNotificacion);
                parameters.Add("nGrupo", notificacionFilter.nGrupo);

                list = await connection.QueryAsync<NotificacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 2);
                parameters.Add("nIdContrato", notificacionData.nIdContrato);
                parameters.Add("nIdCliente", notificacionData.nIdCliente);
                parameters.Add("nIdTipoNotificacion", notificacionData.nIdTipoNotificacion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<PlantillaNotificacionDTO>> getListPlantillaNotificacion()
        {
            IEnumerable<PlantillaNotificacionDTO> list = new List<PlantillaNotificacionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 3);

                list = await connection.QueryAsync<PlantillaNotificacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> posEnviarNotificacion(int nIdNotificacion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 4);
                parameters.Add("nIdNotificacion", nIdNotificacion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
