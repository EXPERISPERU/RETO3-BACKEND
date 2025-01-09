﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class AgendamientoDTO
    {
        public int? nIdAgendamiento { get; set; }
        public int nIdTipoAgendamiento { get; set; }
        public int? nIdSeguimientoCuota { get; set; }
        public string? sTipoAgendamiento { get; set; }
        public int? nIdSeguimiento { get; set; }
        public int? nIdSegFromAgen { get; set; }
        public int? nIdCliente { get; set; }
        public string? sCodigo { get; set; }
        public int? nIdProspecto { get; set; }
        public string? sNombreProspecto { get; set; }
        public int? nIdPersona { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sNombreCliente { get; set; }
        public int? nIdTipoGestion { get; set; }
        public int? nIdEmpleado { get; set; }
        public string? sNombreAsesor { get; set; }
        public int? nIdAgenteDealer { get; set; }
        public DateTime? dFechaPrev { get; set; }
        public DateTime? dFecha { get; set; }
        public string? sDescripcion { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sEstado { get; set; }
    }

    public class AgendamientoFiltrosDTO
    {
        public int? nIdCompania { get; set; }
        public int? nIdUsuario { get; set; }
        public int? nIdAsesor { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdProspecto { get; set; }
        public int? nIdTipoDocumento { get; set; }
        public string? sDocumento { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public int? tipoListSeguimiento { get; set; }
    }

    public class AgendamientoChartDTO
    {
        public int nIdPersona { get; set; }
        public int nIdAsesor { get; set; }
        public string? sNombreAsesor { get; set; }
        public DateTime dFecha { get; set; }
        public int? nCountAgendamiento { get; set; }
    }

    public class AgendamientoChartFilterDTO
    {
        public int nIdUsuario { get; set; }
        public int nIdCompania { get; set; }
        public int? nIdProyecto { get; set; }
        public string? sCodTrimestre { get; set; }
        public string? sMes { get; set; }
        public string? sAno { get; set; }
        public int? nIdSubordinado { get; set; }
    }
}
