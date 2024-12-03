using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ReferidoDTO
    {
        public int? nIdReferido { get; set; }
        public int nIdCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sCliente { get; set; }

        public string? sCelular { get; set; }
        public string? sCelular2 { get; set; }
        public string? sCorreo { get; set; }
        public string? sDireccion { get; set; }

        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int? nIdEmpleado { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public string? sNombreAsesor { get; set; }
        public int? nIdProveedor { get; set; }
        public string? sProveedor { get; set; }
        public DateTime? dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public Boolean? bActivo { get; set; }
    }

    public class InsReferidoDTO
    {
        public int nIdCompania { get; set; }
        public int nIdCliente { get; set; }
        public int nIdUsuario { get; set; }
    }

    public class ReferidoChartDTO
    {
        public int nIdPersona { get; set; }
        public int nIdAsesor { get; set; }
        public string? sNombreAsesor { get; set; }
        public DateTime dFechaPrimerReferido { get; set; }
        public int? nCountUniqueReferido { get; set; }
        public int? nCountTotalReferido { get; set; }
    }

    public class ReferidoChartFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdTipoFilter { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }
        public int? nIdSubordinado { get; set; }
        public int? nIdProveedor { get; set; }
    }

}
