namespace backend.domain
{
    public class BeneficiarioClienteDTO : PersonaDTO
    {
        public int? nIdBeneficiario { get; set; }
        public int nIdCliente { get; set; }
        public int nIdRelacionFamiliar { get; set; }
        public string? sRelacionFamiliar { get; set; }
        public Boolean? bActivo { get; set; }
    }
}
