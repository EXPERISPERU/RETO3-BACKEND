using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CotizacionDTO : LotesDisponiblesDTO
    {
        public int? nIdCotizacion { get; set; }
        public string? sCorrelativo { get; set; }
        public int nIdCliente { get; set; }
        public string? sDocumentoCliente { get; set; }
        public string? sNombreCliente { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
    }

    public class getFormatoCotizacionDTO 
    {
        public int? nIdCotizacion { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdCompania { get; set; }
    }

    public class getSelectCotizacionDTO 
    {
        public int nIdLote { get; set; }
        public int? nIdInicialLote { get; set; }
        public int? nIdDescuentoLote { get; set; }
        public int? nIdCuotaLote { get; set; }
        public int? nIdInteresCuota { get; set; }
    }

    public class InicialDescuentoDTO
    {
        public int nId { get; set; }
        public string sDescripcion { get; set; }
        public decimal nValor { get; set; }
        public int nIdTipo { get; set; }
        public string sTipoCodigo { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdLote { get; set; }
    }

    public class SelectInteresDTO
    {
        public int nId { get; set; }
        public string sDescripcion { get; set; }
        public int nIdTipoInteres { get; set; }
        public decimal nValor { get; set; }
        public int nIdTipoValor { get; set; }
        public string sCodigoTipoValor { get; set; }
    }
}
