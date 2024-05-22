using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Maestros
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IConfiguration _configuration;

        public ProveedorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProveedorDTO>> getListProveedor()
        {
            IEnumerable<ProveedorDTO> list = new List<ProveedorDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 1);

                list = await connection.QueryAsync<ProveedorDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ProveedorDTO> getProveedorByID(int nIdProveedor)
        {
            ProveedorDTO resp = new ProveedorDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 2);
                parameters.Add("nIdProveedor", nIdProveedor);

                resp = await connection.QuerySingleOrDefaultAsync<ProveedorDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<ProveedorDTO> findProveedorByRUC(string sRUC)
        {
            ProveedorDTO resp = new ProveedorDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 3);
                parameters.Add("sRUC", sRUC);

                resp = await connection.QuerySingleOrDefaultAsync<ProveedorDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 4);
                parameters.Add("nIdPersona", proveedor.nIdPersona);
                parameters.Add("sRUC", proveedor.sRUC);
                parameters.Add("sNombreCompleto", proveedor.sNombreCompleto);
                parameters.Add("sCorreo", proveedor.sCorreo);
                parameters.Add("sCelular", proveedor.sCelular);
                parameters.Add("sTelefono", proveedor.sTelefono);
                parameters.Add("bDealer", proveedor.bDealer);
                parameters.Add("nIdUsuario_crea", proveedor.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 5);
                parameters.Add("nIdProveedor", proveedor.nIdProveedor);
                parameters.Add("nIdPersona", proveedor.nIdPersona);
                parameters.Add("sRUC", proveedor.sRUC);
                parameters.Add("sNombreCompleto", proveedor.sNombreCompleto);
                parameters.Add("sCorreo", proveedor.sCorreo);
                parameters.Add("sCelular", proveedor.sCelular);
                parameters.Add("sTelefono", proveedor.sTelefono);
                parameters.Add("bDealer", proveedor.bDealer);
                parameters.Add("nIdUsuario_mod", proveedor.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsJefeComercialProveedor(JefeComercialDTO jefeComercial)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 6);
                parameters.Add("nIdProveedorJefe", jefeComercial.nIdProveedorJefe);
                parameters.Add("nIdJefeComercial", jefeComercial.nIdJefeComercial);
                parameters.Add("nIdProveedor", jefeComercial.nIdProveedor);
                parameters.Add("dFechaIni", jefeComercial.dFechaIni);
                parameters.Add("dFechaFin", jefeComercial.dFechaFin);
                parameters.Add("nIdUsuario_crea", jefeComercial.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", jefeComercial.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<JefeComercialDTO>> getJefesComercialesByProveedor(int nIdProveedor)
        {
            IEnumerable<JefeComercialDTO> resp = new List<JefeComercialDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 7);
                parameters.Add("nIdProveedor", nIdProveedor);

                resp = await connection.QueryAsync<JefeComercialDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectJefesComerciales()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_proveedor]", 8);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


    }
}
