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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly IConfiguration _configuration;

        public EmpleadoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<EmpleadoDTO>> getListEmpleado()
        {
            IEnumerable<EmpleadoDTO> list = new List<EmpleadoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 1);

                list = await connection.QueryAsync<EmpleadoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<EmpleadoDTO> findPersona(string? sDNI, string? sCE)
        {
            EmpleadoDTO resp = new EmpleadoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 2);
                parameters.Add("sDNI", sDNI);
                parameters.Add("sCE", sCE);

                resp = await connection.QuerySingleOrDefaultAsync<EmpleadoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<EmpleadoDTO> getEmpleadoById(int nIdEmpleado)
        {
            EmpleadoDTO resp = new EmpleadoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 3);
                parameters.Add("nIdEmpleado", nIdEmpleado);

                resp = await connection.QuerySingleOrDefaultAsync<EmpleadoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<DireccionDTO>> getListDireccion(int nIdPersona)
        {
            IEnumerable<DireccionDTO> list = new List<DireccionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 4);
                parameters.Add("nIdPersona", nIdPersona);

                list = await connection.QueryAsync<DireccionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<PeriodoLaboralDTO>> getListPeriodoLab(int nIdEmpleado)
        {
            IEnumerable<PeriodoLaboralDTO> list = new List<PeriodoLaboralDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 5);
                parameters.Add("nIdEmpleado", nIdEmpleado);

                list = await connection.QueryAsync<PeriodoLaboralDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 6);

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
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 7);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsEmpleado(EmpleadoDTO empleado)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 8);
                parameters.Add("nIdPersona", empleado.nIdPersona);
                parameters.Add("sPriNombre", empleado.sPriNombre);
                parameters.Add("sSegNombre", empleado.sSegNombre);
                parameters.Add("sApePaterno", empleado.sApePaterno);
                parameters.Add("sApeMaterno", empleado.sApeMaterno);
                parameters.Add("dFechaNac", empleado.dFechaNac);
                parameters.Add("nIdUbigeoNac", empleado.nIdUbigeoNac);
                parameters.Add("nIdGenero", empleado.nIdGenero);
                parameters.Add("nIdEstadoCivil", empleado.nIdEstadoCivil);
                //parameters.Add("sCorreo", empleado.sCorreo);
                //parameters.Add("sCelular", empleado.sCelular);
                parameters.Add("sDNI", empleado.sDNI);
                parameters.Add("sCE", empleado.sCE);
                parameters.Add("nIdUsuario_crea", empleado.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdEmpleado(EmpleadoDTO empleado)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 9);
                parameters.Add("nIdEmpleado", empleado.nIdEmpleado);
                parameters.Add("nIdPersona", empleado.nIdPersona);
                parameters.Add("sPriNombre", empleado.sPriNombre);
                parameters.Add("sSegNombre", empleado.sSegNombre);
                parameters.Add("sApePaterno", empleado.sApePaterno);
                parameters.Add("sApeMaterno", empleado.sApeMaterno);
                parameters.Add("dFechaNac", empleado.dFechaNac);
                parameters.Add("nIdUbigeoNac", empleado.nIdUbigeoNac);
                parameters.Add("nIdGenero", empleado.nIdGenero);
                parameters.Add("nIdEstadoCivil", empleado.nIdEstadoCivil);
                //parameters.Add("sCorreo", empleado.sCorreo);
                //parameters.Add("sCelular", empleado.sCelular);
                parameters.Add("sDNI", empleado.sDNI);
                parameters.Add("sCE", empleado.sCE);
                parameters.Add("nIdUsuario_mod", empleado.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsDireccion(DireccionDTO direccion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 10);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 11);
                parameters.Add("nIdDireccion", direccion.nIdDireccion);
                parameters.Add("nIdPersona", direccion.nIdPersona);
                parameters.Add("sDireccion", direccion.sDireccion);
                parameters.Add("nIdUbigeo", direccion.nIdUbigeo);
                parameters.Add("sCodPostal", direccion.sCodPostal);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getCompanias()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 12);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<int> CantPerLabActivoByEmpleado(int nIdEmpleado)
        {
            int resp;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 13);
                parameters.Add("nIdEmpleado", nIdEmpleado);

                resp = await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<SqlRspDTO> InsPerLab(PeriodoLaboralDTO periodoLaboral)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 14);
                parameters.Add("nIdCompania", periodoLaboral.nIdCompania);
                parameters.Add("nIdEmpleado", periodoLaboral.nIdEmpleado);
                parameters.Add("dFechaIni", periodoLaboral.dFechaIni);
                parameters.Add("dFechaFin", periodoLaboral.dFechaFin);
                parameters.Add("nIdUsuario_crea", periodoLaboral.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdPerLab(PeriodoLaboralDTO periodoLaboral)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_empleado]", 15);
                parameters.Add("nIdPeriodoLaboral", periodoLaboral.nIdPeriodoLaboral);
                parameters.Add("nIdEmpleado", periodoLaboral.nIdEmpleado);
                parameters.Add("dFechaIni", periodoLaboral.dFechaIni);
                parameters.Add("dFechaFin", periodoLaboral.dFechaFin);
                parameters.Add("nIdUsuario_mod", periodoLaboral.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
