using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class TipoCambioDTO
    {
        public int nIdMonedaOrigen { get; set; }
        public int nIdMonedaDestino { get; set; }
        public DateTime dFecha { get; set; }
        public decimal nCompra { get; set; }
        public decimal nVenta { get; set; }
    }
}
