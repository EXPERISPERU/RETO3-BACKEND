using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Maestros
{
    public class DatoContactoRepository : IDatoContactoRepository
    {
        private readonly IConfiguration _configuration;

        public DatoContactoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<DatoContactoDTO>> getListDatoContacto(int nIdPersona)
        {
            IEnumerable<DatoContactoDTO> list = new List<DatoContactoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_dato_contacto]", 1);
                parameters.Add("nIdPersona", nIdPersona);

                list = await connection.QueryAsync<DatoContactoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMedioContacto()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_dato_contacto]", 2);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsDatoContacto(DatoContactoDTO datoContacto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_dato_contacto]", 3);
                parameters.Add("nIdPersona", datoContacto.nIdPersona);
                parameters.Add("nIdMedio", datoContacto.nIdMedio);
                parameters.Add("sDetalle", datoContacto.sDetalle);
                parameters.Add("nIdUsuario_crea", datoContacto.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdDatoContacto(DatoContactoDTO datoContacto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_dato_contacto]", 4);
                parameters.Add("nIdDatoContacto", datoContacto.nIdDatoContacto);
                parameters.Add("nIdPersona", datoContacto.nIdPersona);
                parameters.Add("nIdMedio", datoContacto.nIdMedio);
                parameters.Add("sDetalle", datoContacto.sDetalle);
                parameters.Add("nIdUsuario_mod", datoContacto.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
