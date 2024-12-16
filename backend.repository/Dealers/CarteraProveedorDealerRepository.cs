using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;
using backend.repository.Interfaces.Dealers;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace backend.repository.Dealers
{
    public class CarteraProveedorDealerRepository : ICarteraProveedorDealerRepository
    {
        private readonly IConfiguration _configuration;

        public CarteraProveedorDealerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CarteraProveedorDealerDTO>> getListCarteraProveedorDealer(FilterCarteraDTO filter)
        {
            IEnumerable<CarteraProveedorDealerDTO> list = new List<CarteraProveedorDealerDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_cartera_proveedor]", 1);
                parameters.Add("nIdCompania", filter.nIdCompania);
                parameters.Add("nIdAsesor", filter.nIdAsesor);
                parameters.Add("nIdProveedor", filter.nIdProveedor);
                parameters.Add("nIdUsuario", filter.nIdUsuario);
                parameters.Add("dFechaIni", filter.dFechaIni);
                parameters.Add("dFechaFin", filter.dFechaFin);
                parameters.Add("PageNumber", filter.PageNumber);
                parameters.Add("RowspPage", filter.RowspPage);

                list = await connection.QueryAsync<CarteraProveedorDealerDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> posAsignarCartera(AsignarCarteraDTO proveedor)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[dealers].[pa_cartera_proveedor]", 2);
                parameters.Add("nIdCompania", proveedor.nIdCompania);
                parameters.Add("nIdProveedor", proveedor.nIdProveedor);
                parameters.Add("nIdUsuario", proveedor.nIdUsuario);
                parameters.Add("nIdCliente", proveedor.nIdCliente);
                parameters.Add("nIdAsesor", proveedor.nIdAsesor);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}