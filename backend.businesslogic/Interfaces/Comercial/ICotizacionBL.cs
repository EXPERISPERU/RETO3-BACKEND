using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ICotizacionBL
    {
        Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote);
        Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion);
        Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion);
        Task<CotizacionDTO> getCotizacionById(int nIdCotizacion);
        Task<string> formatoCotizacion();
        Task<ClienteDTO> getClienteReservaByLote(int nIdLote);
        Task<ClienteDTO> getClientePreContratoByLote(int nIdLote);
        Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros);
    }
}
