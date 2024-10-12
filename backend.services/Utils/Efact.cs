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

        private EfactComprobanteDTO comprobanteEfact(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet) {

            EfactComprobanteDTO efactComprobante = new EfactComprobanteDTO();

            efactComprobante._D = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
            efactComprobante._S = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            efactComprobante._B = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            efactComprobante._E = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            efactComprobante.Invoice = new List<Invoice>();

            IdentifierContentDTO icUBLVersionID = new IdentifierContentDTO() { IdentifierContent = "2.1" };
            IdentifierContentDTO icCustomizationID = new IdentifierContentDTO() { IdentifierContent = "2.0" };
            IdentifierContentDTO icID = new IdentifierContentDTO() { IdentifierContent = comprobante.sComprobante };
            DateContentDTO dateContent = new DateContentDTO { DateContent = comprobante.dFecha_crea.ToString("yyyy-MM-dd") };
            DateTimeContentDTO dateTimeContent = new DateTimeContentDTO { DateTimeContent = comprobante.dFecha_crea.ToString("hh:mm:ss") };
            InvoiceTypeCodeDTO invoiceTypeCode = new InvoiceTypeCodeDTO()
            {
                CodeContent = new Sunat().TipoDocumento(comprobante.sCodigoTipoComprobante),
                CodeListNameText = "Tipo de Documento",
                CodeListSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51",
                CodeListIdentifier = "0101",
                CodeNameText = "Tipo de Operacion",
                CodeListUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01",
                CodeListAgencyNameText = "PE:SUNAT"
            };

            NoteDTO noteMontoLetras = new NoteDTO() { 
                TextContent = new NumerosLetras().sConvertir(comprobante.nValorTotal)
                ,LanguageLocaleIdentifier = "1000"
            };

            NoteDTO noteContacto = new NoteDTO()
            {
                TextContent = "Celular: 967 283 715%5D Fijo: 694-8518"
            };

            return efactComprobante;
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
                EfactComprobanteDTO comprobanteEfact = this.comprobanteEfact(comprobante, comprobanteDet);

                string tipoDocumento = new Sunat().TipoDocumento(comprobante.sCodigoTipoComprobante);
                string nombreDocumento = comprobante.sRUCCompania + tipoDocumento + comprobante.sSerie + comprobante.nCorrelativo + ".json";
                // TODO: meter compronbanteEfect en el archivo
                // almacenar el archivo en una ruta temporal
                string filePath = Path.Combine("tmp", nombreDocumento);

                string urlFinal = eFactUrlBase + eFactUrlDocument;
                var authResponse = await this.eFactGetToken();

                //CONSUMIR SERVICIO PARA ENVIAR ARCHIVO
                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.access_token);

                //    var content = new MultipartFormDataContent();

                //    byte[] xmlBytes = await File.ReadAllBytesAsync(filePath);
                //    var fileContent = new ByteArrayContent(xmlBytes);
                //    fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                //    content.Add(fileContent, "file", nombreDocumento);

                //    var response = await httpClient.PostAsync(urlFinal, content);
                //    int status = (int) response.StatusCode;

                //    string res = await response.Content.ReadAsStringAsync();
                //    var result = JsonConvert.DeserializeObject<efactResponseDTO>(res);

                //    if (status == 200)
                //    {
                //        return result;
                //    }
                //    else 
                //    {
                //        throw new Exception(result.description);
                //    }
                //}
                return new efactResponseDTO() { code = "BACKEND", description = "PRUEBAS" };
            }
            catch (Exception ex)
            {
                return new efactResponseDTO() { code = "BACKEND" , description = ex.Message }; 
            }
        }
    }
}
