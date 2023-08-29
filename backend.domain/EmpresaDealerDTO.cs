using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class EmpresaDealerDTO
    {
        public int? nIdEmpresaDealer { get; set; }
        public int? nIdPersona { get; set; }
        public string sRUC { get; set; }
        public string sNombreCompleto { get; set; }
        public string sCorreo { get; set; }
        public string sCelular { get; set; }
        public string sTelefono { get; set; }
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
