using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Contabilidad
{
    public interface IOrdenPagoRepository
    {
        Task<List<OrdenPagoDTO>> getListOrdenPago(int nIdUsuario, int nIdCompania);
        Task<ComprobanteDTO> getOrdenPagoById(int nIdOrdenPago);
        Task<List<OrdenPagoDetDTO>> getListOrdenPagoDet(int nIdOrdenPago);
        Task<List<bbvaDocumento>> getListOrdenPagoRecaudoBBVAbyDocumento(string sDocumento, int nCodigoProyecto);
    }
}
