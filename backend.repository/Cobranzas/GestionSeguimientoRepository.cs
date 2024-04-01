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
using System.Collections;

namespace backend.repository.Cobranzas
{
    public class GestionSeguimientoRepository : IGestionSeguimientoRepository
    {
        private readonly IConfiguration _configuration;

        public GestionSeguimientoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado)
        {
            IEnumerable<GestionClienteDTO> list = new List<GestionClienteDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 1);
                parameters.Add("nIdEmpleado", nIdEmpleado);

                list = await connection.QueryAsync<GestionClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<ContratosDeudaDTO>> getListContratosDeuda(int nIdCliente)
        {
            IEnumerable<ContratosDeudaDTO> list = new List<ContratosDeudaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 2);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<ContratosDeudaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<CronogramaDeudaDTO>> getListCronogramaDeuda(int nIdContrato, int nIdSeguimiento)
        {
            IEnumerable<CronogramaDeudaDTO> list = new List<CronogramaDeudaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 3);
                parameters.Add("nIdContrato", nIdContrato);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<CronogramaDeudaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsSeguimiento(SeguimientoDTO seguimiento)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 4);
                parameters.Add("nIdSeguimiento", seguimiento.nIdSeguimiento);
                parameters.Add("nIdTipoSeguimiento", seguimiento.nIdTipoSeguimiento);
                parameters.Add("nTiempoGestion", seguimiento.nTiempoGestion);
                parameters.Add("nIdCliente", seguimiento.nIdCliente);
                parameters.Add("nIdAsignacion", seguimiento.nIdAsignacion);
                parameters.Add("nIdUsuario_crea", seguimiento.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<GestionClienteDTO> getDatosCliente(int nIdUsuario, int nIdCliente, int nIdTipoSeguimiento)
        {
            GestionClienteDTO res = new GestionClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 5);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("nIdCliente", nIdCliente);
                parameters.Add("nIdTipoSeguimiento", nIdTipoSeguimiento);

                res = await connection.QuerySingleAsync<GestionClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<IList<ClienteSearchDTO>> getListClientSearchByName(int nIdUsuario, string termino)
        {
            IEnumerable<ClienteSearchDTO> list = new List<ClienteSearchDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 6);
                parameters.Add("nIdUsuario", nIdUsuario);
                parameters.Add("termSearch", termino);

                list = await connection.QueryAsync<ClienteSearchDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoContacto()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 7);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectMedioContacto()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 8);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsSeguimientoDetalle(SeguimientoDetalleDTO detalle)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 9);
                parameters.Add("nIdSeguimientoDetalle", detalle.nIdSeguimientoDetalle);
                parameters.Add("nIdSeguimiento", detalle.nIdSeguimiento);
                parameters.Add("nIdTipo", detalle.nIdTipo);
                parameters.Add("nIdMedio", detalle.nIdMedio);
                parameters.Add("sContacto", detalle.sContacto);
                parameters.Add("bRespondio", detalle.bRespondio);
                parameters.Add("nIdResultado", detalle.nIdResultado);
                parameters.Add("sDetalle", detalle.sDetalle);
                parameters.Add("nIdUsuario_crea", detalle.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", detalle.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<IList<SeguimientoDetalleDTO>> getListDetalleSeguimiento(int nIdSeguimiento)
        {
            IEnumerable<SeguimientoDetalleDTO> list = new List<SeguimientoDetalleDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 10);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<SeguimientoDetalleDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectResultado(int bRespuesta, int nIdTipoSeguimiento)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 11);
                parameters.Add("bRespondio", bRespuesta);
                parameters.Add("nIdTipoSeguimiento", nIdTipoSeguimiento);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsAgendamiento(AgendamientoDTO agendamiento)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 12);
                parameters.Add("nIdAgendamiento", agendamiento.nIdAgendamiento);
                parameters.Add("nIdTipoAgendamiento", agendamiento.nIdTipoAgendamiento);
                parameters.Add("nIdSeguimiento", agendamiento.nIdSeguimiento);
                parameters.Add("nIdCliente", agendamiento.nIdCliente);
                parameters.Add("nIdEmpleado", agendamiento.nIdEmpleado);
                parameters.Add("dFecha", agendamiento.dFecha);
                parameters.Add("sDescripcion", agendamiento.sDescripcion);
                parameters.Add("nIdUsuario_crea", agendamiento.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", agendamiento.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<IList<SelectDTO>> getSelectTipoAgendamiento(int nIdTipoSeguimiento)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 13);
                parameters.Add("nIdTipoSeguimiento", nIdTipoSeguimiento);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<AgendamientoDTO>> getListAgendamiento(int nIdSeguimiento)
        {
            IEnumerable<AgendamientoDTO> list = new List<AgendamientoDTO>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 14);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<AgendamientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsSeguimientoCuota(SeguimientoCuotaDTO seguimientoCuota)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 15);
                parameters.Add("nIdSeguimientoCuota", seguimientoCuota.nIdSeguimientoCuota);
                parameters.Add("nIdSeguimiento", seguimientoCuota.nIdSeguimiento);
                parameters.Add("nIdContrato", seguimientoCuota.nIdContrato);
                parameters.Add("nIdCronograma", seguimientoCuota.nIdCronograma);
                parameters.Add("nValorCuota", seguimientoCuota.nValorCuota);
                parameters.Add("dFechaVencimiento", seguimientoCuota.dFechaVencimiento);
                parameters.Add("nDiasMora", seguimientoCuota.nDiasMora);
                parameters.Add("nValorMora", seguimientoCuota.nValorMora);
                parameters.Add("nValorTotal", seguimientoCuota.nValorTotal);
                parameters.Add("nValorCompromiso", seguimientoCuota.nValorCompromiso);
                parameters.Add("dFechaCompromiso", seguimientoCuota.dFechaCompromiso);
                parameters.Add("nIdEstadoCompromiso", seguimientoCuota.nIdEstadoCompromiso);
                parameters.Add("nIdUsuario_crea", seguimientoCuota.nIdUsuario_crea);
                parameters.Add("dFecha_crea", seguimientoCuota.dFecha_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<SqlRspDTO> UpdTerminarSeguimiento(SeguimientoDTO seguimiento)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 16);
                parameters.Add("nIdSeguimiento", seguimiento.nIdSeguimiento);
                parameters.Add("nTiempoGestion", seguimiento.nTiempoGestion);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }

        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoByFilters(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            IEnumerable<SeguimientoHistoricoDTO> list = new List<SeguimientoHistoricoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 17);
                parameters.Add("nIdCompania", SeguimientoFiltros.nIdCompania);
                parameters.Add("nIdEmpleado", SeguimientoFiltros.nIdEmpleado);
                parameters.Add("nIdTipoDocumento", SeguimientoFiltros.nIdTipoDocumento);
                parameters.Add("sDocumento", SeguimientoFiltros.sDocumento);
                parameters.Add("nIdProyecto", SeguimientoFiltros.nIdProyecto);
                parameters.Add("nIdSector", SeguimientoFiltros.nIdSector);
                parameters.Add("nIdManzana", SeguimientoFiltros.nIdManzana);
                parameters.Add("nIdLote", SeguimientoFiltros.nIdLote);
                parameters.Add("fechaInicio", SeguimientoFiltros.fechaInicio);
                parameters.Add("fechaFin", SeguimientoFiltros.fechaFin);

                list = await connection.QueryAsync<SeguimientoHistoricoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 18);
                parameters.Add("nIdManzana", nIdManzana);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectTipoDocumento()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 19);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SeguimientoDTO>> getSeguimiento(int nIdSeguimiento)
        {
            IEnumerable<SeguimientoDTO> list = new List<SeguimientoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 20);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<SeguimientoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SeguimientoCuotaDTO>> getListSeguimientoCuotaBySeguimiento(int nIdSeguimiento)
        {
            IEnumerable<SeguimientoCuotaDTO> list = new List<SeguimientoCuotaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 21);
                parameters.Add("nIdSeguimiento", nIdSeguimiento);

                list = await connection.QueryAsync<SeguimientoCuotaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getInfoContactoByMedio(int nIdCliente, int nIdMedio)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 22);
                parameters.Add("nIdCliente", nIdCliente);
                parameters.Add("nIdMedio", nIdMedio);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<SelectDTO>> getSelectAsesorSeguimiento(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 23);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return list.ToList();
        }

        public async Task<SqlRspDTO> InsAgendamientoByFechaCompromiso(AgendamientoDTO agendamiento)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 24);
                parameters.Add("nIdAgendamiento", agendamiento.nIdAgendamiento);
                parameters.Add("nIdSeguimientoCuota", agendamiento.nIdSeguimientoCuota);
                parameters.Add("nIdTipoAgendamiento", agendamiento.nIdTipoAgendamiento);
                parameters.Add("nIdSeguimiento", agendamiento.nIdSeguimiento);
                parameters.Add("nIdCliente", agendamiento.nIdCliente);
                parameters.Add("nIdEmpleado", agendamiento.nIdEmpleado);
                parameters.Add("dFechaPrev", agendamiento.dFechaPrev);
                parameters.Add("dFecha", agendamiento.dFecha);
                parameters.Add("sDescripcion", agendamiento.sDescripcion);
                parameters.Add("nIdUsuario_crea", agendamiento.nIdUsuario_crea);
                parameters.Add("nIdUsuario_mod", agendamiento.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }   
            return res;
        }


        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoVentasByFilters(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            IEnumerable<SeguimientoHistoricoDTO> list = new List<SeguimientoHistoricoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 25);
                parameters.Add("nIdCompania", SeguimientoFiltros.nIdCompania);
                parameters.Add("nIdEmpleado", SeguimientoFiltros.nIdEmpleado);
                parameters.Add("nIdTipoDocumento", SeguimientoFiltros.nIdTipoDocumento);
                parameters.Add("sDocumento", SeguimientoFiltros.sDocumento);
                parameters.Add("fechaInicio", SeguimientoFiltros.fechaInicio);
                parameters.Add("fechaFin", SeguimientoFiltros.fechaFin);

                list = await connection.QueryAsync<SeguimientoHistoricoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


        public async Task<IList<SeguimientoHistoricoDTO>> getListSeguimientoAtencionCliente(SeguimientoFiltrosDTO SeguimientoFiltros)
        {
            IEnumerable<SeguimientoHistoricoDTO> list = new List<SeguimientoHistoricoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[cobranzas].[pa_gestion_seguimiento]", 26);
                parameters.Add("nIdCompania", SeguimientoFiltros.nIdCompania);
                parameters.Add("nIdUsuario", SeguimientoFiltros.nIdUsuario);
                parameters.Add("nIdCliente", SeguimientoFiltros.nIdCliente);

                list = await connection.QueryAsync<SeguimientoHistoricoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }


    }
}
