using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class FormularioContactoPortalDTO
    {
        public int nIdPortal { get; set; }
        public string sPortal { get; set; }
        public string sURL { get; set; }
        public string sNombreCompleto { get; set; }
        public string sDNI { get; set; }
        public string sCelular { get; set; }
        public string sUbicacion { get; set; }
        public string sCorreo { get; set; }
        public int nIdTipoSolicitud { get; set; }
        public string sTipoSolicitud { get; set; }
    }
}
