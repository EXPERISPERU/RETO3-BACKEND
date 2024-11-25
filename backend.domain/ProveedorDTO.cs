using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ProveedorDTO
    {
        public int? nIdProveedor { get; set; }
        public int? nIdTipo { get; set; }
        public int? nIdPersona { get; set; }
        public string? sAlias { get; set; }
        public string? sDNI { get; set; }
        public string sRUC { get; set; }
        public string? sPriNombre { get; set; }
        public string? sSegNombre { get; set; }
        public string? sApePaterno { get; set; }
        public string? sApeMaterno { get; set; }
        public string? sNombreCompleto { get; set; }
        public string sCorreo { get; set; }
        public string sCelular { get; set; }
        public string sTelefono { get; set; }
        public bool bDealer { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
    }


    public class JefeComercialDTO
    {
        public int? nIdProveedorJefe { get; set; }
        public int nIdJefeComercial { get; set; }
        public string? sJefeComercial { get; set; }
        public int nIdProveedor { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
