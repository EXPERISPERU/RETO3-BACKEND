using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ProspectoDTO
    {
        public int? nIdProspecto { get; set; }
        public string? sCodigo { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdSeguimiento { get; set; }
        public int? nIdTipo { get; set; }
        public int? nIdEmpleado { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public string sPriNombre { get; set; }
        public string? sSegNombre { get; set; }
        public string sApePaterno { get; set; }
        public string? sApeMaterno { get; set; }
        public string? sNombreCompleto { get; set; }
        public DateTime? dFechaNac { get; set; }
        public int? nIdUbigeoNac { get; set; }
        public int? nIdGenero { get; set; }
        public string? sGenero { get; set; }
        public int? nIdEstadoCivil { get; set; }
        public string? sEstadoCivil { get; set; }
        public string? sCorreo { get; set; }
        public string? sCelular { get; set; }
        public string? sCelular2 { get; set; }
        public string? sTelefono { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sEstado { get; set; }
        public string? sEmpleado { get; set; }
        public string? sAgenteDealer { get; set; }
        public string? sNombreAsesor { get; set; }

    }
}
