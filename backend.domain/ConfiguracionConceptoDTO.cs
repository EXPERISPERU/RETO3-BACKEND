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
        public int nIdproyecto { get; set; }
        public string? sIdTipoComprobante { get; set; }
        public string? sIdMedioPago { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int nIdConceptoVenta { get; set; }
    }
}
