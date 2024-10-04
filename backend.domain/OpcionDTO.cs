﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class OpcionDTO
    {
        public int? nIdOpcion { get; set; }
        public int? nIdOpcionP { get; set; }
        public string sOpcion { get; set; }
        public string? sDescripcion { get; set; } 
        public string? sRuta { get; set; } 
        public int nIdTipoOpcion { get; set; }
        public bool bActivo { get; set; }
    }


    public class OpcionByPerfilDTO
    {
        public int? nIdPerfil { get; set; }
        public int? nIdOpcion { get; set; }
        public int? nIdOpcionP { get; set; }
        public string? sCodigo { get; set; }
        public string sOpcion { get; set; }
        public string? sRuta { get; set; }
        public int nIdTipoOpcion { get; set; }
        public bool bActivo { get; set; }
    }

    public class PermisosDashboardDTO
    {
        public string? sNombreComponente { get; set; }
        public int? nPerfilUsuario { get; set; }
    }
}
