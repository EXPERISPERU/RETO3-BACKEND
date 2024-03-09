using backend.domain;
using backend.repository.Interfaces.Contacto;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace backend.repository.Contacto
{
    public class FormularioContactoRepository : IFormularioContactoRepository
    {
        private readonly IConfiguration _configuration;

        public FormularioContactoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlRspDTO> InsFormularioContactoPortal(FormularioContactoPortalDTO seguimiento)
        {
            SqlRspDTO res = new SqlRspDTO(); ;

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("cnInmobisoft")))
            {
                DynamicParameters parameters = new();
                string storedProcedure = string.Format("{0};{1}", "[contacto].[pa_formulario_contacto]", 1);
                parameters.Add("IdPortal", seguimiento.nIdPortal);
                parameters.Add("Portal", seguimiento.sPortal);
                parameters.Add("URL", seguimiento.sURL);
                parameters.Add("NombreCompleto", seguimiento.sNombreCompleto);
                parameters.Add("DNI", seguimiento.sDNI);
                parameters.Add("Celular", seguimiento.sCelular);
                parameters.Add("Correo", seguimiento.sCorreo);
                parameters.Add("Direccion", seguimiento.sUbicacion);
                parameters.Add("IdTipoSolicitud", seguimiento.nIdTipoSolicitud);
                parameters.Add("TipoSolicitud", seguimiento.sTipoSolicitud);

                res = await connection.QuerySingleAsync<SqlRspDTO>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return res;
        }
    }


}
