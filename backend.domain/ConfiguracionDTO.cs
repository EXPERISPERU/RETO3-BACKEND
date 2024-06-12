using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ConfiguracionDTO
    {

        public int nIdConfiguracion { get; set; }
        public int nIdProyecto { get; set; }
        public int nIdMoneda { get; set; }
        public bool bImpuestoVenta { get; set; }
        //public int nIdImpuestoVenta { get; set; }
        public string? sIdInteres { get; set; }
        public string? sIdDocumentoVenta { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public string? sIdDocumentosContratos { get; set; }

        public bool bTipoCambio { get; set; }

    }
    /*
    public class ItemCompaniaDTO
    {
        public int? nIdItemCompania { get; set; }
        public int? nIdItem { get; set; }
        public string? sItem { get; set; }
        public int? nIdCompania { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
    */

}
