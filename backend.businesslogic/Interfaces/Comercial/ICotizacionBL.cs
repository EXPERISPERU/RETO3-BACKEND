using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ICotizacionBL
    {
        Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote, int? nIdInicialLote, int? nIdDescuentoLote);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote, int? nIdDescuentoLote, int? nIdCuotaLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote, int? nIdInicialLote, int? nIdCuotaLote);
        Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion);
        Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion);
        Task<CotizacionDTO> getCotizacionById(int nIdCotizacion);
        Task<string> formatoCotizacion(int nIdCotizacion);
        Task<ClienteDTO> getClienteReservaByLote(int nIdLote);
        Task<ClienteDTO> getClientePreContratoByLote(int nIdLote);
        Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato);
        Task<IList<SelectInteresDTO>> getListInteresLote(int nIdLote, int? nIdInicial, int? nIdDescuento, int? nIdCuotaLote);
        Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri, int? nIdMonedaDest);
        Task calculateCotizacionValues(LotesDisponiblesDTO loteDisponible, bool bIndividual);
        Task<IList<CotizacionChartDTO>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter);
    }
}
