using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class efactAuthResponseDTO
    {
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public string? refresh_token { get; set; }
        public int? expires_in { get; set; }
        public string? scope { get; set; }
        public string? error { get; set; }
        public string? error_description { get; set; }
    }

    public class efactResponseDTO
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    #region COMPROBANTE EFACT DTO
    public class InvoiceDTO
    {
        public string _D { get; set; }
        public string _S { get; set; }
        public string _B { get; set; }
        public string _E { get; set; }
        public List<Invoice> Invoice { get; set; }
    }

    public class Invoice
    {
        public List<IdentifierContentDTO> UBLVersionID { get; set; }
        public List<IdentifierContentDTO> CustomizationID { get; set; }
        public List<IdentifierContentDTO> ID { get; set; }
        public List<DateContentDTO> IssueDate { get; set; }
        public List<DateTimeContentDTO> IssueTime { get; set; }
        public List<InvoiceTypeCodeDTO> InvoiceTypeCode { get; set; }
        public List<NoteDTO> Note { get; set; }
        public List<DocumentCurrencyCodeDTO> DocumentCurrencyCode { get; set; }
        public List<NumericContentDTO> LineCountNumeric { get; set; }
        public List<SignatureDTO> Signature { get; set; }
        public List<AccountingPartyDTO> AccountingSupplierParty { get; set; }
        public List<AccountingPartyDTO> AccountingCustomerParty { get; set; }
        public List<TaxTotalDTO> TaxTotal { get; set; }
        public List<LegalMonetaryTotalDTO> LegalMonetaryTotal { get; set; }
        public List<InvoiceLineDTO> InvoiceLine { get; set; }
    }

    public class IdentifierContentDTO
    {
        public string IdentifierContent { get; set; }
    }

    public class DateContentDTO
    {
        public string DateContent { get; set; }
    }

    public class DateTimeContentDTO
    {
        public string DateTimeContent { get; set; }
    }

    public class InvoiceTypeCodeDTO
    {
        public string CodeContent { get; set; }
        public string CodeListNameText { get; set; }
        public string CodeListSchemeUniformResourceIdentifier { get; set; }
        public string CodeListIdentifier { get; set; }
        public string CodeNameText { get; set; }
        public string CodeListUniformResourceIdentifier { get; set; }
        public string CodeListAgencyNameText { get; set; }
    }

    public class NoteDTO
    {
        public string TextContent { get; set; }
        public string LanguageLocaleIdentifier { get; set; }
        public string LanguageIdentifier { get; set; }
    }

    public class DocumentCurrencyCodeDTO
    {
        public string CodeContent { get; set; }
        public string CodeListIdentifier { get; set; }
        public string CodeListNameText { get; set; }
        public string CodeListAgencyNameText { get; set; }
    }

    public class NumericContentDTO
    {
        public int NumericContent { get; set; }
    }

    public class SignatureDTO
    {
        public List<IdentifierContentDTO> ID { get; set; }
        public List<SignatoryPartyDTO> SignatoryParty { get; set; }
        public List<DigitalSignatureAttachmentDTO> DigitalSignatureAttachment { get; set; }
    }

    public class SignatoryPartyDTO
    {
        public List<PartyIdentificationDTO> PartyIdentification { get; set; }
        public List<PartyNameDTO> PartyName { get; set; }
    }

    public class PartyIdentificationDTO
    {
        public List<IdentifierContentDTO> ID { get; set; }
    }

    public class PartyNameDTO
    {
        public List<TextContentDTO> Name { get; set; }
    }

    public class TextContentDTO
    {
        public string TextContent { get; set; }
    }

    public class DigitalSignatureAttachmentDTO
    {
        public List<ExternalReferenceDTO> ExternalReference { get; set; }
    }

    public class ExternalReferenceDTO
    {
        public List<TextContentDTO> URI { get; set; }
    }

    public class AccountingPartyDTO
    {
        public List<PartyDTO> Party { get; set; }
    }

    public class PartyDTO
    {
        public List<PartyIdentificationDTO> PartyIdentification { get; set; }
        public List<PartyNameDTO> PartyName { get; set; }
        public List<PartyLegalEntityDTO> PartyLegalEntity { get; set; }
        public List<ContactDTO> Contact { get; set; }
    }

    public class PartyLegalEntityDTO
    {
        public List<TextContentDTO> RegistrationName { get; set; }
        public List<RegistrationAddressDTO> RegistrationAddress { get; set; }
    }

    public class RegistrationAddressDTO
    {
        public List<IdentifierContentDTO> ID { get; set; }
        public List<CodeContentDTO> AddressTypeCode { get; set; }
        public List<TextContentDTO> CityName { get; set; }
        public List<TextContentDTO> CountrySubentity { get; set; }
        public List<TextContentDTO> District { get; set; }
        public List<AddressLineDTO> AddressLine { get; set; }
        public List<CountryDTO> Country { get; set; }
    }

    public class CodeContentDTO
    {
        public string CodeContent { get; set; }
    }

    public class AddressLineDTO
    {
        public List<TextContentDTO> Line { get; set; }
    }

    public class CountryDTO
    {
        public List<CodeContentDTO> IdentificationCode { get; set; }
    }

    public class ContactDTO
    {
        public List<TextContentDTO> ElectronicMail { get; set; }
    }

    public class TaxTotalDTO
    {
        public List<AmountContentDTO> TaxAmount { get; set; }
        public List<TaxSubtotalDTO> TaxSubtotal { get; set; }
    }

    public class AmountContentDTO
    {
        public decimal AmountContent { get; set; }
        public string AmountCurrencyIdentifier { get; set; }
    }

    public class TaxSubtotalDTO
    {
        public List<AmountContentDTO> TaxableAmount { get; set; }
        public List<AmountContentDTO> TaxAmount { get; set; }
        public List<TaxCategoryDTO> TaxCategory { get; set; }
    }

    public class TaxCategoryDTO
    {
        public List<TaxSchemeDTO> TaxScheme { get; set; }
        public List<CodeContentDTO> TaxExemptionReasonCode { get; set; }
        public List<NumericContentDTO> Percent { get; set; }
    }

    public class TaxSchemeDTO
    {
        public List<IdentifierContentDTO> ID { get; set; }
        public List<TextContentDTO> Name { get; set; }
        public List<CodeContentDTO> TaxTypeCode { get; set; }
    }

    public class LegalMonetaryTotalDTO
    {
        public List<AmountContentDTO> LineExtensionAmount { get; set; }
        public List<AmountContentDTO> TaxInclusiveAmount { get; set; }
        public List<AmountContentDTO> PayableAmount { get; set; }
    }

    public class InvoiceLineDTO
    {
        public List<IdentifierContentDTO> ID { get; set; }
        public List<NoteDTO> Note { get; set; }
        public List<QuantityContentDTO> InvoicedQuantity { get; set; }
        public List<AmountContentDTO> LineExtensionAmount { get; set; }
        public List<PricingReferenceDTO> PricingReference { get; set; }
        public List<TaxTotalDTO> TaxTotal { get; set; }
        public List<ItemEfactDTO> Item { get; set; }
        public List<PriceDTO> Price { get; set; }
    }

    public class QuantityContentDTO
    {
        public decimal QuantityContent { get; set; }
        public string QuantityUnitCode { get; set; }
        public string QuantityUnitCodeListIdentifier { get; set; }
        public string QuantityUnitCodeListAgencyNameText { get; set; }
    }

    public class PricingReferenceDTO
    {
        public List<AlternativeConditionPriceDTO> AlternativeConditionPrice { get; set; }
    }

    public class AlternativeConditionPriceDTO
    {
        public List<AmountContentDTO> PriceAmount { get; set; }
        public List<InvoiceTypeCodeDTO> PriceTypeCode { get; set; }
    }

    public class ItemEfactDTO
    {
        public List<TextContentDTO> Description { get; set; }
        public List<PartyIdentificationDTO> SellersItemIdentification { get; set; }
    }

    public class PriceDTO
    {
        public List<AmountContentDTO> PriceAmount { get; set; }
    }
    #endregion
}
