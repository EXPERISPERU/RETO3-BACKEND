using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ComprobanteBajaDTO
    {

        public int? nIdComprobanteBaja { get; set; }
        public int? nIdComprobante { get; set; }
        public string? sCodigoBaja { get; set; }
        public int? nIdMotivo { get; set; }
        public string? sMotivo { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int nIdUsuario_autoriza { get; set; }

        //Otros
        public int? nTipo { get; set; }
        public int? nIdCobranza { get; set; }
    }

}
