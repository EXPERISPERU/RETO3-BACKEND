namespace backend.domain
{
    public class OperacionBancariaDTO
    {
        public int? nIdOperacionBancaria {  get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int nIdCuenta { get; set; }
        public string? sNroCuenta { get; set; }
        public int nIdMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public string? sMoneda { get; set; }
        public string sReferencia { get; set; }
        public int nMovimiento { get; set; }
        public DateTime dFechaOperacion { get; set; }
        public decimal nImporte { get; set; }
        public decimal? nITF { get; set; }
        public decimal? nSaldo { get; set; }
        public int? nIdEstado { get; set; }
        public string? sEstado { get; set; }
        public int? nIdAdjunto { get; set; }
        public string? sRutaFtp { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public int? nValorServicio { get; set; }

    }
}
