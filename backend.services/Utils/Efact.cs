using backend.domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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

        private EfactComprobanteDTO comprobanteEfact(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet, ComprobanteDTO? comprobanteOrigen, List<ComprobanteMetodoPagoDTO>? metodosPago)
        {

            EfactComprobanteDTO efactComprobante = new EfactComprobanteDTO();

            string observaciones = "Celular: 967 283 715 %5D Fijo: 694 - 8518";

            if (metodosPago.Count() > 0)
            {
                observaciones += " %5D Metodo de Pago:%5D";

                for (int i = 0; i < metodosPago.Count(); i++)
                {
                    observaciones += $"{metodosPago[i].sAbrev} ";
                    if (metodosPago[i].sAbrev != "Efectivo")
                    {
                        observaciones += $"- {metodosPago[i].sDetalle}";
                    }
                }

                observaciones += "%5D";
            }


            string[] ubigeoCliente = comprobante.sUbigeo.Split(',').Select(s => s.Trim()).ToArray();
            string[] ubigeoCompania = comprobante.sUbigeoCompania.Split(',').Select(i => i.Trim()).ToArray();

            var invoiceLines = new List<InvoiceLineDTO>();

            for (int i = 0; i < comprobanteDet.Count; i++)
            {
                invoiceLines.Add(
                    new InvoiceLineDTO
                    {
                        ID = new List<IdentifierContentInvoiceDTO>()
                        {
                            new IdentifierContentInvoiceDTO
                            {
                                IdentifierContent = i + 1,
                            }
                        },
                        Note = new List<NoteDTO>()
                        {
                            new NoteDTO
                            {
                                TextContent = "UNIDAD"
                            }
                        },
                        InvoicedQuantity = new List<QuantityContentDTO>
                        {
                            new QuantityContentDTO
                            {
                                QuantityContent = comprobanteDet[i].nCantidad,
                                QuantityUnitCode = "ZZ",
                                QuantityUnitCodeListIdentifier = "UN/ECE rec 20",
                                QuantityUnitCodeListAgencyNameText = "United Nations Economic Commission for Europe"
                            }
                        },
                        LineExtensionAmount = new List<AmountContentDTO>
                        {
                            new AmountContentDTO
                            {
                                AmountContent = Math.Round(comprobanteDet[i].nValorSubTotal.Value,2),
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda
                            }
                        },
                        PricingReference = new List<PricingReferenceDTO>
                        {
                            new PricingReferenceDTO
                            {
                                AlternativeConditionPrice = new List<AlternativeConditionPriceDTO>()
                                {
                                    new AlternativeConditionPriceDTO
                                    {
                                        PriceAmount = new List<AmountContentDTO>
                                        {
                                            new AmountContentDTO
                                            {
                                                AmountContent = Math.Round(comprobanteDet[i].nValorTotal,2),
                                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                                            }
                                        },
                                        PriceTypeCode = new List<InvoiceTypeCodeDTO>
                                        {
                                            new InvoiceTypeCodeDTO
                                            {
                                                CodeContent = "01",
                                                CodeListNameText = "Tipo de Precio",
                                                CodeListAgencyNameText = "PE:SUNAT",
                                                CodeListUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        TaxTotal = new List<TaxTotalDTO>
                        {
                            new TaxTotalDTO{
                                TaxAmount = new List<AmountContentDTO>{
                                    new AmountContentDTO
                                    {
                                        AmountContent = Math.Round(comprobanteDet[i].nValorIgv.Value,2),
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                                    }
                                },
                                TaxSubtotal = new List<TaxSubtotalDTO>{
                                    new TaxSubtotalDTO
                                    {
                                        TaxableAmount = new List<AmountContentDTO>{
                                            new AmountContentDTO
                                            {
                                                AmountContent = Math.Round(comprobanteDet[i].nValorSubTotal.Value,2),
                                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                                            }
                                        },
                                        TaxAmount = new List<AmountContentDTO>{
                                            new AmountContentDTO
                                            {
                                                AmountContent = Math.Round(comprobanteDet[i].nValorIgv.Value,2),
                                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                                            }
                                        },
                                        TaxCategory = new List<TaxCategoryDTO>{
                                            new TaxCategoryDTO
                                            {
                                                Percent = new List<NumericContentDTO>{
                                                    new NumericContentDTO{
                                                        NumericContent = 18,
                                                    }
                                                },
                                                TaxExemptionReasonCode = new List<CodeContentDTO>
                                                {
                                                    new CodeContentDTO
                                                    {
                                                        CodeContent = "10",
                                                        CodeListAgencyNameText = "PE:SUNAT",
                                                        CodeListNameText = "Afectacion del IGV",
                                                        CodeListUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07",
                                                    }
                                                },
                                                TaxScheme = new List<TaxSchemeDTO>
                                                {
                                                    new TaxSchemeDTO
                                                    {
                                                        ID = new List<IdentifierContentDTO>
                                                        {
                                                            new IdentifierContentDTO
                                                            {
                                                                IdentifierContent = "1000",
                                                                IdentificationSchemeNameText = "Codigo de tributos",
                                                                IdentificationSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05",
                                                                IdentificationSchemeAgencyNameText = "PE:SUNAT"
                                                            }
                                                        },
                                                        Name = new List<TextContentDTO>
                                                        {
                                                            new TextContentDTO
                                                            {
                                                                TextContent = "IGV"
                                                            }
                                                        },
                                                        TaxTypeCode = new List<CodeContentDTO>
                                                        {
                                                            new CodeContentDTO
                                                            {
                                                                CodeContent = "VAT"
                                                            }
                                                        }
                                                    }
                                                },
                                            }
                                        },
                                    },
                                },
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
                                        TextContent = comprobanteDet[i].sDescripcion.Replace("#n#","%5D")
                                    }
                                },
                                SellersItemIdentification = new List<PartyIdentificationDTO>
                                {
                                    new PartyIdentificationDTO
                                    {
                                        ID = new List<IdentifierContentPartyDTO>
                                        {
                                            new IdentifierContentPartyDTO
                                            {
                                                IdentifierContent = $"{i + 1}",
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
                                        AmountContent = Math.Round(comprobanteDet[i].nValorSubTotal.Value,2),
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda
                                    }
                                }
                            }
                        }
                    }
                );
            }

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

            List<NoteDTO> notes = new List<NoteDTO>(){
                new NoteDTO(){
                    TextContent = new NumerosLetras().sConvertir(Math.Round(comprobante.nValorTotal,2))
                    ,
                    LanguageLocaleIdentifier = "1000"
                },
                new NoteDTO()
                {
                    TextContent = observaciones
                },
                new NoteDTO()
                {
                    TextContent = "001101300201068964",
                    LanguageIdentifier = "BH"
                },
                new NoteDTO()
                {
                    TextContent = "011130000201068964-20",
                    LanguageIdentifier = "BI"
                },
                new NoteDTO(){
                    TextContent = "0011-0101-02-00641816",
                    LanguageIdentifier = "BF"
                },
                new NoteDTO(){
                    TextContent = "011 101 00020064181630",
                    LanguageIdentifier = "BG"
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
            invoice.DocumentCurrencyCode = new List<DocumentCurrencyCodeDTO> { documentCurrencyCode };

            #region OBJETOS PARA NOTA DE CREDITO

            DiscrepancyResponseDTO discrepancyResponse = new DiscrepancyResponseDTO()
            {
                ResponseCode = new List<CodeContentDTO>()
                {
                    new CodeContentDTO
                    {
                        CodeContent = comprobanteOrigen?.nIdTipoOperacionNcd.ToString(),
                        CodeListAgencyNameText = "PE:SUNAT",
                        CodeListNameText = "Tipo de nota de credito",
                        CodeListUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo09"
                    }
                },
                Description = new List<TextContentDTO>()
                {
                    new TextContentDTO
                    {
                        TextContent = "CLIENTE NO DESEA PARTICIPAR EN EL PROYECTO SAUCES"
                    }
                }
            };

            BillingReferenceDTO billingReference = new BillingReferenceDTO()
            {
                InvoiceDocumentReference = new List<DocumentReferenceDTO>()
                {
                    new DocumentReferenceDTO
                    {
                        ID = new List<IdentifierContentDTO>
                        {
                            new IdentifierContentDTO
                            {
                                IdentifierContent = comprobanteOrigen?.sComprobante
                            }
                        },
                        IssueDate = new List<DateContentDTO>
                        {
                            new DateContentDTO
                            {
                                DateContent = comprobanteOrigen?.sFecha_crea
                            }
                        },
                        DocumentTypeCode = new List<CodeContentDTO>
                        {
                            new CodeContentDTO
                            {
                                CodeContent = new Sunat().TipoDocumento(comprobanteOrigen?.sCodigoTipoComprobante),
                                CodeListNameText = "Tipo de Documento",
                                CodeListSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01",
                                CodeListAgencyNameText = "PE:SUNAT"
                            }
                        }
                    }
                }
            };

            #endregion

            NumericContentDTO numericContent = new NumericContentDTO()
            {
                NumericContent = 1
            };

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
                                PartyIdentification = new List<PartyIdentificationSignatureDTO>()
                                {
                                    new PartyIdentificationSignatureDTO
                                    {
                                        ID = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO { TextContent = comprobante.sRUCCompania }
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
                                                TextContent = comprobante.sRazonSocialCompania
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
            invoice.Signature = new List<SignatureDTO> { signature };

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
                                        ID = new List<IdentifierContentPartyDTO>()
                                        {
                                            new IdentifierContentPartyDTO
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
                                                        IdentifierContent = "150101",
                                                        IdentificationSchemeAgencyNameText = "PE:INEI",
                                                        IdentificationSchemeNameText = "Ubigeos"
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
                                                            new TextContentDTO { TextContent = comprobante.sDireccionCompania }
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
            invoice.AccountingSupplierParty = new List<AccountingPartyDTO> { accountingSupplierParty };

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
                                ID = new List<IdentifierContentPartyDTO>()
                                {
                                    new IdentifierContentPartyDTO
                                    {
                                        IdentifierContent = comprobante.sDNI,
                                        IdentificationSchemeIdentifier = "1",
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
                        PartyLegalEntity = new List<PartyLegalEntityDTO>
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
                                RegistrationAddress = new List<RegistrationAddressDTO>
                                {
                                    new RegistrationAddressDTO
                                    {
                                        ID = new List<IdentifierContentDTO>
                                        {
                                            new IdentifierContentDTO
                                            {
                                                IdentifierContent = comprobante.sCodigoUbigeo,
                                                IdentificationSchemeAgencyNameText = "PE:INEI",
                                                IdentificationSchemeNameText = "Ubigeos"
                                            }
                                        },
                                        CityName = new List<TextContentDTO>()
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent =  ubigeoCliente.Length > 0 ? ubigeoCliente[0] : string.Empty,
                                            }
                                        },
                                        CountrySubentity = new List<TextContentDTO>
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = "",
                                            }
                                        },
                                        District = new List<TextContentDTO>
                                        {
                                            new TextContentDTO
                                            {
                                                TextContent = "",
                                            }
                                        },
                                        AddressLine = new List<AddressLineDTO>{
                                            new AddressLineDTO
                                            {
                                                Line =  new List<TextContentDTO>
                                                {
                                                    new TextContentDTO
                                                    {
                                                        TextContent = comprobante.sDireccion
                                                    }
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
                            }
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
            invoice.AccountingCustomerParty = new List<AccountingPartyDTO> { accountingCustomerParty };

            TaxTotalDTO taxTotal = new TaxTotalDTO()
            {
                TaxAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO
                            {
                                AmountContent = Math.Round(Math.Round(comprobante.nValorIgv,2),2),
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
                                        AmountContent = Math.Round(comprobante.nValorSubTotal,2),
                                        AmountCurrencyIdentifier = comprobante.sSunatMoneda
                                    }
                                },
                                TaxAmount = new List<AmountContentDTO>()
                                {
                                    new AmountContentDTO
                                    {
                                        AmountContent = Math.Round(Math.Round(comprobante.nValorIgv,2),2),
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
                                                        IdentificationSchemeAgencyNameText = "PE:SUNAT",
                                                        IdentificationSchemeUniformResourceIdentifier = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05",
                                                        IdentificationSchemeNameText = "Codigo de tributos",
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
            invoice.TaxTotal = new List<TaxTotalDTO> { taxTotal };

            LegalMonetaryTotalDTO legalMonetaryTotal = new LegalMonetaryTotalDTO()
            {
                LineExtensionAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = Math.Round(comprobante.nValorSubTotal,2),
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        },
                TaxInclusiveAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = Math.Round(comprobante.nValorTotal,2),
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        },
                PayableAmount = new List<AmountContentDTO>()
                        {
                            new AmountContentDTO{
                                AmountContent = Math.Round(comprobante.nValorTotal,2),
                                AmountCurrencyIdentifier = comprobante.sSunatMoneda,
                            }
                        }
            };
            invoice.LegalMonetaryTotal = new List<LegalMonetaryTotalDTO> { legalMonetaryTotal };

            if (comprobante.sCodigoTipoComprobante == "3")
            {
                invoice.InvoiceTypeCode = new List<InvoiceTypeCodeDTO> { invoiceTypeCode };
                invoice.LineCountNumeric = new List<NumericContentDTO> { numericContent };
                invoice.InvoiceLine = invoiceLines;
            }

            if (comprobante.sCodigoTipoComprobante == "7")
            {
                invoice.DiscrepancyResponse = new List<DiscrepancyResponseDTO> { discrepancyResponse };
                invoice.BillingReference = new List<BillingReferenceDTO> { billingReference };
                invoice.CreditNoteLine = invoiceLines;
            }

            efactComprobante.Invoice = new List<Invoice> { invoice };

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

        public async Task<efactResponseDTO> GenerarDocumento(ComprobanteDTO comprobante, List<ComprobanteDetDTO> comprobanteDet, ComprobanteDTO? comprobanteOrigen, List<ComprobanteMetodoPagoDTO>? metodoPago)
        {
            try
            {
                EfactComprobanteDTO comprobanteEfact = this.comprobanteEfact(comprobante, comprobanteDet, comprobanteOrigen, metodoPago);

                string tipoDocumento = new Sunat().TipoDocumento(comprobante.sCodigoTipoComprobante);
                string nombreDocumento = comprobante.sRUCCompania + "-" + tipoDocumento + "-" + comprobante.sSerie + "-" + comprobante.nCorrelativo.ToString().PadLeft(8, '0') + ".json";

                // Asegurarse de que la carpeta 'tmp' existe
                string tmpFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "tmp");

                if (!Directory.Exists(tmpFolderPath))
                {
                    Directory.CreateDirectory(tmpFolderPath);
                }

                // Serializar el objeto a JSON con configuración de ignorar valores nulos
                var jsonString = JsonConvert.SerializeObject(
                    comprobanteEfact,
                    Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

                // Ruta completa del archivo
                string filePath = Path.Combine(tmpFolderPath, nombreDocumento);

                // Escribir el JSON en el archivo
                File.WriteAllText(filePath, jsonString);

                string urlFinal = eFactUrlBase + eFactUrlDocument;
                var authResponse = await this.eFactGetToken();

                // CONSUMIR SERVICIO PARA ENVIAR ARCHIVO
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.access_token);

                    var content = new MultipartFormDataContent();

                    byte[] xmlBytes = await File.ReadAllBytesAsync(filePath);
                    var fileContent = new ByteArrayContent(xmlBytes);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                    content.Add(fileContent, "file", nombreDocumento);

                    var response = await httpClient.PostAsync(urlFinal, content);
                    int status = (int)response.StatusCode;

                    File.Delete(filePath);

                    string res = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<efactResponseDTO>(res);

                    if (status == 200)
                    {
                        return result;
                    }
                    else
                    {
                        return new efactResponseDTO() { code = result?.code, description = result?.description };
                    }
                }
            }
            catch (Exception ex)
            {
                return new efactResponseDTO() { code = "BACKEND", description = ex.Message };
            }
        }
    }
}
