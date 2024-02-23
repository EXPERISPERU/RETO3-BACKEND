using backend.domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Cobranzas;

namespace backend.repository.Cobranzas
{
    public class AsignacionClienteRepository: IAsignacionClienteRepository
    {
        private readonly IConfiguration _configuration;

        public AsignacionClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectPeriodoGestion()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 1);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania( int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 2);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectSectoresByProyecto(int nIdProyecto)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 3);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 4);
                parameters.Add("nIdSector", nIdSector);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectCicloPagoByProyecto(int nIdProyecto)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 5);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
        public async Task<IList<SelectDTO>> getSelectAsesorCobranza(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 6);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<AsignacionClienteDTO>> getListAsignacionClienteByFilters(AsignacionClienteFiltrosDTO AsignacionFiltros)
        {
            IEnumerable<AsignacionClienteDTO> list = new List<AsignacionClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 7);
                parameters.Add("nIdCompania", AsignacionFiltros.nIdCompania);
                parameters.Add("nIdProyecto", AsignacionFiltros.nIdProyecto);
                parameters.Add("nIdCicloPago", AsignacionFiltros.nIdCicloPago);
                parameters.Add("nIdSector", AsignacionFiltros.nIdSector);
                parameters.Add("nIdManzana", AsignacionFiltros.nIdManzana);
                parameters.Add("nIdLote", AsignacionFiltros.nIdLote);
                parameters.Add("estadoMorosidad", AsignacionFiltros.estadoMorosidad);
                parameters.Add("estadoAsignacion", AsignacionFiltros.estadoAsignacion);
                parameters.Add("nIdPeriodoGestion", AsignacionFiltros.nIdPeriodoGestion);

                list = await connection.QueryAsync<AsignacionClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsAsignacionCliente(AsignacionClienteDTO asignacionCliente)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_asignacion_cliente]", 8);
                parameters.Add("nIdEmpleado", asignacionCliente.nIdEmpleado);
                parameters.Add("nIdCliente", asignacionCliente.nIdCliente);
                parameters.Add("nIdPeriodoGestion", asignacionCliente.nIdPeriodoGestion);
                parameters.Add("nIdUsuario_crea", asignacionCliente.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }


    }
}
