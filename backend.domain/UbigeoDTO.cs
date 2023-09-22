using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class UbigeoDTO
    {
        public int nIdUbigeo { get; set; }
        public string sCodigo { get; set; }
        public string sUbigeo { get; set; }
        public string? sUbigeoP { get; set; }
        public int? nIdUbigeoP { get; set; }
        public int nIdTipoUbigeo { get; set; }
        public int nIdPais { get; set; }
    }
}
