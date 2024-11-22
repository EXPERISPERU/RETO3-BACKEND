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
        public int? nIdTipoFilter { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }
        public int? nIdSubordinado { get; set; }
        public int? nIdProveedor { get; set; }
    }

    public class ClienteActivoInactivoDTO
    {
        public int nIdCliente { get; set; }
        public string sNombreCliente { get; set; }
        public int nIdLote { get; set; }
        public string sCelular { get; set; }
        public string sDNI { get; set; }
        public string sCE { get; set; }
        public string sRUC { get; set; }
        public string? sTipo { get; set; }
        public int? nIdServicio { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sPeriodo { get; set; }
        public string? sPredio { get; set; }
        public string sNombreAsesor { get; set; }
        public int? nDiasSinContacto { get; set; }

    }

    public class ClienteActivoInactivoFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdTipoFilter { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }
        public int? nIdSubordinado { get; set; }
        public int? nIdProveedor { get; set; }
    }


}
