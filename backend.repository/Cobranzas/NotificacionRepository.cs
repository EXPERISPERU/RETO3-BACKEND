using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using Dapper;
using Microsoft.Extensions.Configuration;
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

        public async Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO filter)
        {
            IEnumerable<NotificacionDTO> list = new List<NotificacionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]");
                parameters.Add("nTipoNotificacion", filter.nIdTipoNotificacion);
                parameters.Add("nGrupo", filter.nIdGrupo);

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
                parameters.Add("nIdCliente", notificacionData.nIdCliente);
                parameters.Add("nIdContrato", notificacionData.nIdContrato);
                parameters.Add("nIdTipoNotificacion", notificacionData.nIdTipoNotificacion);
                parameters.Add("nIdTipoSeguimiento", notificacionData.nIdTipoSeguimiento);
                parameters.Add("nIdSeguimiento", notificacionData.nIdSeguimiento);
                parameters.Add("nIdFormato", notificacionData.nIdFormato);
                parameters.Add("nIdUsuario", notificacionData.nIdUsuario);
                parameters.Add("nIdCompania", notificacionData.nIdCompania);
                parameters.Add("nIdPlantilla", notificacionData.nIdPlantilla);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getListPlantillaNotificacion()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> updNotificacionEstado(int nIdNotificacion, string message)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 4);
                parameters.Add("nIdNotificacion", nIdNotificacion);
                parameters.Add("sCode", message);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getListMedioEnvio()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<NotificacionDTO> getNotificacionByID(int? nIdNotificacion)
        {
            NotificacionDTO resp = new NotificacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 6);
                parameters.Add("nIdNotificacion", nIdNotificacion);

                resp = await connection.QuerySingleAsync<NotificacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<PlantillaNotificacionDTO> getPlantillaNotificacionByID(int? nIdPlantilla)
        {
            PlantillaNotificacionDTO resp = new PlantillaNotificacionDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 7);
                parameters.Add("nIdPlantilla", nIdPlantilla);


                resp = await connection.QuerySingleAsync<PlantillaNotificacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getListFormatoCartas()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 8);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<FormatoDTO> getFormatoCartaByID(int? nIdFormato)
        {
            FormatoDTO resp = new FormatoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 9);
                parameters.Add("nIdFormato", nIdFormato);

                resp = await connection.QuerySingleAsync<FormatoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<CronogramaDeudaDTO>> getList4CronogramaDeuda(int nIdContrato, int? nIdSeguimiento)
        {
            IEnumerable<CronogramaDeudaDTO> list = new List<CronogramaDeudaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 10);
                parameters.Add("nIdContrato", nIdContrato);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<CronogramaDeudaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<ClienteDeudaDTO>> getListMorosos(NotificacionFilterDTO filter)
        {
            IEnumerable<ClienteDeudaDTO> list = new List<ClienteDeudaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 11);
                parameters.Add("nIdProyecto", filter.nIdProyecto);
                parameters.Add("nIdGrupo", filter.nIdGrupo);
                parameters.Add("nIdCiclo", filter.nIdCiclo);
                parameters.Add("nIdEstado", filter.nIdEstado);
                parameters.Add("PageNumber", filter.PageNumber);
                parameters.Add("RowspPage", filter.RowspPage);

                list = await connection.QueryAsync<ClienteDeudaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<ContratosDeudaDTO> getDeudaByContratoID(int? nIdCompania, int? nIdCliente, int? nIdContrato)
        {
            ContratosDeudaDTO resp = new ContratosDeudaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 12);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdCliente", nIdCliente);
                parameters.Add("nIdContrato", nIdContrato);


                resp = await connection.QuerySingleAsync<ContratosDeudaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<NotificacionDTO>> getListNotificacionBySeguimiento(int? nIdSeguimiento)
        {
            IEnumerable<NotificacionDTO> list = new List<NotificacionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_notificacion]", 13);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<NotificacionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }


    }
}
