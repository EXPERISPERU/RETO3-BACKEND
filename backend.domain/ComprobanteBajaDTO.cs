using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ComprobanteBajaDTO
    {
        public int? nCorrelativo { get; set; }
        public int? nIdComprobanteBaja { get; set; }
        public int? nIdComprobante { get; set; }
        public string? sCodigoBaja { get; set; }
        public string? sComprobante { get; set; }
        public string? sRUCCompania { get; set; }
        public string? sRazonSocialCompania { get; set; }
        public string? sUbigeoCompania { get; set; }
        public string? sDireccionCompania { get; set; }
        public string? sMotivoBaja { get; set; }
        public string? sSerieC {  get; set; }
        public int? nCorrelativoC { get; set; }
        public int? nIdMotivo { get; set; }
        public string? sMotivo { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int nIdUsuario_autoriza { get; set; }

        //Otros
        public int? nIdCobranza { get; set; }
    }

    public class SelectComprobanteBajaDTO
    {
        public int nIdCompania { get; set; }
        public int PageNumber { get; set; }
        public int RowspPage { get; set; }
    }

}
