using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class UsuarioDTO
    {
        public int nIdUsuario { get; set; }
        public string sUsuario { get; set; }
        public string sPassword { get; set; }
        public bool bActivo { get; set; }
        public int nIdTipoPersona { get; set;}
        public int nIdPerDet { get; set; }
    }

    public class authLoginDTO
    {
        public string sUsuario { get; set; }
        public string sPassword { get; set; }
    }
}
