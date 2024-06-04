using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ProveedorAgenteDealerDTO
    {
        public int? nIdProveedorAgente { get; set; }
        public int nIdProveedor { get; set; }
        public string? sProveedor { get; set; }
        public int nIdAgenteDealer { get; set; }
        public bool? bActivo { get; set; }
        public DateTime dFechaIni { get; set; }
        public string? sFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaFin { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public string? sFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public string? sFecha_mod { get; set; }
    }

    public class JefeAgenteDealerDTO
    {
        public int? nIdJefeDealer { get; set; }
        public int nIdJefe { get; set; }
        public int nIdAgenteDealer { get; set; }
        public string? sAgenteDealer { get; set; }
        public int? nIdProveedorAgente { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
