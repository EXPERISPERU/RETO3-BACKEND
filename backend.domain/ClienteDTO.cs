namespace backend.domain
{
    public class ClienteDTO : PersonaDTO
    {
        public int? nIdCliente { get; set; }
        public int nIdTipo { get; set; }
        public string? sPromotorActual { get; set; }
    }

    public class SunatRQPersonaDTO
    { 
        public int tipDocu { get; set; }
        public string numDocu { get; set; }
        public string tipPers { get; set; }
    }

    public class PersonaSunatDTO
    {
        public string? apeMatSoli { get; set; }
        public string? apePatSoli { get; set; }
        public string? nombreSoli { get; set; }
    }
}
