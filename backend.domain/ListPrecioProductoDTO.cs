using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ParamPrecioProductoDTO
    {
        public int? nIdConcepto { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdContrato { get; set; }
    }

    public class ListPrecioProductoDTO
    {
        public int? nIdPrecioProducto { get; set; }
        public int? nIdConcepto { get; set; }
        public string sConcepto { get; set; }
        public decimal? nValor { get; set; }
        public int? nIdMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public string? sMoneda { get; set; }
    }


}
