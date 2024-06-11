using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Cobranzas
{
    public class AgendamientoRepository : IAgendamientoRepository
    {
        private readonly IConfiguration _configuration;

        public AgendamientoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamientoByFilters(AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            IEnumerable<AgendamientoDTO> list = new List<AgendamientoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_agendamiento]", 1);
                parameters.Add("nIdCompania", AgendamientoFiltros.nIdCompania);
                parameters.Add("nIdUsuario", AgendamientoFiltros.nIdUsuario);
                parameters.Add("nIdEmpleado", AgendamientoFiltros.nIdEmpleado);
                parameters.Add("nIdTipoDocumento", AgendamientoFiltros.nIdTipoDocumento);
                parameters.Add("sDocumento", AgendamientoFiltros.sDocumento);
                parameters.Add("nIdProyecto", AgendamientoFiltros.nIdProyecto);
                parameters.Add("nIdSector", AgendamientoFiltros.nIdSector);
                parameters.Add("nIdManzana", AgendamientoFiltros.nIdManzana);
                parameters.Add("nIdLote", AgendamientoFiltros.nIdLote);
                parameters.Add("fechaInicio", AgendamientoFiltros.fechaInicio);
                parameters.Add("fechaFin", AgendamientoFiltros.fechaFin);

                list = await connection.QueryAsync<AgendamientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<SelectDTO>> getSelectAsesorAgendamiento(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_agendamiento]", 2);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamientoVentasByFilters(AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            IEnumerable<AgendamientoDTO> list = new List<AgendamientoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_agendamiento]", 3);
                parameters.Add("nIdCompania", AgendamientoFiltros.nIdCompania);
                parameters.Add("nIdEmpleado", AgendamientoFiltros.nIdEmpleado);
                parameters.Add("nIdTipoDocumento", AgendamientoFiltros.nIdTipoDocumento);
                parameters.Add("sDocumento", AgendamientoFiltros.sDocumento);
                parameters.Add("fechaInicio", AgendamientoFiltros.fechaInicio);
                parameters.Add("fechaFin", AgendamientoFiltros.fechaFin);

                list = await connection.QueryAsync<AgendamientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamientoAtencionCliente(AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            IEnumerable<AgendamientoDTO> list = new List<AgendamientoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_agendamiento]", 4);
                parameters.Add("nIdCompania", AgendamientoFiltros.nIdCompania);
                parameters.Add("nIdUsuario", AgendamientoFiltros.nIdUsuario);
                parameters.Add("nIdCliente", AgendamientoFiltros.nIdCliente);

                list = await connection.QueryAsync<AgendamientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamientoProspecto(AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            IEnumerable<AgendamientoDTO> list = new List<AgendamientoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[atencion].[pa_agendamiento]", 5);
                parameters.Add("nIdCompania", AgendamientoFiltros.nIdCompania);
                parameters.Add("nIdUsuario", AgendamientoFiltros.nIdUsuario);
                parameters.Add("nIdProspecto", AgendamientoFiltros.nIdProspecto);

                list = await connection.QueryAsync<AgendamientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


    }



}
