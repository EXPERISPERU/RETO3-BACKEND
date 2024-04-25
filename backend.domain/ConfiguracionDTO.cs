﻿using System;
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
        public string? sIdConfiguracion { get; set; }
        public int nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }

    }
}
