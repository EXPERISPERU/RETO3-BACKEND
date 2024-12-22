using System.Text;
using System.Text.Json;
using backend.domain;
using Newtonsoft.Json;

namespace backend.services.Utils
{
    public class UltraMsg
    {
        private string sUltraMsgUrl;
        private string sUltraMsgInstance;
        private string sUltraMsgToken;

        public UltraMsg(IConfiguration configuration)
        {
            sUltraMsgUrl = configuration["EfacConfig:url"];
            sUltraMsgInstance = configuration["EfacConfig:instance"];
            sUltraMsgToken = configuration["EfacConfig:token"];
        }

        private string estructurarMensaje(ClienteDTO cliente, NotificacionDTO notificacion)
        {
            return "";
        }

        private Dictionary<string, string> estructurarEnvio(ClienteDTO cliente, NotificacionDTO notificacion, string mensaje)
        {
            return new Dictionary<string, string>
            {
                { "token", sUltraMsgToken ?? string.Empty },
                { "to", cliente?.sCelular ?? cliente?.sCelular2 ?? string.Empty },
                { "mensaje", mensaje },
                { "titulo", notificacion?.sTipoNotificacion ?? "Sin Título" }
            };
        }

        private string estructurarUrl()
        {
            var sUrlEndpoint = "/message/chat";

            return sUltraMsgUrl + sUltraMsgInstance + sUrlEndpoint;
        }

        public async Task<NotificacionResponseDTO> enviarNotificacion(NotificacionDTO notificacion, ClienteDTO cliente)
        {
            try
            {
                string mensaje = estructurarMensaje(cliente, notificacion);

                var body = estructurarEnvio(cliente, notificacion, mensaje);

                var requestBody = System.Text.Json.JsonSerializer.Serialize(body);
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");


                string urlFinal = estructurarUrl();

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(urlFinal, content);
                    int status = (int)response.StatusCode;

                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<NotificacionResponseDTO>(res);

                    if (status == 200)
                    {
                        return result;
                    }
                    else
                    {
                        return new NotificacionResponseDTO() { sent = (bool)result?.sent, message = result?.message, id = (int)result?.id };
                    }
                }
            }
            catch (Exception ex)
            {
                return new NotificacionResponseDTO() { sent = false, error = ex?.Message };
            }
        }
    }
}
