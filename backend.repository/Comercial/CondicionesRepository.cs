using backend.domain;
using backend.repository.Interfaces.Comercial;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Comercial
{
    public class CondicionesRepository : ICondicionesRepository
    {
        private readonly IConfiguration _configuration;

        public CondicionesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario)
        {
            IEnumerable<CondicionesDTO> list = new List<CondicionesDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 1);
                parameters.Add("nIdCompania", nIdCompania);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<CondicionesDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 2);
                parameters.Add("nIdCompania", condiciones.nIdCompania);
                parameters.Add("sDescripcion", condiciones.sDescripcion);
                parameters.Add("bActivo", condiciones.bActivo);
                parameters.Add("nIdUsuario_crea", condiciones.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 3);
                parameters.Add("nIdCondicion", condiciones.nIdCondicion);
                parameters.Add("sDescripcion", condiciones.sDescripcion);
                parameters.Add("bActivo", condiciones.bActivo);
                parameters.Add("nIdUsuario_mod", condiciones.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> SelectTipoCondiciones()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 4);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<CondicionesDetDTO>> getListCondicionesDetByTipo(int nIdCondicion, int nIdTipoCondicionDet)
        {
            IEnumerable<CondicionesDetDTO> res = new List<CondicionesDetDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 5);
                parameters.Add("nIdCondicion", nIdCondicion);
                parameters.Add("nIdTipoCondicionDet", nIdTipoCondicionDet);

                res = await connection.QueryAsync<CondicionesDetDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<CondicionesDetDTO> getCondicionesDetById(int nIdCondicionesDet)
        {
            CondicionesDetDTO res = new CondicionesDetDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 6);
                parameters.Add("nIdCondicionesDet", nIdCondicionesDet);

                res = await connection.QuerySingleAsync<CondicionesDetDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> SelectProyectoByCompania(int nIdCompania)
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 7);
                parameters.Add("nIdCompania", nIdCompania);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectSectorByProyecto(int nIdProyecto)
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 8);
                parameters.Add("nIdProyecto", nIdProyecto);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectManzanaBySector(int nIdSector)
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 9);
                parameters.Add("nIdSector", nIdSector);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectLoteByManzana(int nIdManzana)
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 10);
                parameters.Add("nIdManzana", nIdManzana);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectGrupoInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 11);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectUbicacionInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 12);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectTerrenoInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 13);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectZonificacionInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 14);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectDescripcionInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 15);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectColorInmueble()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 16);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectTipoFinanciamiento()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 17);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectCuotaLote()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 18);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectInicial()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 19);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<IList<SelectDTO>> SelectDescuento()
        {
            IEnumerable<SelectDTO> res = new List<SelectDTO>(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 20);

                res = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res.ToList();
        }

        public async Task<SqlRspDTO> InsCondicionesDet(CondicionesDetDTO condicionesDet)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 21);
                parameters.Add("nIdCondicion", condicionesDet.nIdCondicion);
                parameters.Add("nIdTipoCondicionDet", condicionesDet.nIdTipoCondicionDet);
                parameters.Add("nIdProyecto", condicionesDet.nIdProyecto);
                parameters.Add("nIdSector", condicionesDet.nIdSector);
                parameters.Add("nIdManzana", condicionesDet.nIdManzana);
                parameters.Add("nIdLote", condicionesDet.nIdLote);
                parameters.Add("nIdGrupo", condicionesDet.nIdGrupo);
                parameters.Add("nIdUbicacion", condicionesDet.nIdUbicacion);
                parameters.Add("nIdTerreno", condicionesDet.nIdTerreno);
                parameters.Add("nIdZonificacion", condicionesDet.nIdZonificacion);
                parameters.Add("nIdDescripcion", condicionesDet.nIdDescripcion);
                parameters.Add("nIdColor", condicionesDet.nIdColor);
                parameters.Add("nIdTipoFinanciamiento", condicionesDet.nIdTipoFinanciamiento);
                parameters.Add("nIdCuotaLote", condicionesDet.nIdCuotaLote);
                parameters.Add("nIdInicialLote", condicionesDet.nIdInicialLote);
                parameters.Add("nIdDescuentoLote", condicionesDet.nIdDescuentoLote);
                parameters.Add("bActivo", condicionesDet.bActivo);
                parameters.Add("nIdUsuario_crea", condicionesDet.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdCondicionesDet(CondicionesDetDTO condicionesDet)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_condiciones]", 22);
                parameters.Add("nIdCondicionesDet", condicionesDet.nIdCondicionesDet);
                parameters.Add("nIdProyecto", condicionesDet.nIdProyecto);
                parameters.Add("nIdSector", condicionesDet.nIdSector);
                parameters.Add("nIdManzana", condicionesDet.nIdManzana);
                parameters.Add("nIdLote", condicionesDet.nIdLote);
                parameters.Add("nIdGrupo", condicionesDet.nIdGrupo);
                parameters.Add("nIdUbicacion", condicionesDet.nIdUbicacion);
                parameters.Add("nIdTerreno", condicionesDet.nIdTerreno);
                parameters.Add("nIdZonificacion", condicionesDet.nIdZonificacion);
                parameters.Add("nIdDescripcion", condicionesDet.nIdDescripcion);
                parameters.Add("nIdColor", condicionesDet.nIdColor);
                parameters.Add("nIdTipoFinanciamiento", condicionesDet.nIdTipoFinanciamiento);
                parameters.Add("nIdCuotaLote", condicionesDet.nIdCuotaLote);
                parameters.Add("nIdInicialLote", condicionesDet.nIdInicialLote);
                parameters.Add("nIdDescuentoLote", condicionesDet.nIdDescuentoLote);
                parameters.Add("bActivo", condicionesDet.bActivo);
                parameters.Add("nIdUsuario_mod", condicionesDet.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
