using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CarteraProveedorDealerDTO: PersonaDTO
    {
        public int? nTotalTabla { get; set; }
        public int? nIdCliente { get; set; }
        public int nIdTipo { get; set; }
        public string? sPromotorActual { get; set; }
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
        public int nIdAsesor { get; set; }
        public int nIdProveedor { get; set; }
        public int nIdUsuario { get; set; }
     }


}