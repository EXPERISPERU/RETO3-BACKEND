using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using Newtonsoft.Json.Linq;

namespace backend.businesslogic.Contabilidad
{
    public class ComprobanteBL : IComprobanteBL
    {
        IComprobanteRepository repository;

        public ComprobanteBL(IComprobanteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<SqlRspDTO> posInsNotaCredito(NotaCreditoDTO notaCredito)
        {
            return await repository.posInsNotaCredito(notaCredito);
        }

        public async Task<IList<ComprobanteDTO>> getListComprobante(SelectComprobanteDTO selectComprobante)
        {
            return await repository.getListComprobante(selectComprobante);
        }

        public async Task<ComprobanteDTO> getComprobanteById(int nIdComprobante)
        {
            return await repository.getComprobanteById(nIdComprobante);
        }

        public async Task<List<ComprobanteDetDTO>> getComprobanteDetById(int nIdComprobante)
        {
            return await repository.getComprobanteDetById(nIdComprobante);
        }

        public async Task<string> formatoComprobanteByIdComprobante(int nIdComprobante)
        {
            return await repository.formatoComprobanteByIdComprobante(nIdComprobante);
        }

        public async Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp)
        {
            return await repository.InsComprobanteAdjunto(nIdComprobante, sRutaFtp);
        }

        public async Task<SqlRspDTO> InsCertificacionComprobante(int nIdComprobante, string sCodigo, string? sMensaje, string? sCodigoSunat, string? sMensajeSunat, string? sToken, bool bExito)
        {
            return await repository.InsCertificacionComprobante(nIdComprobante, sCodigo, sMensaje, sCodigoSunat, sMensajeSunat, sToken, bExito);
        }

        public async Task<List<int>> getComprobantesPendientesCertByCompania(int nCodigoCompania)
        {
            return await repository.getComprobantesPendientesCertByCompania(nCodigoCompania);
        }

        public async Task<List<ComprobanteMetodoPagoDTO>> getMetodoPagoById(int nIdComprobante)
        {
            return await repository.getMetodoPagoById(nIdComprobante);
        }
    }
}
