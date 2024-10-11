﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class LotesDisponiblesFiltrosDTO
    {
        public int nIdProyecto { get; set; }
        public string sProyecto { get; set; }
        public int nIdSector { get; set; }
        public string sSector { get; set; }
        public int nIdManzana { get; set; }
        public string sManzana { get; set; }
        public int nIdLote { get; set; }
        public string sLote { get; set; }
    }

    public class SelectLotesDisponiblesDTO 
    { 
        public int nIdCompania { get; set; }
        public int nIdUsuario { get; set; }
        public int PageNumber { get; set; } 
        public int RowspPage { get; set; }
        public int? nIdProyecto { get; set; }
        public int? nIdSector { get; set; }
        public int? nIdManzana { get; set; }
        public int? nIdLote { get; set; }
    }

    public class LotesDisponiblesDTO
    {
        public int? nTotalTabla { get; set; }
        public int? nIdCompania { get; set; }
        public int? nCodigoCompania { get; set; }
        public string? sCompania { get; set; }
        public int? nCodigoProyecto { get; set; }
        public int nIdProyecto { get; set; }
        public string sProyecto { get; set; }
        public int nIdSector { get; set; }
        public string sSector { get; set; }
        public int nIdManzana { get; set; }
        public string sManzana { get; set; }
        public int? Id_Old { get; set; }
        public int nIdLote { get; set; }
        public string sLote { get; set; }
        public int? nIdEstado { get; set; }
        public string? sCodigoEstado { get; set; }
        public string? sEstado { get; set; }
        public int nIdGrupo { get; set; }
        public string sGrupo { get; set; }
        public int nIdUbicacion { get; set; }
        public string sUbicacion { get; set; }
        public int nIdTerreno { get; set; }
        public string? sTerreno { get; set; }
        public int nIdZonificacion { get; set; }
        public string? sZonificacion { get; set; }
        public int nIdDescripcion { get; set; }
        public string? sDescripcion { get; set; }
        public int nIdMoneda { get; set; }
        public string sSimbolo { get; set; }
        public int? nIdAsignacionPrecio { get; set; }
        public decimal? nPrecioVentaM2 { get; set; }
        public decimal nMetraje { get; set; }
        public decimal? nPrecioVenta { get; set; }
        public int? nIdInicial { get; set; }
        public int? nIdTipoValorIni { get; set; }
        public string? sSimboloIni { get; set; }
        public decimal? nValorOriIni { get; set; }
        public decimal? nValorCalIni { get; set; }
        public decimal? nInicial { get; set; }
        public int? nIdDescuentoFin { get; set; }
        public int? nIdTipoValorDescuentoFin { get; set; }
        public string? sSimboloDescuentoFin { get; set; }
        public decimal? nValorOriDescuentoFin { get; set; }
        public decimal? nValorCalDescuentoFin { get; set; }
        public decimal? nDescuentoFin { get; set; }
        public int? nIdInteresCuota { get; set; }
        public decimal? nInteresCuota { get; set; }
        public string? sInteresCuota { get; set; }
        public string? sCodigoTipoInteresCuota { get; set; }
        public string? sCodigoTipoValorInteresCuota { get; set; }
        public decimal? nValorCalInteresCuota { get; set; }
        public decimal? nValorFinanciado { get; set; }
        public int? nIdCuota { get; set; }
        public decimal? nCuotas { get; set; }
        public decimal? nValorCuota { get; set; }
        public int? nIdDescuentoCon { get; set; }
        public int? nIdTipoValorDescuentoCon { get; set; }
        public string? sSimboloDescuentoCon { get; set; }
        public decimal? nValorOriDescuentoCon { get; set; }
        public decimal? nValorCalDescuentoCon { get; set; }
        public decimal? nDescuentoCon { get; set; }
        public decimal? nValorContado { get; set; }
        public string? sIdConceptoVenta { get; set; }
        public int? cantPreContratos { get; set; }
        public int? nIdContrato { get; set; }
        //Nuevos campos
        public int? nIdTipoItem { get; set; }
        public int? nIdCliente { get; set; }
    }
}
