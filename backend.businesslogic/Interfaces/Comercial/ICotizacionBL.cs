﻿using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ICotizacionBL
    {
        Task<IList<SelectDTO>> getSelectCuotaLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion);
        Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion);
        Task<CotizacionDTO> getCotizacionById(int nIdCotizacion);
        Task<string> formatoCotizacion(getFormatoCotizacionDTO getFormatoCotizacion);
        Task<ClienteDTO> getClienteReservaByLote(int nIdLote);
        Task<ClienteDTO> getClientePreContratoByLote(int nIdLote);
        Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato);
        Task<IList<SelectInteresDTO>> getListInteresLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri, int? nIdMonedaDest);
        Task calculateCotizacionValues(LotesDisponiblesDTO loteDisponible, bool bIndividual);
        Task<IList<CotizacionChartDTO>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter);
    }
}
