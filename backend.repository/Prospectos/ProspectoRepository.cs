using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using backend.repository.Interfaces.Prospectos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Prospectos
{
    public class ProspectoRepository : IProspectoRepository
    {
        private readonly IConfiguration _configuration;

        public ProspectoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IList<ProspectoDTO>> getListProspectoByIdUsuario(int nIdUsuario)
        {
            IEnumerable<ProspectoDTO> list = new List<ProspectoDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_prospectos]", 1);
                parameters.Add("nIdUsuario", nIdUsuario);

                list = await connection.QueryAsync<ProspectoDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsProspecto(ProspectoDTO prospecto)
        {
            SqlRspDTO res = new SqlRspDTO();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_prospectos]", 2);

                parameters.Add("nIdProspecto", prospecto.nIdProspecto);
                parameters.Add("nIdCompania", prospecto.nIdCompania);
                parameters.Add("sPriNombre", prospecto.sPriNombre);
                parameters.Add("sSegNombre", prospecto.sSegNombre);
                parameters.Add("sApePaterno", prospecto.sApePaterno);
                parameters.Add("sApeMaterno", prospecto.sApeMaterno);
                parameters.Add("sNombreCompleto", prospecto.sNombreCompleto);
                //parameters.Add("@dFechaNac", prospecto.dFechaNac);
                //parameters.Add("@nIdUbigeoNac", prospecto.nIdUbigeoNac);
                //parameters.Add("@nIdGenero", prospecto.nIdGenero);
                //parameters.Add("@nIdEstadoCivil", prospecto.nIdEstadoCivil);
                parameters.Add("@sCorreo", prospecto.sCorreo);
                parameters.Add("@sCelular", prospecto.sCelular);
                parameters.Add("@sCelular2", prospecto.sCelular2);
                parameters.Add("@sTelefono", prospecto.sTelefono);
                parameters.Add("bActivo", prospecto.bActivo);
                parameters.Add("nIdUsuario_crea", prospecto.nIdUsuario_crea);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_prospectos]", 3);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            IEnumerable<SelectDTO> list = new List<SelectDTO>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_prospectos]", 4);

                list = await connection.QueryAsync<SelectDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return list.ToList();
        }

        public async Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[comercial].[pa_prospectos]", 5);
                parameters.Add("nIdCompania", persona.nIdCompania);
                parameters.Add("nIdPersona", persona.nIdPersona);
                parameters.Add("sPriNombre", persona.sPriNombre);
                parameters.Add("sSegNombre", persona.sSegNombre);
                parameters.Add("sApePaterno", persona.sApePaterno);
                parameters.Add("sApeMaterno", persona.sApeMaterno);
                parameters.Add("sNombreCompleto", persona.sNombreCompleto);
                parameters.Add("dFechaNac", persona.dFechaNac);
                parameters.Add("nIdUbigeoNac", persona.nIdUbigeoNac);
                parameters.Add("nIdGenero", persona.nIdGenero);
                parameters.Add("nIdEstadoCivil", persona.nIdEstadoCivil);
                parameters.Add("sCorreo", persona.sCorreo);
                parameters.Add("sCelular", persona.sCelular);
                parameters.Add("sDNI", persona.sDNI);
                parameters.Add("sCE", persona.sCE);
                parameters.Add("sRUC", persona.sRUC);
                parameters.Add("nIdDireccion", persona.nIdDireccion);
                parameters.Add("sDireccion", persona.sDireccion);
                parameters.Add("nIdUbigeoDir", persona.nIdUbigeoDir);
                parameters.Add("nIdUsuario_crea", persona.nIdUsuario_crea);
                parameters.Add("nIdProspecto", persona.nIdProspecto);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

            return res;
        }

    }
}
