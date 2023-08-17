using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ElementoSistemaDTO
    {
        public int? nIdElemento { get; set; }
        public int? nIdElementoP { get; set; }
        public string? sCodigo { get; set; }
        public string sAbrev { get; set; }
        public string? sDescripcion { get; set; }
        public bool bActivo { get; set; }
        public int nTipoElemento { get; set; }
        public string? sTipoElemento { get; set; }
        public int? nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public int? nIdPais { get; set; }
        public string? sPais { get; set; }
    }
}
