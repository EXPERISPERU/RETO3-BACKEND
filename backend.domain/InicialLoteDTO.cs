using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InicialLoteDTO
    {
        public int nIdInicialLote { get; set; }
        public int? nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public int nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int? nIdSector { get; set; }
        public string? sSector { get; set; }
        public int? nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int? nIdLote { get; set; }
        public string? sLote { get; set; }
        public string sDescripcion { get; set; }
        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int? nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public decimal nValor { get; set; }
        public DateTime dFechaIni { get; set; }
        public string? sFechaIni { get; set; }
        public DateTime? dFechaFin { get; set; }
        public string? sFechaFin { get; set; }
        public bool bActivo { get; set; }
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
