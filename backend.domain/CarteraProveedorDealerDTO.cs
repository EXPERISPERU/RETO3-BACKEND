using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CarteraProveedorDealerDTO : PersonaDTO
    {
        public int? nTotalTabla { get; set; }
        public int? nIdCliente { get; set; }
        public string sNombreCompleto { get; set; }
        public DateTime? dFechaNac { get; set; }
        public string sFechaNac { get; set; }
        public string sCorreo { get; set; }
        public string sCelular1 { get; set; }
        public string sCelular2 { get; set; }
        public string sTelefono { get; set; }
        public string sDNI { get; set; }
        public string sCE { get; set; }
        public string sRUC { get; set; }
        public string sPromotorActual { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public string sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string sFecha_mod { get; set; }
    }

    public class FilterCarteraDTO
    {
        public int nIdCompania { get; set; }
        public int? nIdAsesor { get; set; }
        public int? nIdProveedor { get; set; }
        public int nIdUsuario { get; set; }
        public string? dFechaIni { get; set; }
        public string? dFechaFin { get; set; }
        public int? PageNumber { get; set; }
        public int? RowspPage { get; set; }
    }

    public class AsignarCarteraDTO
    {
        public int nIdCompania { get; set; }
        public int nIdCliente { get; set; }
        public int? nIdAsesor { get; set; }
        public int? nIdProveedor { get; set; }
        public int nIdUsuario { get; set; }
    }


}