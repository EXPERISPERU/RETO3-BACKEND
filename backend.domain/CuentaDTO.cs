namespace backend.domain
{
    public class CuentaDTO
    {
        public int? nIdCuenta { get; set; }
        public int nIdBanco { get; set; }
        public string? sBanco {  get; set; }
        public int nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public string sNroCuenta { get; set; }
        public string? sNroCuentaCCI { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
