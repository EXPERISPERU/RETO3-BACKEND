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
        public string? sCliente { get; set; }
        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int? nIdEmpleado { get; set; }
        public string? sEmpleado { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public string? sAgenteDealer { get; set; }
        public int? nIdProveedor { get; set; }
        public string? sProveedor { get; set; }
        public DateTime? dFechaIni { get; set; }
        public string? sFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaFin { get; set; }
    }

    public class InsReferidoDTO
    {
        public int nIdCliente { get; set; }
        public int nIdUsuario { get; set; }
    }
}
