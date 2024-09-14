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
        Task<string> formatoCotizacion(int nIdCotizacion);
        Task<ClienteDTO> getClienteReservaByLote(int nIdLote);
        Task<ClienteDTO> getClientePreContratoByLote(int nIdLote);
        Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato);
        Task<IList<SelectInteresDTO>> getListInteresLote(int nIdLote, int nIdInicial, int nIdDescuento, int nIdCuotaLote);
        Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri);
    }
}
