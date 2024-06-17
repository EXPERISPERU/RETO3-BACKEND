namespace backend.domain
{
    public class EmpleadoDTO : PersonaDTO
    {
        public int? nIdEmpleado { get; set; }
    }

    public class JefeEmpleadoDTO
    {
        public int? nIdJefeEmpleado { get; set; }
        public int nIdJefe { get; set; }
        public string? sJefeEmpleado { get; set; }
        public int nIdEmpleado { get; set; }
        public string? sEmpleado { get; set; }
        public int? nIdPeriodoLaboral { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
