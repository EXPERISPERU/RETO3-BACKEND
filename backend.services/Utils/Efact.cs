using backend.domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;

namespace backend.services.Utils
{
    public class Efact
    {
        private string eFactUrlBase;
        private string eFactUser;
        private string eFactPassword;
        private string eFactUrlToken;
        private string eFactUrlDocument;

        public Efact(IConfiguration configuration)
        {
            eFactUrlBase = configuration["EfacConfig:url"];
            eFactUser = configuration["EfacConfig:username"];
            eFactPassword = configuration["EfacConfig:password"];
            eFactUrlToken = configuration["EfacConfig:urlToken"];
            eFactUrlDocument = configuration["EfacConfig:urlDocument"];
        }

        private async Task<efactAuthResponseDTO> eFactGetToken()
        {
            try
            {
                string urlFinal = eFactUrlBase + eFactUrlToken;
                using (var httpClient = new HttpClient())
                {
                    string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("client:secret"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    var values = new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "username", eFactUser },
                        { "password", eFactPassword }
                    };

                    var content = new FormUrlEncodedContent(values);

                    var result = await httpClient.PostAsync(urlFinal, content).Result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<efactAuthResponseDTO>(result);
                    
                    return response;
                }
            }
            catch (Exception ex)
            {
                return new efactAuthResponseDTO() { error = "BACKEN ERROR", error_description = ex.Message };
            }
        }

        public async Task<efactResponseDTO> GenerarDocumento(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet)
        {
            try
            {
                string tipoDocumento = new Sunat().TipoDocumento(comprobante.sCodigoTipoComprobante);
                string nombreDocumento = comprobante.sRUCCompania + tipoDocumento + comprobante.sSerie + comprobante.nCorrelativo + ".xml";
                string filePath = Path.Combine("tmp", nombreDocumento);

                string urlFinal = eFactUrlBase + eFactUrlToken;
                var authResponse = await this.eFactGetToken();

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.access_token);

                    var content = new MultipartFormDataContent();

                    byte[] xmlBytes = await File.ReadAllBytesAsync(filePath);
                    var fileContent = new ByteArrayContent(xmlBytes);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                    content.Add(fileContent, "file", nombreDocumento);
                
                    var response = await httpClient.PostAsync(urlFinal, content);
                    int status = (int) response.StatusCode;
                    
                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<efactResponseDTO>(res);

                    if (status == 200)
                    {
                        return result;
                    }
                    else 
                    {
                        throw new Exception(result.description);
                    }
                }
            }
            catch (Exception ex)
            {
                return new efactResponseDTO() { code = "BACKEND" , description = ex.Message }; 
            }
        }
    }
}
