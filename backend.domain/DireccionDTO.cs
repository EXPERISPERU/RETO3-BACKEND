using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class DireccionDTO
    {
        public int? nIdDireccion { get; set; }
        public int nIdPersona { get; set; }
        public int? nIdVia { get; set; }
        public string? sTipoVia { get; set; }
        public string? sNombreVia { get; set; }
        public int? nNumeracion { get; set; }
        public string? sBlock { get; set; }
        public int? nPiso { get; set; }
        public string? sDepartamento { get; set; }
        public string? sSector { get; set; }
        public string? sManzana { get; set; }
        public string? sLote { get; set; }
        public decimal? nKm { get; set; }
        public string? sUrbanizacion { get; set; }
        public string? sReferencia { get; set; }
        public string sDireccion { get; set; }
        public int nIdUbigeo { get; set; }
        public string? sUbigeo { get; set; }
        public string? sCodPostal { get; set; }
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
