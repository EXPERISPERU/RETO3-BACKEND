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
    public class OficinaRepository : IOficinaRepository
    {
        private readonly IConfiguration _configuration;

        public OficinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<OficinaDTO>> getListOficinaByCompania(int nIdCompania)
        {
            IEnumerable<OficinaDTO> list = new List<OficinaDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<OficinaDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getTipoOficina()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 2);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListOficinaPByTipo(int nIdCompania, int nIdTipoOficina)
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 3);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdTipoOficina", nIdTipoOficina);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsOficina(OficinaDTO oficina)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 4);
                parameters.Add("nIdOficinaP", oficina.nIdOficinaP);
                parameters.Add("nIdCompania", oficina.nIdCompania);
                parameters.Add("nIdUbigeo", oficina.nIdUbigeo);
                parameters.Add("sDireccion", oficina.sDireccion);
                parameters.Add("sOficina", oficina.sOficina);
                parameters.Add("sDescripcion", oficina.sDescripcion);
                parameters.Add("nIdTipoOficina", oficina.nIdTipoOficina);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdOficina(OficinaDTO oficina)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[maestros].[pa_oficina]", 5);
                parameters.Add("nIdOficina", oficina.nIdOficina);
                parameters.Add("nIdOficinaP", oficina.nIdOficinaP);
                parameters.Add("nIdCompania", oficina.nIdCompania);
                parameters.Add("nIdUbigeo", oficina.nIdUbigeo);
                parameters.Add("sDireccion", oficina.sDireccion);
                parameters.Add("sOficina", oficina.sOficina);
                parameters.Add("sDescripcion", oficina.sDescripcion);
                parameters.Add("nIdTipoOficina", oficina.nIdTipoOficina);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
