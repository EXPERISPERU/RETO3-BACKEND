using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{ 


    public class ReporteCotizacionesFiltrosDTO
    {
        public string? sCorrelativo { get; set; }
        public int? nIdTipoDocumento { get; set; }
        public string? sDocumento { get; set; }
        public string? nNombreCompleto { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
        public int? nIdItem { get; set; }
        public DateTime? dFechaCreacion { get; set; }
        public string? nNombreUsuario { get; set; }
        public int? nIdCompania { get; set; }
        public int? nIdUsuario { get; set; }
    }

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


    public class CotizacionChartDTO
    {
        public int nIdPersona { get; set; }
        public int nIdAsesor { get; set; }
        public string? sNombreAsesor { get; set; }
        public DateTime dFecha { get; set; }
        public int? nCountCotizacion { get; set; }
    }

    public class CotizacionChartFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }
    }
}
