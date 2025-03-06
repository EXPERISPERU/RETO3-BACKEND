using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class UsuarioDTO
    {
        public int? nIdUsuario { get; set; }
        public string? sUsuario { get; set; }
        public string? sPassword { get; set; }
        public bool? bActivo { get; set; }
        public int nIdPersona { get; set;}
        public int? nIdUsuario_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sNombreCompleto { get; set; }
    }

    public class authLoginDTO
    {
        public string sUsuario { get; set; }
        public string sPassword { get; set; }
    }

    public class recoverPasswordDTO
    {
        public int bChangePassword { get; set; }
        public string sCorreoUser { get; set; }
        public string? sMsj { get; set; }
        public int emailExist { get; set; }
    }
}
