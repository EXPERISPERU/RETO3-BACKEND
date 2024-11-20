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

        public async Task<IList<ComprobanteDTO>> getListComprobante(FilterComprobanteDTO filtroComprobante)
        {
            return await repository.getListComprobante(filtroComprobante);
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

        public async Task<IList<SelectDTO>> getListTipoNotaCredito()
        {
            return await repository.getListTipoNotaCredito();
        }

        public async Task<IList<SelectDTO>> getSelectTipoMotivoBaja()
        {
            return await repository.getSelectTipoMotivoBaja();
        }

        public async Task<SqlRspDTO> InsComprobanteBaja(ComprobanteBajaDTO comprobanteBaja)
        {
            return await repository.InsComprobanteBaja(comprobanteBaja);
        }

        public async Task<IList<LoginDTO>> AuthUserBaja(string sUsuario, string sContrasena)
        {
            return await repository.AuthUserBaja(sUsuario, sContrasena);
        }

        public async Task<ComprobanteBajaDTO> getComprobanteBajaById(int nIdComprobanteBaja)
        {
            return await repository.getComprobanteBajaById(nIdComprobanteBaja);
        }

        public async Task<IList<ComprobanteDTO>> getListComprobanteEgresosCaja(SelectComprobanteEgresoCajaDTO selectComprobanteEgresoCaja)
        {
            return await repository.getListComprobanteEgresosCaja(selectComprobanteEgresoCaja);
        }
    }
}
