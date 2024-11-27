namespace backend.domain
{
    public class rdSelectReporteDealerDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int nIdProveedor { get; set; }
        public int nIdAgenteDealer { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
    }

    public class rdReporteDataDiaDTO
    { 
        public DateTime dFecha { get; set; }
        public int nCantidad { get; set; }
    }
}
