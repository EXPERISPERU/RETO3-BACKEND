using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ProyectoDocumentoContratoDTO
    {

        public int? nIdProyDocCont { get; set; }
        public int nIdProyecto { get; set; }
        public int nIdDocumento { get; set; }
        public string sDocumento { get; set; }
        public bool bActivo { get; set; }
        public bool? bRequeridoFirma { get; set; }
        public bool? bFirmaDigital { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }


    }
}
