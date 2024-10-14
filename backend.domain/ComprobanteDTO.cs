﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class ComprobanteDTO
    {
        public int nIdComprobante { get; set; }
        public int nIdOrdenPago { get; set; }
        public int nCodigoCompania { get; set; }
        public int nIdCompania { get; set; }
        public string? sCompania { get; set; }
        public string? sRUCCompania { get; set; }
        public int nIdTipoComprobante { get; set; }
        public string? sTipoComprobante { get; set; }
        public string? sCodigoTipoComprobante { get; set; }
        public string sSerie { get; set; }
        public int nCorrelativo { get; set; }
        public string sComprobante { get; set; }
        public int nIdCliente { get; set; }
        public string? sDNI { get; set; }
        public string? sCE { get; set; }
        public string? sRUC { get; set; }
        public string? sCelular { get; set; }
        public string? sTelefono { get; set; }
        public string? sCorreo { get; set; }
        public string sNombreCompleto { get; set; }
        public string sDireccion { get; set; }
        public string sUbigeo { get; set; }
        public decimal nValorNoGravado { get; set; }
        public decimal nValorInafecto { get; set; }
        public decimal nValorSubTotal { get; set; }
        public decimal nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int nIdMoneda { get; set; }
        public string sMoneda { get; set; }
        public string sSunatMoneda { get; set; }
        public string sSimbolo { get; set; }
        public int? nIdAdjunto { get; set; }
        public string? sRutaFtp { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public string sFecha_crea { get; set; }
        #region   AUXILIARES PARA FORMATO COMPROBANTE
        public string? sCondicionPago { get; set; }
        public string? sOrdenPago { get; set; }
        public string? sFechaVencimiento { get; set; }
        public string? sGuiaRemision { get; set; }
        public string? sRazonSocialCompania { get; set; }
        public string? sDireccionCompania { get; set; }
        public string? sUbigeoCompania { get; set; }
        #endregion

        public string sNombrePromotor { get; set; }
        public string sFechaFinReserva { get; set; }
        public string sProyecto { get; set; }
        public string sSector { get; set; }
        public string sManzana { get; set; }
        public string sLote { get; set; }
        public int nMetraje { get; set; }
    }

    public class ComprobanteDetDTO
    {
        public int? nIdComprobanteDet { get; set; }
        public int nIdComprobante { get; set; }
        public string sDescripcion { get; set; }
        public decimal nCantidad { get; set; }
        public int nIdUnidadMedida { get; set; }
        public string sCodigoUnidadMedida { get; set; }
        public string sUnidadMedida { get; set; }
        public decimal nValorUnitario { get; set; }
        public decimal? nValorNoGravado { get; set; }
        public decimal? nValorInafecto { get; set; }
        public decimal? nValorSubTotal { get; set; }
        public decimal? nValorIgv { get; set; }
        public decimal nValorTotal { get; set; }
        public int nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string sUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public string sFecha_crea { get; set; }
    }
}
