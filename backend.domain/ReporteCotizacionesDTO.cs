using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ReporteCotizacionesDTO
    {
        public int? nIdCotizacion { get; set; }
        public string? sCorrelativo { get; set; }
        public int? nIdLote { get; set; }
        public string? sLote { get; set; }
        public int? nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdCliente { get; set; }
        public string? sNombreCompleto { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public string? sUsuario { get; set; }
        public string? dFecha_crea { get; set; }
    }
}
