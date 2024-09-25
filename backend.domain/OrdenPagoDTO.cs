namespace backend.domain
{
    public class OrdenPagoDTO
    {
        public int? nIdOrdenPago { get; set; }
        public int nIdCliente { get; set; }
        public int nIdMoneda { get; set; }
        public int nIdEstado { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdLote { get; set; }
        public int? nIdReserva { get; set; }
        public int? nIdContrato { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }

    public class OrdenPagoDetDTO
    {
        public int? nIdOrdenPagoDet { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nIdItem { get; set; }
        public string? sItem { get; set; }
        public string sDescripcion { get; set; }
        public int nCantidad { get; set; }
        public decimal nValorUnitario { get; set; }
        public decimal nValorSubtotal { get; set; }
        public decimal? nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int? nIdCronograma { get; set; }
    }
}
