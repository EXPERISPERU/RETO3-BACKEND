using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Dealers
{
    public class EmpresaDealerRepository : IEmpresaDealerRepository
    {
        private readonly IConfiguration _configuration;

        public EmpresaDealerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<EmpresaDealerDTO>> getListEmpresaDealer()
        {
            IEnumerable<EmpresaDealerDTO> list = new List<EmpresaDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer]", 1);

                list = await connection.QueryAsync<EmpresaDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<EmpresaDealerDTO> getEmpresaDealerByID(int nIdEmpresaDealer)
        {
            EmpresaDealerDTO resp = new EmpresaDealerDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer]", 2);
                parameters.Add("nIdEmpresaDealer", nIdEmpresaDealer);

                resp = await connection.QuerySingleOrDefaultAsync<EmpresaDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<EmpresaDealerDTO> findEmpresaByRUC(string sRUC)
        {
            EmpresaDealerDTO resp = new EmpresaDealerDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer]", 3);
                parameters.Add("sRUC", sRUC);

                resp = await connection.QuerySingleOrDefaultAsync<EmpresaDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsEmpresaDealer(EmpresaDealerDTO empresaDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer]", 4);
                parameters.Add("nIdPersona", empresaDealer.nIdPersona);
                parameters.Add("sRUC", empresaDealer.sRUC);
                parameters.Add("sNombreCompleto", empresaDealer.sNombreCompleto);
                parameters.Add("sCorreo", empresaDealer.sCorreo);
                parameters.Add("sCelular", empresaDealer.sCelular);
                parameters.Add("sTelefono", empresaDealer.sTelefono);
                parameters.Add("nIdUsuario_crea", empresaDealer.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdEmpresaDealer(EmpresaDealerDTO empresaDealer)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_empresa_dealer]", 5);
                parameters.Add("nIdEmpresaDealer", empresaDealer.nIdEmpresaDealer);
                parameters.Add("nIdPersona", empresaDealer.nIdPersona);
                parameters.Add("sRUC", empresaDealer.sRUC);
                parameters.Add("sNombreCompleto", empresaDealer.sNombreCompleto);
                parameters.Add("sCorreo", empresaDealer.sCorreo);
                parameters.Add("sCelular", empresaDealer.sCelular);
                parameters.Add("sTelefono", empresaDealer.sTelefono);
                parameters.Add("nIdUsuario_mod", empresaDealer.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
