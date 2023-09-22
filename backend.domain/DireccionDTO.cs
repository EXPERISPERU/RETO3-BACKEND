using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class DireccionDTO
    {
        public int? nIdDireccion { get; set; }
        public int nIdPersona { get; set; }
        public string sDireccion { get; set; }
        public int nIdUbigeo { get; set; }
        public string? sUbigeo { get; set; }
        public string? sCodPostal { get; set; }
    }
}
