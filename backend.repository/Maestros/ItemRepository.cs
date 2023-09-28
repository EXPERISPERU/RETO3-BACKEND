using backend.domain;
using backend.repository.Interfaces.Maestros;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace backend.repository.Maestros
{
    public class ItemRepository : IItemRepository
    {
        private readonly IConfiguration _configuration;

        public ItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ItemDTO>> getListItem()
        {
            IEnumerable<ItemDTO> list = new List<ItemDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item]", 1);

                list = await connection.QueryAsync<ItemDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsItem(ItemDTO item)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item]", 2);
                parameters.Add("sItem", item.sItem);
                parameters.Add("sDescripcion", item.sDescripcion);
                parameters.Add("nIdTipo", item.nIdTipo);
                parameters.Add("nIdUsuario_crea", item.nIdUsuario_crea);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }


        public async Task<IList<SelectDTO>> getListElementoSistema()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> UpdItem(ItemDTO item)
        {
            SqlRspDTO resp = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_item]", 3);
                parameters.Add("nIdItem", item.nIdItem);
                parameters.Add("sItem", item.sItem);
                parameters.Add("sDescripcion", item.sDescripcion);
                parameters.Add("nIdTipo", item.nIdTipo);
                parameters.Add("bActivo", item.bActivo);
                parameters.Add("nIdUsuario_mod", item.nIdUsuario_mod);

                resp = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return resp;
        }
    }
}