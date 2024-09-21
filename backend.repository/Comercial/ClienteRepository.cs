using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ClienteDTO>> getListCliente(int nIdUsuario, int nIdCompania, int pagina, int cantpagina, string? sFiltro)
        {
            IEnumerable<ClienteDTO> list = new List<ClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("PageNumber", pagina);
                parameters.Add("RowspPage", cantpagina);
                parameters.Add("sFiltro", sFiltro);

                list = await connection.QueryAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ClienteDTO> getClienteByID(int nIdCompania, int nIdCliente)
        {
            ClienteDTO resp = new ClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 2);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdCliente", nIdCliente);

                resp = await connection.QuerySingleAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<ClienteDTO> findClienteByDoc(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            ClienteDTO resp = new ClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 3);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);
                parameters.Add("sRUC", sRUC);

                resp = await connection.QuerySingleOrDefaultAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getListTiposPersona()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 5);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 6);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsCliente(ClienteDTO cliente)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 7);
                parameters.Add("nIdPersona", cliente.nIdPersona);
                parameters.Add("nIdTipo", cliente.nIdTipo);
                parameters.Add("sPriNombre", cliente.sPriNombre);
                parameters.Add("sSegNombre", cliente.sSegNombre);
                parameters.Add("sApePaterno", cliente.sApePaterno);
                parameters.Add("sApeMaterno", cliente.sApeMaterno);
                parameters.Add("sNombreCompleto", cliente.sNombreCompleto);
                parameters.Add("dFechaNac", cliente.dFechaNac);
                parameters.Add("nIdUbigeoNac", cliente.nIdUbigeoNac);
                parameters.Add("nIdGenero", cliente.nIdGenero);
                parameters.Add("nIdEstadoCivil", cliente.nIdEstadoCivil);
                //parameters.Add("sCorreo", cliente.sCorreo);
                //parameters.Add("sCelular", cliente.sCelular);
                //parameters.Add("sCelular2", cliente.sCelular2);
                //parameters.Add("sTelefono", cliente.sTelefono);
                parameters.Add("sDNI", cliente.sDNI);
                parameters.Add("sCE", cliente.sCE);
                parameters.Add("sRUC", cliente.sRUC);
                parameters.Add("nIdUsuario_crea", cliente.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCliente(ClienteDTO cliente)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 8);
                parameters.Add("nIdCliente", cliente.nIdCliente);
                parameters.Add("nIdPersona", cliente.nIdPersona);
                parameters.Add("nIdTipo", cliente.nIdTipo);
                parameters.Add("sPriNombre", cliente.sPriNombre);
                parameters.Add("sSegNombre", cliente.sSegNombre);
                parameters.Add("sApePaterno", cliente.sApePaterno);
                parameters.Add("sApeMaterno", cliente.sApeMaterno);
                parameters.Add("sNombreCompleto", cliente.sNombreCompleto);
                parameters.Add("dFechaNac", cliente.dFechaNac);
                parameters.Add("nIdUbigeoNac", cliente.nIdUbigeoNac);
                parameters.Add("nIdGenero", cliente.nIdGenero);
                parameters.Add("nIdEstadoCivil", cliente.nIdEstadoCivil);
                //parameters.Add("sCorreo", cliente.sCorreo);
                //parameters.Add("sCelular", cliente.sCelular);
                //parameters.Add("sCelular2", cliente.sCelular2);
                //parameters.Add("sTelefono", cliente.sTelefono);
                parameters.Add("sDNI", cliente.sDNI);
                parameters.Add("sCE", cliente.sCE);
                parameters.Add("sRUC", cliente.sRUC);
                parameters.Add("nIdUsuario_mod", cliente.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<ApiResponse<ClienteDTO>> findClienteGCByDoc(int nIdUsuario, int nIdCompania, string? sDNI, string? sCE)
        {
            ApiResponse<ClienteDTO> resp = new ApiResponse<ClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 9);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);
                parameters.Add("success", resp.success, direction: ParameterDirection.Output);
                parameters.Add("errMsj", resp.errMsj, direction: ParameterDirection.Output, size : int.MaxValue);

                resp.data = await connection.QuerySingleOrDefaultAsync<ClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                resp.success = parameters.Get<bool>("success");
                resp.errMsj = parameters.Get<string>("errMsj");
            }

            return resp;
        }


        public async Task<IList<ClienteTrazabilidadDTO>> postListClienteTrazabilidad(ClienteTrazabilidadFilterDTO clienteTrazabilidadFilter)
        {
            IEnumerable<ClienteTrazabilidadDTO> list = new List<ClienteTrazabilidadDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_cliente]", 10);
                parameters.Add("nIdUsuario", clienteTrazabilidadFilter.nIdUsuario);
                parameters.Add("nIdCompania", clienteTrazabilidadFilter.nIdCompania);
                parameters.Add("nIdProyecto", clienteTrazabilidadFilter.nIdProyecto);
                parameters.Add("sCodTrimestre", clienteTrazabilidadFilter.sCodTrimestre);

                list = await connection.QueryAsync<ClienteTrazabilidadDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }


    }
}
