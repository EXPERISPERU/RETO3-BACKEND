using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public  class CajaDTO
    {
        public int? nIdCaja { get; set; }
        public int? nIdUsuario_apertura { get; set; }
        public DateTime? dFecha_Apertura { get; set; }
        public decimal nMontoApertura { get; set; }
        public int? nIdUsuario_cierre { get; set; }
        public DateTime? dFecha_Cierre { get; set; }
        public decimal nMontoCierre { get; set; }
        public int nIdTipoMovimiento { get; set; }
        public int nIdEstado { get; set; }
        public int nIdCompania { get; set; }

        //OTROS
        public decimal nTotalIngresos { get; set; }
        public decimal nTotalEgresos { get; set; }


        /*
            [nIdCaja] [int] IDENTITY(1,1) NOT NULL,
            [nIdUsuario_apertura] [int] NULL,
            [dFecha_Apertura] [datetime] NULL,
            [nMontoApertura] [decimal](13, 4) NULL,
            [nIdUsuario_cierre] [int] NULL,
            [dFecha_Cierre] [datetime] NULL,
            [nMontoCierre] [decimal](13, 4) NULL,
            [nIdTipoMovimiento] [int] NOT NULL,
            [nIdEstado] [int] NOT NULL,
            [nIdCompania] [int] NOT NULL,
         */

    }
}
