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
    public class ItemCompaniaRepository : IItemCompaniaRepository
    {

        private readonly IConfiguration _configuration;

        public ItemCompaniaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ItemCompaniaDTO>> getListConceptoPagoTipoComprobanteByCompania(int nIdCompania)
        {
            IEnumerable<ItemCompaniaDTO> list = new List<ItemCompaniaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ItemCompaniaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ItemDTO>> getListMaestroConceptoPagos()
        {
            IEnumerable<ItemDTO> list = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 2);

                list = await connection.QueryAsync<ItemDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<ElementoSistemaDTO>> getListMaestroTipoComprobantes()
        {
            IEnumerable<ElementoSistemaDTO> list = new List<ElementoSistemaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 3);

                list = await connection.QueryAsync<ElementoSistemaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsItemCompania(ItemCompaniaDTO itemCompaniaDTO)
        {

            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 4);
                parameters.Add("nIdCompania", itemCompaniaDTO.nIdCompania);
                parameters.Add("nIdItem", itemCompaniaDTO.nIdItem);
                parameters.Add("nIdComprobante", itemCompaniaDTO.nIdComprobante);
                parameters.Add("bActivo", itemCompaniaDTO.bActivo);
                parameters.Add("nIdUsuario_crea", itemCompaniaDTO.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;

        }

        public async Task<SqlRspDTO> InsItemCompania_Terminologia(ItemCompaniaDTO itemCompaniaDTO)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 5);
                parameters.Add("nIdCompania", itemCompaniaDTO.nIdCompania);
                parameters.Add("nIdItem", itemCompaniaDTO.nIdItem);
                parameters.Add("vTerminologia", itemCompaniaDTO.vTerminologia);
                parameters.Add("nIdUsuario_mod", itemCompaniaDTO.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<ItemCompaniaDTO>> getListConceptoPagoTerminologiaByCompania(int nIdCompania)
        {
            IEnumerable<ItemCompaniaDTO> list = new List<ItemCompaniaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item_compania]", 6);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ItemCompaniaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
    }
}
