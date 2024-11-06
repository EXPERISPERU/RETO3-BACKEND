using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Contabilidad
{
    public interface IComprobanteRepository
    {
        Task<SqlRspDTO> posInsNotaCredito(NotaCreditoDTO notaCredito);
        Task<IList<ComprobanteDTO>> getListComprobante(SelectComprobanteDTO selectComprobante);
        Task<ComprobanteDTO> getComprobanteById(int nIdComprobante);
        Task<List<ComprobanteDetDTO>> getComprobanteDetById(int nIdComprobante);
        Task<string> formatoComprobanteByIdComprobante(int nIdComprobante);
        Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp);
        Task<SqlRspDTO> InsCertificacionComprobante(int nIdComprobante, string sCodigo, string? sMensaje, string? sCodigoSunat, string? sMensajeSunat, string? sToken, bool bExito);
        Task<List<int>> getComprobantesPendientesCertByCompania(int nCodigoCompania);
        Task<List<ComprobanteMetodoPagoDTO>> getMetodoPagoById(int nIdComprobante);
    }
}
