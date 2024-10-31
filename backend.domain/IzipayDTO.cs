using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class IzipayComercioDTO
    {
        public int? nIdComercio { get; set; }
        public int nNroComercio { get; set; }
        public int? nNroComercioEstatico { get; set; }
        public int nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public bool bActivo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod  { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod  { get; set; }
    }

    public class IzipayVoucherDTO
    {
        public int? nIdVoucher { get; set; }
        public int nIdProyecto { get; set; }
        public string? sProyecto { get; set; }
        public int nIdComercio { get; set; }
        public int? nNroComercio { get; set; }
        public int? nNroComercioEstatico { get; set; }
        public int nIdTipoVoucher { get; set; }
        public string? sCodigoTipoVoucher { get; set; }
        public string? sTipoVoucher { get; set; }
        public int? nReferencia { get; set; }
        public int? nLote { get; set; }
        public int? nAutorizacion { get; set; }
        public int? nBilletera { get; set; }
        public DateTime dFecha { get; set; }
        public int nIdMoneda { get; set; }
        public string? sMoneda { get; set; }
        public string? sSimbolo { get; set; }
        public decimal nMonto { get; set; }
        public decimal nSaldo { get; set; }
        public int? nIdEstado { get; set; }
        public string? sCodigoEstado { get; set; }
        public string? sCodigo { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }
}
