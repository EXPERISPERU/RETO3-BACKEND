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
using backend.repository.Interfaces.Comercial.Precio;

namespace backend.repository.Comercial.Precio
{
    public class ListaPrecioRepository : IListaPrecioRepository
    {
        private readonly IConfiguration _configuration;

        public ListaPrecioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ListaPrecioDTO>> getListListaPrecio()
        {
            IEnumerable<ListaPrecioDTO> list = new List<ListaPrecioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 1);

                list = await connection.QueryAsync<ListaPrecioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ListaPrecioDTO> getListaPrecio(int nIdListaPrecio)
        {
            ListaPrecioDTO resp = new ListaPrecioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 2);
                parameters.Add("nIdListaPrecio", nIdListaPrecio);

                resp = await connection.QuerySingleOrDefaultAsync<ListaPrecioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectTipoListaPrecio()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 5);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsListaPrecio(ListaPrecioDTO listaPrecio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 6);
                parameters.Add("nIdTipo", listaPrecio.nIdTipo);
                parameters.Add("nIdCompania", listaPrecio.nIdCompania);
                parameters.Add("nIdOficina", listaPrecio.nIdOficina);
                parameters.Add("dFechaIni", listaPrecio.dFechaIni);
                parameters.Add("dFechaFin", listaPrecio.dFechaFin);
                parameters.Add("bActivo", listaPrecio.bActivo);
                parameters.Add("nIdUsuario_crea", listaPrecio.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdListaPrecio(ListaPrecioDTO listaPrecio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_lista_precio]", 7);
                parameters.Add("nIdListaPrecio", listaPrecio.nIdListaPrecio);
                parameters.Add("nIdCompania", listaPrecio.nIdCompania);
                parameters.Add("nIdOficina", listaPrecio.nIdOficina);
                parameters.Add("dFechaIni", listaPrecio.dFechaIni);
                parameters.Add("dFechaFin", listaPrecio.dFechaFin);
                parameters.Add("bActivo", listaPrecio.bActivo);
                parameters.Add("nIdUsuario_mod", listaPrecio.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
