using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Contabilidad
{
    public class OrdenPagoBL : IOrdenPagoBL
    {
        IOrdenPagoRepository repository;

        public OrdenPagoBL(IOrdenPagoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<List<OrdenPagoDTO>> getListOrdenPago(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListOrdenPago(nIdUsuario, nIdCompania);
        }
        
        public async Task<OrdenPagoDTO> getOrdenPagoById(int nIdOrdenPago)
        {
            return await repository.getOrdenPagoById(nIdOrdenPago);
        }
        
        public async Task<List<OrdenPagoDetDTO>> getListOrdenPagoDet(int nIdOrdenPago)
        {
            return await repository.getListOrdenPagoDet(nIdOrdenPago);
        }
        
        public async Task<List<bbvaDocumento>> getListOrdenPagoRecaudoBBVAbyDocumento(string sDocumento, int nConvenio)
        {
            return await repository.getListOrdenPagoRecaudoBBVAbyDocumento(sDocumento, nConvenio);
        }

        public async Task<bbvaDocumento> getOrdenPagoRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdOrdenPago)
        { 
            return await repository.getOrdenPagoRecaudoBBVAbyDocumentoAndID(sDocumento, nConvenio, nIdOrdenPago);
        }
    }
}
