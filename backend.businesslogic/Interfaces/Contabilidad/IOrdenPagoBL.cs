using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Contabilidad
{
    public interface IOrdenPagoBL
    {
        Task<List<OrdenPagoDTO>> getListOrdenPago(int nIdUsuario, int nIdCompania);
        Task<OrdenPagoDTO> getOrdenPagoById(int nIdOrdenPago);
        Task<List<OrdenPagoDetDTO>> getListOrdenPagoDet(int nIdOrdenPago);
        Task<List<bbvaDocumento>> getListOrdenPagoRecaudoBBVAbyDocumento(string sDocumento, int nConvenio);
        Task<bbvaDocumento> getOrdenPagoRecaudoBBVAbyDocumentoAndID(string sDocumento, int nConvenio, int nIdOrdenPago);
    }
}
