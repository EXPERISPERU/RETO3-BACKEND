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

        public async Task<IList<ComprobanteDTO>> getListComprobante(int pagina, int cantpagina)
        {
            return await repository.getListComprobante(pagina, cantpagina);
        }

        public async Task<ComprobanteDTO> getComprobanteById(int nIdComprobante)
        {
            return await repository.getComprobanteById(nIdComprobante);
        }

        public async Task<List<ComprobanteDetDTO>> getComprobanteDetById(int nIdComprobante)
        {
            return await repository.getComprobanteDetById(nIdComprobante);
        }

        public async Task<string> formatoComprobanteByIdComprobante(int nIdCompania, int nIdProyecto, int nIdComprobante)
        {
            return await repository.formatoComprobanteByIdComprobante(nIdCompania, nIdProyecto, nIdComprobante);
        }

        public async Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp)
        {
            return await repository.InsComprobanteAdjunto(nIdComprobante, sRutaFtp);
        }

        public async Task<SqlRspDTO> InsCertificacionComprobante(int nIdComprobante, string sCodigo, string? sMensaje, string? sCodigoSunat, string? sMensajeSunat, string? sToken)
        {
            return await repository.InsCertificacionComprobante(nIdComprobante, sCodigo, sMensaje, sCodigoSunat, sMensajeSunat, sToken);
        }
    }
}
