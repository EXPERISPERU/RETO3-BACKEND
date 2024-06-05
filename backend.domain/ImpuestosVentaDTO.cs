using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ImpuestosVentaDTO
    {
        public int nIdImpuestoVenta { get; set; }
        public int nIdCompania { get; set; }
        public string? sAbrev { get; set; }
        public decimal dValor { get; set; }
        public string sValorAbrev { get; set; }
        public int nIdPais { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }

    }
}
