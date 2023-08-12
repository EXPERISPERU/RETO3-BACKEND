using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class PerfilUsuarioDTO
    {
        public int nIdPerfil { get; set; }
        public string? sPerfil { get; set; }
        public int nIdUsuario { get; set; }
        public string? sUsuario { get; set; }
        public int nIdCompania { get; set; }
        public string? sCompania { get; set; }
    }
}
