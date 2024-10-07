using backend.domain;

namespace backend.repository.Interfaces.Comercial
{
    public interface ICotizacionRepository
    {
        Task<IList<SelectDTO>> getSelectCuotaLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion);
        Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion);
        Task<CotizacionDTO> getCotizacionById(int nIdCotizacion);
        Task<string> formatoCotizacion(int nIdCotizacion);
        Task<ClienteDTO> getClienteReservaByLote(int nIdLote);
        Task<ClienteDTO> getClientePreContratoByLote(int nIdLote);
        Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato);
        Task<IList<SelectInteresDTO>> getListInteresLote(getSelectCotizacionDTO selectCotizacionDTO);
        Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri, int? nIdMonedaDest);
        Task<IList<CotizacionChartDTO>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter);
    }
}
