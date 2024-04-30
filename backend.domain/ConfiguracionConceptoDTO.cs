using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ConfiguracionConceptoDTO
    {
        public int nIdConfiguracionConcepto { get; set; }
        public int nIdConfiguracion { get; set; }
        public int nIdproyecto { get; set; }
        public string? sIdTipoComprobanteMedioPago { get; set; }
        public bool bActivo { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime dFecha_crea { get; set; }
        public DateTime? dFecha_mod { get; set; }
        public int nIdConceptoVenta { get; set; }
        public string? sConceptoVenta { get; set; }
    }


    public class tipoComprobante
    {
        public string? sAbrev { get; set; }
        public int? nIdElemento { get; set; }
        public bool? seleccionado { get; set; }
    }
}
