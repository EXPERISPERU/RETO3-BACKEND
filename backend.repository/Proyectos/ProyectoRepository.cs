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
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly IConfiguration _configuration;

        public ProyectoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProyectoDTO>> getListProyectoByCompania(int nIdCompania)
        {
            IEnumerable<ProyectoDTO> list = new List<ProyectoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_proyecto]", 1);
                parameters.Add("nIdCompania", nIdCompania);

                list = await connection.QueryAsync<ProyectoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<ProyectoDTO> getProyectoByID(int nIdProyecto)
        {
            ProyectoDTO res = new ProyectoDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_proyecto]", 2);
                parameters.Add("nIdProyecto", nIdProyecto);

                res = await connection.QuerySingleAsync<ProyectoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getSelectCompanias()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_proyecto]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsProyecto(ProyectoDTO proyecto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_proyecto]", 4);
                parameters.Add("nIdCompania", proyecto.nIdCompania);
                parameters.Add("sNombre", proyecto.sNombre);
                parameters.Add("sDescripcion", proyecto.sDescripcion);
                parameters.Add("nIdUbigeo", proyecto.nIdUbigeo);
                parameters.Add("nLatitud", proyecto.nLatitud);
                parameters.Add("nLongitud", proyecto.nLongitud);
                //parameters.Add("bIGV", proyecto.bIGV);
                parameters.Add("nSectores", proyecto.nSectores);
                parameters.Add("nManzanas", proyecto.nManzanas);
                parameters.Add("nLotes", proyecto.nLotes);
                parameters.Add("nIdUsuario_crea", proyecto.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<SqlRspDTO> UpdProyecto(ProyectoDTO proyecto)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[proyectos].[pa_proyecto]", 5);
                parameters.Add("nIdProyecto", proyecto.nIdProyecto);
                parameters.Add("sNombre", proyecto.sNombre);
                parameters.Add("sDescripcion", proyecto.sDescripcion);
                parameters.Add("nIdUbigeo", proyecto.nIdUbigeo);
                parameters.Add("nLatitud", proyecto.nLatitud);
                parameters.Add("nLongitud", proyecto.nLongitud);
                //parameters.Add("bIGV", proyecto.bIGV);
                parameters.Add("nSectores", proyecto.nSectores);
                parameters.Add("nManzanas", proyecto.nManzanas);
                parameters.Add("nLotes", proyecto.nLotes);
                parameters.Add("nIdUsuario_mod", proyecto.nIdUsuario_mod);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }
    }
}
