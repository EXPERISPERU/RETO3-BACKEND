using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class VigenciaServicioDTO
    {
        public int? nIdVigenciaServicio { get; set; }
        public int nIdPrecioServicio { get; set; }
        public int nVigencia { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int nIdUsuario_mod { get; set; }
        public DateTime dFecha_mod { get; set; }
    }
}
