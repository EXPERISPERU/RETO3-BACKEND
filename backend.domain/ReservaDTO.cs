﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class InsReservaDTO
    {
        public int nIdLote { get; set; }
        public int nIdCliente { get; set; }
        public int nIdPrecioServicio { get; set; }
        public int nIdTipoGestionComercial { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public int? nIdEmpleado { get; set; }
        public int nIdUsuario_crea { get; set; }
    }

    public class ReciboIngresoReservaDTO
    {
        
    }
}
