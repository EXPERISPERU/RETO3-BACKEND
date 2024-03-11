using System.Net.Mail;
using System.Net;

namespace backend.services.Utils
{
    public class EmailSender
    {
        /* Variables GMAIL */
        private const string usuariogmail = "";
        private const string passwordgmail = "";
        private const string hostGmail = "smtp.gmail.com";
        private const string portGmail = "587";
        private const string sslGmail = "false";
        private const string defaultcredentialsGmail = "false";

        /* Variables OUTLOOK */
        private const string usuarioOutlook = "";
        private const string passwordOutlook = "";
        private const string hostOutlook = "smtp-mail.outlook.com";
        private const string portOutlook = "587";
        private const string sslOutlook = "true";
        private const string defaultcredentialsOutlook = "true";



        public void SendEmailGmail(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(usuariogmail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = "smtp.gmail.com"; // this._configuration["hostGmail"];
            int port = int.Parse(portGmail);
            bool ssl = bool.Parse(sslGmail);
            bool defaultcreadentials = bool.Parse(defaultcredentialsGmail);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.Host = "smtp.gmail.com"; // smtpserver;
            smtpClient.Port = 587; // port;
            smtpClient.EnableSsl = true; // ssl;
            smtpClient.UseDefaultCredentials = false; //defaultcreadentials;


            NetworkCredential usercredential = new NetworkCredential(usuariogmail, passwordgmail);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }


        public void SendEmailOutlook(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            String usermail = usuarioOutlook;
            String passwordmail = passwordOutlook;

            mail.From = new MailAddress(usermail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            String smtpserver = hostOutlook;
            int port = int.Parse(portOutlook);
            bool ssl = bool.Parse(sslOutlook);
            bool defaultcreadentials = bool.Parse(defaultcredentialsOutlook);

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
