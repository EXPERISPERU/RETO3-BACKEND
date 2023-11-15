using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface ICotizacionRepository
    {
        Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote);
        Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion, int nIdCompania);
        Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion, int nIdCompania);
        Task<CotizacionDTO> getCotizacionById(int nIdCotizacion);
        Task<string> formatoCotizacion();
    }
}
