using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class LoginDTO
    {
        public int nIdUsuario { get; set; }
        public string? sNombreCompleto { get; set; }
        public int? nIdPersona { get; set; }
        public string? sUsuario { get; set; }
        public string? sMsj { get; set; }
        public DateTime? dFechaNac { get; set; }
    }

    public class RecoverPasswordDTO
    {
        public int bChangePassword { get; set; }
        public string sCorreoUser { get; set; }
        public string? sMsj { get; set; }
        public int emailExist { get; set; }        
    }
}
