using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class InicialLoteRepository : IInicialLoteRepository
    {
        private readonly IConfiguration _configuration;

        public InicialLoteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<InicialLoteDTO>> getListInicialLote()
        {
            IEnumerable<InicialLoteDTO> list = new List<InicialLoteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 1);

                list = await connection.QueryAsync<InicialLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote)
        {
            InicialLoteDTO resp = new InicialLoteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 2);
                parameters.Add("nIdInicialLote", nIdInicialLote);

                resp = await connection.QuerySingleOrDefaultAsync<InicialLoteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 4);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 6);
                parameters.Add("nIdProyecto", inicialLote.nIdProyecto);
                parameters.Add("sDescripcion", inicialLote.sDescripcion);
                parameters.Add("nIdTipo", inicialLote.nIdTipo);
                parameters.Add("nValor", inicialLote.nValor);
                parameters.Add("nIdMoneda", inicialLote.nIdMoneda);
                parameters.Add("dFechaIni", inicialLote.dFechaIni);
                parameters.Add("dFechaFin", inicialLote.dFechaFin);
                parameters.Add("bActivo", inicialLote.bActivo);
                parameters.Add("nIdUsuario_crea", inicialLote.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO inicialLote)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 7);
                parameters.Add("nIdInicialLote", inicialLote.nIdInicialLote);
                parameters.Add("sDescripcion", inicialLote.sDescripcion);
                parameters.Add("dFechaIni", inicialLote.dFechaIni);
                parameters.Add("dFechaFin", inicialLote.dFechaFin);
                parameters.Add("bActivo", inicialLote.bActivo);
                parameters.Add("nIdUsuario_mod", inicialLote.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_inicial_lote]", 8);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
