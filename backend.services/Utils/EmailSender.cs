using System.Net.Mail;
using System.Net;
using backend.domain;

namespace backend.services.Utils
{
    public class EmailSender
    {
        /* Variables GMAIL */
        private const string usuariogmail = "sistemas@inmobitec.pe";
        private const string passwordGmailApp = "aikn wnka pasz snxe";
        private const string smtpGmail = "smtp.gmail.com";
        private const int portGmail = 587;
        private const bool sslGmail = true;
        private const bool defaultcredentialsGmail = false;

        /* Variables OUTLOOK */
        private const string usuarioOutlook = "";
        private const string passwordOutlook = "";
        private const string smtpOutlook = "smtp-mail.outlook.com";
        private const int portOutlook = 587;
        private const bool sslOutlook = true;
        private const bool defaultcredentialsOutlook = true;

        public void SendEmailGmail(String receptor, String asunto, FormularioContactoPortalDTO mensaje, string formato)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(usuariogmail);
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = formato;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient(smtpGmail);

            smtpClient.Host = smtpGmail;
            smtpClient.Port = portGmail;
            smtpClient.EnableSsl = sslGmail;
            smtpClient.UseDefaultCredentials = defaultcredentialsGmail;

            NetworkCredential usercredential = new NetworkCredential(usuariogmail, passwordGmailApp);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }

        public void SendEmailOutlook(String receptor, String asunto, String mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(usuarioOutlook);
            mail.To.Add(new MailAddress(passwordOutlook));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = smtpOutlook;
            smtpClient.Port = portOutlook;
            smtpClient.EnableSsl = sslOutlook;
            smtpClient.UseDefaultCredentials = defaultcredentialsOutlook;

            NetworkCredential usercredential = new NetworkCredential(usuarioOutlook, passwordOutlook);

            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }
    }
}
