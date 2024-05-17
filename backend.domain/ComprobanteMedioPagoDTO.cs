using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ComprobanteMedioPagoDTO
    {
        public int nIdComprobanteMedioPago { get; set; }
        public int nIdCompania { get; set; }
        public int nIdComprobante { get; set; }
        public int nIdMedioPago { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public bool bActivo { get; set; }
    }
}
