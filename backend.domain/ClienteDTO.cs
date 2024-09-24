namespace backend.domain
{
    public class ClienteDTO : PersonaDTO
    {
        public int? nTotalTabla { get; set; }
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

    public class ClienteTrazabilidadDTO
    {
        public int nIdCliente { get; set; }
        public string sNombreCliente { get; set; }
        public string sPredio { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public int? nCantCotizaciones { get; set; }
        public int? nCantReservas { get; set; }
        public int? nCantPreContratos { get; set; }
        public int? nCantVentas { get; set; }
    }

    public class ClienteTrazabilidadFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
    }
}
