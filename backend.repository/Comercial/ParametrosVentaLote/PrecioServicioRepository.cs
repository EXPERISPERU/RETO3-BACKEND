using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Comercial.ParametrosVentaLote
{
    public class PrecioServicioRepository : IPrecioServicioRepository
    {
        private readonly IConfiguration _configuration;

        public PrecioServicioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<PrecioServicioDTO>> getListPrecioServicioGeneral()
        {
            IEnumerable<PrecioServicioDTO> list = new List<PrecioServicioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 1);

                list = await connection.QueryAsync<PrecioServicioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<PrecioServicioDTO>> getListPrecioServicioEspecifica()
        {
            IEnumerable<PrecioServicioDTO> list = new List<PrecioServicioDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 2);

                list = await connection.QueryAsync<PrecioServicioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<PrecioServicioDTO> getPrecioServicioByID(int nIdPrecioServicio)
        {
            PrecioServicioDTO resp = new PrecioServicioDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 3);
                parameters.Add("nIdPrecioServicio", nIdPrecioServicio);

                resp = await connection.QuerySingleOrDefaultAsync<PrecioServicioDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return resp;
        }

        public async Task<IList<SelectDTO>> getSelectItem()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 4);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 5);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 6);
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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 7);
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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 8);
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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 9);
                parameters.Add("nIdManzana", nIdManzana);

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
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 10);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }
        public async Task<SqlRspDTO> InsPrecioServicio(PrecioServicioDTO precioServicio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 11);
                parameters.Add("nIdItem", precioServicio.nIdItem);
                parameters.Add("nIdProyecto", precioServicio.nIdProyecto);
                parameters.Add("nIdLote", precioServicio.nIdLote);
                parameters.Add("nValor", precioServicio.nValor);
                parameters.Add("nIdMoneda", precioServicio.nIdMoneda);
                parameters.Add("dFechaIni", precioServicio.dFechaIni);
                parameters.Add("dFechaFin", precioServicio.dFechaFin);
                parameters.Add("bActivo", precioServicio.bActivo);
                parameters.Add("nIdUsuario_crea", precioServicio.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdPrecioServicio(PrecioServicioDTO precioServicio)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_precio_servicio]", 12);
                parameters.Add("nIdPrecioServicio", precioServicio.nIdPrecioServicio);
                parameters.Add("dFechaIni", precioServicio.dFechaIni);
                parameters.Add("dFechaFin", precioServicio.dFechaFin);
                parameters.Add("bActivo", precioServicio.bActivo);
                parameters.Add("nIdUsuario_mod", precioServicio.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
