using backend.domain;
using backend.repository.Interfaces.Contacto;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

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

                SendEmailOutlook("bstrada4@gmail.com", "Prueba", "Cuerpo del correo");
            }
            return res;
        }

        public void SendEmailGmail(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            String usermail = "bstrada4@gmail.com";//this._configuration["usuariogmail"];
            String passwordmail = "Boris@@2023"; // this._configuration["passwordgmail"];

            mail.From = new MailAddress(usermail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = "smtp.gmail.com"; // this._configuration["hostGmail"];
            int port = int.Parse(this._configuration["portGmail"]);
            bool ssl = bool.Parse(this._configuration["sslGmail"]);
            bool defaultcreadentials = bool.Parse(this._configuration["defaultcredentialsGmail"]);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.Host = "smtp.gmail.com"; // smtpserver;
            smtpClient.Port = 587; // port;
            smtpClient.EnableSsl = true; // ssl;
            smtpClient.UseDefaultCredentials = false; //defaultcreadentials;


            NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }


        public void SendEmailOutlook(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            String usermail = this._configuration["usuariooutlook"];
            String passwordmail = this._configuration["passwordoutlook"];

            mail.From = new MailAddress(usermail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = this._configuration["host"];
            int port = int.Parse(this._configuration["port"]);
            bool ssl = bool.Parse(this._configuration["ssl"]);
            bool defaultcreadentials = bool.Parse(this._configuration["defaultcredentials"]);

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = smtpserver;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultcreadentials;


            NetworkCredential usercredential = new NetworkCredential(usermail, passwordmail);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }
    }


}
