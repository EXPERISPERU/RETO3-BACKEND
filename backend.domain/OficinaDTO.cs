using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class OficinaDTO
    {
        public int nIdOficina { get; set; }
        public int? nIdOficinaP { get; set; }
        public int nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public int nIdUbigeo { get; set; }
        public string? sUbigeo { get; set; }
        public string sDireccion { get; set; }
        public string sOficina { get; set; }
        public string? sDescripcion { get; set; }
        public int nIdTipoOficina { get; set; }
        public string? sTipoOficina { get; set; }
    }
}
