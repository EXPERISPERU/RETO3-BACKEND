﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class DescuentoLoteDTO
    {
        public int nIdDescuentoLote { get; set; }
        public string? sDescripcion { get; set; }
        public int nIdTipo { get; set; }
        public string? sTipo { get; set; }
        public int? nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public decimal nValor { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
