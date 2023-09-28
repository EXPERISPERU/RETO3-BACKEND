using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ItemDTO
    {
        public int? nIdItem { get; set; }
        public string? sItem { get; set; }
        public string? sDescripcion { get; set; }
        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
    }
}