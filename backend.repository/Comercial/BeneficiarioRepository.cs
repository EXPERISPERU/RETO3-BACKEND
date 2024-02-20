using backend.domain;
using backend.repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class BeneficiarioRepository : IBeneficiarioRepository
    {
        private readonly IConfiguration _configuration;

        public BeneficiarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<BeneficiarioClienteDTO>> getListBeneficiarioByCliente(int nIdCliente)
        {
            IEnumerable<BeneficiarioClienteDTO> list = new List<BeneficiarioClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 1);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<BeneficiarioClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<BeneficiarioClienteDTO> findPersona(string? sDNI, string? sCE)
        {
            BeneficiarioClienteDTO resp = new BeneficiarioClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 2);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);

                resp = await connection.QuerySingleOrDefaultAsync<BeneficiarioClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListRelacionFamiliar()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsBeneficiario(BeneficiarioClienteDTO beneficiario)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 6);
                parameters.Add("nIdCliente", beneficiario.nIdCliente);
                parameters.Add("nIdPersona", beneficiario.nIdPersona);
                parameters.Add("nIdRelacionFamiliar", beneficiario.nIdRelacionFamiliar);
                parameters.Add("sPriNombre", beneficiario.sPriNombre);
                parameters.Add("sSegNombre", beneficiario.sSegNombre);
                parameters.Add("sApePaterno", beneficiario.sApePaterno);
                parameters.Add("sApeMaterno", beneficiario.sApeMaterno);
                parameters.Add("dFechaNac", beneficiario.dFechaNac);
                parameters.Add("nIdUbigeoNac", beneficiario.nIdUbigeoNac);
                parameters.Add("nIdGenero", beneficiario.nIdGenero);
                parameters.Add("nIdEstadoCivil", beneficiario.nIdEstadoCivil);
                parameters.Add("sCorreo", beneficiario.sCorreo);
                parameters.Add("sCelular", beneficiario.sCelular);
                parameters.Add("sDNI", beneficiario.sDNI);
                parameters.Add("sCE", beneficiario.sCE);
                parameters.Add("nIdUsuario_crea", beneficiario.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdBeneficiario(BeneficiarioClienteDTO beneficiario)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_beneficiario_cliente]", 7);
                parameters.Add("nIdBeneficiario", beneficiario.nIdBeneficiario);
                parameters.Add("nIdPersona", beneficiario.nIdPersona);
                parameters.Add("nIdRelacionFamiliar", beneficiario.nIdRelacionFamiliar);
                parameters.Add("sPriNombre", beneficiario.sPriNombre);
                parameters.Add("sSegNombre", beneficiario.sSegNombre);
                parameters.Add("sApePaterno", beneficiario.sApePaterno);
                parameters.Add("sApeMaterno", beneficiario.sApeMaterno);
                parameters.Add("dFechaNac", beneficiario.dFechaNac);
                parameters.Add("nIdUbigeoNac", beneficiario.nIdUbigeoNac);
                parameters.Add("nIdGenero", beneficiario.nIdGenero);
                parameters.Add("nIdEstadoCivil", beneficiario.nIdEstadoCivil);
                parameters.Add("sCorreo", beneficiario.sCorreo);
                parameters.Add("sCelular", beneficiario.sCelular);
                parameters.Add("sDNI", beneficiario.sDNI);
                parameters.Add("sCE", beneficiario.sCE);
                parameters.Add("nIdUsuario_mod", beneficiario.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
