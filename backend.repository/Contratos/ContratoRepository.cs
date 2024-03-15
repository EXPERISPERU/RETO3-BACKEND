using backend.domain;
using backend.repository.Interfaces.Contratos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Contratos
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly IConfiguration _configuration;

        public ContratoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 1);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 2);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 3);
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
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 4);
                parameters.Add("nIdSector", nIdSector);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 5);
                parameters.Add("nIdManzana", nIdManzana);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 6);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectEstadoContrato()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 7);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ContratoDTO>> getListContratoByFilters(ContratoFiltrosDTO contratoFiltros)
        {
            IEnumerable<ContratoDTO> list = new List<ContratoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 8);
                parameters.Add("nIdCompania", contratoFiltros.nIdCompania);
                parameters.Add("nIdProyecto", contratoFiltros.nIdProyecto);
                parameters.Add("nIdSector", contratoFiltros.nIdSector);
                parameters.Add("nIdManzana", contratoFiltros.nIdManzana);
                parameters.Add("nIdLote", contratoFiltros.nIdLote);
                parameters.Add("sDocumento", contratoFiltros.sDocumento);
                parameters.Add("nIdCondicionPago", contratoFiltros.nIdCondicionPago);
                parameters.Add("nIdEstado", contratoFiltros.nIdEstado);

                list = await connection.QueryAsync<ContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ContratoDTO> getContratoById(int nIdContrato)
        {
            ContratoDTO res = new ContratoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 9);
                parameters.Add("nIdContrato", nIdContrato);

                res = await connection.QuerySingleAsync<ContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<CronogramaDTO>> getListCronogramaByContrato(int nIdContrato)
        {
            IEnumerable<CronogramaDTO> list = new List<CronogramaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 10);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<CronogramaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<OrdenPagoPreContratoDTO>> getListOrdenPagoByContrato(int nIdContrato)
        {
            IEnumerable<OrdenPagoPreContratoDTO> list = new List<OrdenPagoPreContratoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 11);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<OrdenPagoPreContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ContratoByIdClientDTO>> getContratosByIdCliente(int nIdCliente)
        {
            IEnumerable<ContratoByIdClientDTO> list = new List<ContratoByIdClientDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 12);
                parameters.Add("nIdCliente", nIdCliente);

                list = await connection.QueryAsync<ContratoByIdClientDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ListInicialByContrato>> getListInicialByContrato(int nIdContrato)
        {
            IEnumerable<ListInicialByContrato> list = new List<ListInicialByContrato>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 13);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<ListInicialByContrato>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<DocumentosContratoDTO>> getListDocumentosByContrato(int nIdContrato)
        {
            IEnumerable<DocumentosContratoDTO> list = new List<DocumentosContratoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 14);
                parameters.Add("nIdContrato", nIdContrato);

                list = await connection.QueryAsync<DocumentosContratoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<BeneficiarioClienteDTO> getConyugueByCliente(int nIdCliente)
        {
            BeneficiarioClienteDTO res = new BeneficiarioClienteDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 15);
                parameters.Add("nIdCliente", nIdCliente);

                res = await connection.QuerySingleOrDefaultAsync<BeneficiarioClienteDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdConyugueContrato(UpdConyugueDTO updConyugue)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 16);
                parameters.Add("nIdContrato", updConyugue.nIdContrato);
                parameters.Add("nIdBeneficiario", updConyugue.nIdBeneficiario);
                parameters.Add("nIdUsuario", updConyugue.nIdUsuario);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdRetirarConyugueContrato(UpdConyugueDTO updConyugue)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 17);
                parameters.Add("nIdContrato", updConyugue.nIdContrato);
                parameters.Add("nIdUsuario", updConyugue.nIdUsuario);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<string> getFormatoContratoById(int nIdFormato)
        {
            string res = "";

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 18);
                parameters.Add("nIdFormato", nIdFormato);

                res = await connection.QuerySingleOrDefaultAsync<string>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdFirmaContrato(UpdFirmaContratoDTO updfirma)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 19);
                parameters.Add("nIdContrato", updfirma.nIdContrato);
                parameters.Add("nIdUsuario", updfirma.nIdUsuario);
                parameters.Add("sFirma", updfirma.sFirma);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdFirmaConyugueContrato(UpdFirmaContratoDTO updfirma)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contratos].[pa_contratos]", 20);
                parameters.Add("nIdContrato", updfirma.nIdContrato);
                parameters.Add("nIdUsuario", updfirma.nIdUsuario);
                parameters.Add("sFirma", updfirma.sFirma);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
