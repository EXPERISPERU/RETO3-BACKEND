using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class CronogramaDTO
    {
        public int? nIdCronograma { get; set; }
        public int? nIdCompania { get; set; }
        public int nIdContrato { get; set; }
        public int nIdEstado { get; set; }
        public string? sEstado { get; set; }
        public int nNroCuota { get; set; }
        public int nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public decimal nMonto { get; set; }
        public int nMontoMora { get; set; }
        public decimal nMontoFinal { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public string? sFechaVencimiento { get; set; }
        public DateTime dFechaPago { get; set; }
        public string? sFechaPago { get; set; }
        public int? nIdComprobante { get; set; }
    }
}
