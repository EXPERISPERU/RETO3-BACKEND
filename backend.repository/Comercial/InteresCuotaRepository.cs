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
    public class InteresCuotaRepository : IInteresCuotaRepository
    {
        private readonly IConfiguration _configuration;

        public InteresCuotaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<InteresCuotaDTO> getListInteresCuotaById(int nIdProyecto, int nIdCuotaLote)
        {
            InteresCuotaDTO res = new InteresCuotaDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 1);
                parameters.Add("nIdProyecto", nIdProyecto);
                parameters.Add("nIdCuotaLote", nIdCuotaLote);

                res = await connection.QuerySingleAsync<InteresCuotaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 2);

                parameters.Add("nIdInteresCuota", interesCuota.nIdInteresCuota);
                parameters.Add("nIdTipoInteres", interesCuota.nIdTipoInteres);
                parameters.Add("nIdProyecto", interesCuota.nIdProyecto);
                parameters.Add("nIdCuotaLote", interesCuota.nIdCuotaLote);
                parameters.Add("nIdTipoValor", interesCuota.nIdTipoValor);
                parameters.Add("sDescripcion", interesCuota.sDescripcion);
                parameters.Add("nIdMoneda", interesCuota.nIdMoneda);
                parameters.Add("nValor", interesCuota.nValor);
                parameters.Add("dFechaIni", interesCuota.dFechaIni);
                parameters.Add("dFechaFin", interesCuota.dFechaFin);
                parameters.Add("bActivo", interesCuota.bActivo);
                parameters.Add("nIdUsuario_crea", interesCuota.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroInteres()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 3);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ProyectoDTO> getProyectoByID(int nIdProyecto)
        {
            ProyectoDTO res = new ProyectoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 4);
                parameters.Add("nIdProyecto", nIdProyecto);

                res = await connection.QuerySingleAsync<ProyectoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 5);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 6);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ConfiguracionDTO>> getListTipoInteresConfigByIdProyecto(int nIdProyecto)
        {
            IEnumerable<ConfiguracionDTO> list = new List<ConfiguracionDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_interes_cuota]", 7);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<ConfiguracionDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
