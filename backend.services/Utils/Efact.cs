using backend.domain;
using iText.Kernel.Utils;
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

        private EfactComprobanteDTO comprobanteEfact(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet)
        {

            EfactComprobanteDTO efactComprobante = new EfactComprobanteDTO();

            string[] ubigeoCliente = comprobante.sUbigeoCompania.Split(',');
            string[] ubigeoCompania = comprobante.sUbigeoCompania.Split(',');

            efactComprobante._D = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
            efactComprobante._S = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
            efactComprobante._B = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
            efactComprobante._E = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
            efactComprobante.Invoice = new List<Invoice>();

            var invoice = new Invoice();

            IdentifierContentDTO icUBL = new IdentifierContentDTO() { IdentifierContent = "2.1" };
            invoice.UBLVersionID = new List<IdentifierContentDTO> { icUBL };

            IdentifierContentDTO icCustomizationID = new IdentifierContentDTO() { IdentifierContent = "2.0" };
            invoice.CustomizationID = new List<IdentifierContentDTO> { icCustomizationID };

            IdentifierContentDTO icID = new IdentifierContentDTO() { IdentifierContent = comprobante.sComprobante };
            invoice.ID = new List<IdentifierContentDTO> { icID };

            DateContentDTO dateContent = new DateContentDTO { DateContent = comprobante.dFecha_crea.ToString("yyyy-MM-dd") };
            invoice.IssueDate = new List<DateContentDTO> { dateContent };

            DateTimeContentDTO dateTimeContent = new DateTimeContentDTO { DateTimeContent = comprobante.dFecha_crea.ToString("hh:mm:ss") };
            invoice.IssueTime = new List<DateTimeContentDTO> { dateTimeContent };

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

            invoice.InvoiceTypeCode.Add(invoiceTypeCode);

            List<NoteDTO> notes = new List<NoteDTO>(){
                new NoteDTO(){
                    TextContent = new NumerosLetras().sConvertir(comprobante.nValorTotal)
                    ,
                    LanguageLocaleIdentifier = "1000"
                },
                new NoteDTO()
                {
                    TextContent = "Celular: 967 283 715%5D Fijo: 694-8518"
                },
                new NoteDTO()
                {
                    TextContent = "001101300201068964",
                    LanguageLocaleIdentifier = "BH"
                },
                new NoteDTO()
                {
                    TextContent = "011130000201068964-20",
                    LanguageLocaleIdentifier = "BI"
                },
                new NoteDTO(){
                    TextContent = "0011-0101-02-00641816",
                    LanguageLocaleIdentifier = "BF"
                },
                new NoteDTO(){
                    TextContent = "011 101 00020064181630",
                    LanguageLocaleIdentifier = "BG"
                }
            };

            invoice.Note = notes;

            DocumentCurrencyCodeDTO documentCurrencyCode = new DocumentCurrencyCodeDTO()
            {
                CodeContent = comprobante.sSunatMoneda,
                CodeListIdentifier = "ISO 4217 Alpha",
                CodeListNameText = "Currency",
                CodeListAgencyNameText = "United Nations Economic Commission for Europe"
            };
            invoice.DocumentCurrencyCode.Add(documentCurrencyCode);

            NumericContentDTO numericContent = new NumericContentDTO()
            {
                NumericContent = 1
            };
            invoice.LineCountNumeric.Add(numericContent);

            SignatureDTO signature = new SignatureDTO
            {
                ID = new List<IdentifierContentDTO>()
                        {
                            new IdentifierContentDTO { IdentifierContent = "IDSignature" }
                        },
                SignatoryParty = new List<SignatoryPartyDTO>()
                        {
                            new SignatoryPartyDTO
                            {
                                PartyIdentification = new List<PartyIdentificationDTO>()
                                {
                                    new PartyIdentificationDTO
                                    {
                                        ID = new List<IdentifierContentDTO>()
                                        {
                                            new IdentifierContentDTO { IdentifierContent = comprobante.sRUCCompania }
                                        }
                                    }
                                },
                                PartyName = new List<PartyNameDTO>()
                                {
                                    new PartyNameDTO
                                    {
                                        Name = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = comprobante.sCompania
                                            }
                                        }
                                    }
                                }
                            }
                        },
                DigitalSignatureAttachment = new List<DigitalSignatureAttachmentDTO>()
                        {
                            new DigitalSignatureAttachmentDTO
                            {
                                ExternalReference = new List<ExternalReferenceDTO>()
                                {
                                    new ExternalReferenceDTO
                                    {
                                        URI = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO { TextContent = "IDSignature" }
                                        }
                                    }
                                }
                            }
                        },
            };
            invoice.Signature.Add(signature);

            AccountingPartyDTO accountingSupplierParty = new AccountingPartyDTO()
            {
                Party = new List<PartyDTO>()
                        {
                            new PartyDTO
                            {
                                PartyIdentification = new List<PartyIdentificationDTO>()
                                {
                                    new PartyIdentificationDTO
                                    {
                                        ID = new List<IdentifierContentDTO>()
                                        {
                                            new IdentifierContentDTO
                                            {
                                                IdentifierContent = comprobante.sRUCCompania,
                                                IdentificationSchemeIdentifier = 6,
                                                IdentificationSchemeNameText = "Documento de Identidad",
                                                IdentificationSchemeAgencyNameText = "PE:SUNAT",
                                                IdentificationSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"
                                            }
                                        }
                                    }
                                },
                                PartyName = new List<PartyNameDTO>()
                                {
                                    new PartyNameDTO
                                    {
                                        Name = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent =  comprobante.sRazonSocialCompania,
                                            }
                                        }
                                    }
                                },
                                PartyLegalEntity = new List<PartyLegalEntityDTO>()
                                {
                                    new PartyLegalEntityDTO
                                    {
                                        RegistrationName = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent =  comprobante.sRazonSocialCompania,
                                            }
                                        },
                                        RegistrationAddress = new List<RegistrationAddressDTO>()
                                        {
                                            new RegistrationAddressDTO
                                            {
                                                ID = new List<IdentifierContentDTO>()
                                                {
                                                    new IdentifierContentDTO
                                                    {
                                                        IdentifierContent = "0000",
                                                        IdentificationSchemeAgencyNameText = "PE:SUNAT",
                                                        IdentificationSchemeNameText = "Establecimientos anexos"
                                                    }
                                                },
                                                AddressTypeCode = new List<CodeContentDTO>()
                                                {
                                                    new CodeContentDTO
                                                    {
                                                        CodeContent = "0000",
                                                        CodeListAgencyNameText = "PE:SUNAT",
                                                        CodeListNameText = "Establecimientos anexos"
                                                    }
                                                },
                                                CityName = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCompania[0].ToString() },
                                                },
                                                CountrySubentity = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCompania[1].ToString() },
                                                },
                                                District  = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCompania[2].ToString() },
                                                },
                                                AddressLine = new List<AddressLineDTO>()
                                                {
                                                    new AddressLineDTO
                                                    {
                                                        Line = new List<TextContentDTO>
                                                        {
                                                            new TextContentDTO { TextContent = comprobante.sDireccion }
                                                        }
                                                    }
                                                },
                                                Country = new List<CountryDTO>
                                                {
                                                    new CountryDTO
                                                    {
                                                        IdentificationCode = new List<CodeContentDTO>
                                                        {
                                                            new CodeContentDTO
                                                            {
                                                                CodeContent = "PE",
                                                                CodeListIdentifier = "ISO 3166-1",
                                                                CodeListAgencyNameText = "United Nations Economic Commission for Europe",
                                                                CodeListNameText = "Country"
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                },
                            }
                        }
            };
            invoice.AccountingSupplierParty.Add(accountingSupplierParty);

            AccountingPartyDTO accountingCustomerParty = new AccountingPartyDTO()
            {
                Party = new List<PartyDTO>()
                        {
                            new PartyDTO
                            {
                                PartyIdentification = new List<PartyIdentificationDTO>()
                                {
                                    new PartyIdentificationDTO
                                    {
                                        ID = new List<IdentifierContentDTO>()
                                        {
                                            new IdentifierContentDTO
                                            {
                                                IdentifierContent = comprobante.sDNI,
                                                IdentificationSchemeIdentifier = 1,
                                                IdentificationSchemeNameText = "Documento de Identidad",
                                                IdentificationSchemeAgencyNameText = "PE:SUNAT",
                                                IdentificationSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06"
                                            }
                                        }
                                    }
                                },
                                PartyName = new List<PartyNameDTO>()
                                {
                                    new PartyNameDTO
                                    {
                                        Name = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = comprobante.sNombreCompleto,
                                            }
                                        }
                                    }
                                },
                                PartyLegalEntity = new List<PartyLegalEntityDTO>()
                                {
                                    new PartyLegalEntityDTO
                                    {
                                        RegistrationName = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = comprobante.sNombreCompleto,
                                            }
                                        },
                                        RegistrationAddress = new List<RegistrationAddressDTO>()
                                        {
                                            new RegistrationAddressDTO
                                            {
                                                ID = new List<IdentifierContentDTO>()
                                                {
                                                    new IdentifierContentDTO
                                                    {
                                                        IdentifierContent = null,
                                                        IdentificationSchemeAgencyNameText = "PE:INEI",
                                                        IdentificationSchemeNameText = "Ubigeos"
                                                    }
                                                },
                                                CityName = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCliente[0].ToString() },
                                                },
                                                CountrySubentity = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCliente[1].ToString() },
                                                },
                                                District  = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO { TextContent = ubigeoCliente[2].ToString() },
                                                },
                                                AddressLine = new List<AddressLineDTO>()
                                                {
                                                    new AddressLineDTO
                                                    {
                                                        Line = new List<TextContentDTO>
                                                        {
                                                            new TextContentDTO { TextContent = comprobante.sDireccion }
                                                        }
                                                    }
                                                },
                                                Country = new List<CountryDTO>
                                                {
                                                    new CountryDTO
                                                    {
                                                        IdentificationCode = new List<CodeContentDTO>
                                                        {
                                                            new CodeContentDTO
                                                            {
                                                                CodeContent = "PE",
                                                                CodeListIdentifier = "ISO 3166-1",
                                                                CodeListAgencyNameText = "United Nations Economic Commission for Europe",
                                                                CodeListNameText = "Country"
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                },
                                Contact = new List<ContactDTO>()
                                {
                                    new ContactDTO
                                    {
                                        ElectronicMail = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = comprobante.sCorreo
                                            }
                                        }
                                    }
                                }
                            }
                        }
            };
            invoice.AccountingSupplierParty.Add(accountingCustomerParty);

            TaxTotalDTO taxTotal = new TaxTotalDTO()
            {
                TaxAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO
                            {
                                AmountContent = comprobante.nValorIgv,
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        },
                TaxSubtotal = new List<TaxSubtotalDTO>()
                        {
                            new TaxSubtotalDTO
                            {
                                TaxableAmount = new List<AmountContentDTO>()
                                {
                                    new AmountContentDTO
                                    {
                                        AmountContent = comprobante.nValorTotal,
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda
                                    }
                                },
                                TaxAmount = new List<AmountContentDTO>()
                                {
                                    new AmountContentDTO
                                    {
                                        AmountContent = comprobante.nValorIgv,
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda
                                    }
                                },
                                TaxCategory = new List<TaxCategoryDTO>()
                                {
                                    new TaxCategoryDTO
                                    {
                                        TaxScheme = new List<TaxSchemeDTO>()
                                        {
                                            new TaxSchemeDTO
                                            {
                                                ID = new List<IdentifierContentDTO>()
                                                {
                                                    new IdentifierContentDTO
                                                    {
                                                        IdentifierContent = "1000",
                                                        IdentificationSchemeNameText = "Codigo de tributos",
                                                        IdentificationSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05",
                                                        IdentificationSchemeAgencyNameText = "PE:SUNAT"
                                                    }
                                                },
                                                Name = new List<TextContentDTO>()
                                                {
                                                    new TextContentDTO
                                                    {
                                                        TextContent = "IGV",
                                                    }
                                                },
                                                TaxTypeCode = new List<CodeContentDTO>()
                                                {
                                                    new CodeContentDTO
                                                    {
                                                        CodeContent = "VAT",
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
            };
            invoice.TaxTotal.Add(taxTotal);

            LegalMonetaryTotalDTO legalMonetaryTotal = new LegalMonetaryTotalDTO()
            {
                LineExtensionAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = comprobante.nValorTotal,
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        },
                TaxInclusiveAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = comprobante.nValorTotal,
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        },
                PayableAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = comprobante.nValorTotal,
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        }
            };
            invoice.LegalMonetaryTotal.Add(legalMonetaryTotal);

            InvoiceLineDTO invoiceLine = new InvoiceLineDTO()
            {
                ID = new List<IdentifierContentDTO>()
                        {
                            new IdentifierContentDTO
                            {
                                IdentifierContent = 1.ToString(),
                            }
                        },
                Note = new List<NoteDTO>()
                        {
                            new NoteDTO{
                                TextContent = "UNIDAD"
                            }
                        },
                InvoicedQuantity = new List<QuantityContentDTO>
                        {
                            new QuantityContentDTO
                            {
                                QuantityContent = 1,
                                QuantityUnitCode = "ZZ",
                                QuantityUnitCodeListIdentifier = "UN/ECE rec 20",
                                QuantityUnitCodeListAgencyNameText = "United Nations Economic Commission for Europe"
                            }
                        },
                LineExtensionAmount = new List<AmountContentDTO>
                        {
                            new AmountContentDTO
                            {
                                AmountContent = comprobante.nValorTotal,
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda
                            }
                        },
                Item = new List<ItemEfactDTO>
                        {
                            new ItemEfactDTO
                            {
                                Description = new List<TextContentDTO>
                                {
                                    new TextContentDTO
                                    {
                                        TextContent = comprobanteDet[0].sDescripcion
                                    }
                                },
                                SellersItemIdentification = new List<PartyIdentificationDTO>
                                {
                                    new PartyIdentificationDTO
                                    {
                                        ID = new List<IdentifierContentDTO>
                                        {
                                            new IdentifierContentDTO
                                            {
                                                IdentifierContent = "1"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                Price = new List<PriceDTO>
                        {
                            new PriceDTO
                            {
                                PriceAmount = new List<AmountContentDTO>
                                {
                                    new AmountContentDTO {
                                        AmountContent = comprobante.nValorTotal,
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda
                                    }
                                }
                            }
                        }
            };
            invoice.InvoiceLine.Add(invoiceLine);


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

                // Asegurarse de que la carpeta 'tmp' existe
                string tmpFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "tmp");
                if (!Directory.Exists(tmpFolderPath))
                {
                    Directory.CreateDirectory(tmpFolderPath);
                }

                // Ruta completa del archivo
                string filePath = Path.Combine(tmpFolderPath, nombreDocumento);

                // Convertir el objeto a formato JSON
                string jsonString = System.Text.Json.JsonSerializer.Serialize(comprobanteEfact);

                // Escribir el JSON en el archivo
                File.WriteAllText(filePath, jsonString);

                // string urlFinal = eFactUrlBase + eFactUrlDocument;
                // var authResponse = await this.eFactGeAtToken();

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
                return new efactResponseDTO() { code = "BACKEND", description = ex.Message };
            }
        }
    }
}
