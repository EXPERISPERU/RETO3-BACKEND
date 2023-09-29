using backend.domain;
using backend.repository.Interfaces.Proyectos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Proyectos
{
    public class SectorRepository : ISectorRepository
    {
        private readonly IConfiguration _configuration;

        public SectorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<SelectDTO>> getSelectCompanias()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 1);

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
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 2);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SectorDTO>> getListSectorByProyecto(int nIdProyecto)
        {
            IEnumerable<SectorDTO> list = new List<SectorDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 3);
                parameters.Add("nIdProyecto", nIdProyecto);

                list = await connection.QueryAsync<SectorDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getSelectEstado()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsSector(SectorDTO sector)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 5);
                parameters.Add("nIdProyecto", sector.nIdProyecto);
                parameters.Add("sSector", sector.sSector);
                parameters.Add("nManzanas", sector.nManzanas);
                parameters.Add("nIdEstado", sector.nIdEstado);
                parameters.Add("bActivo", sector.bActivo);
                parameters.Add("nIdUsuario_crea", sector.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdSector(SectorDTO sector)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_sector]", 6);
                parameters.Add("nIdSector", sector.nIdSector);
                parameters.Add("nIdProyecto", sector.nIdProyecto);
                parameters.Add("sSector", sector.sSector);
                parameters.Add("nManzanas", sector.nManzanas);
                parameters.Add("nIdEstado", sector.nIdEstado);
                parameters.Add("bActivo", sector.bActivo);
                parameters.Add("nIdUsuario_mod", sector.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
