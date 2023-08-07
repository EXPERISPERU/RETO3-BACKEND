using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CompaniaDTO
    {
        public int? nIdCompania { get; set; }
        public string sRUC { get; set; }
        public string sRazonSocial { get; set; }
        public string sAbrev { get; set; }
        public int nIdUbigeo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
