using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class CotizacionBL : ICotizacionBL
    {
        ICotizacionRepository repository;

        public CotizacionBL(){}

        public CotizacionBL(ICotizacionRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote)
        {
            return await repository.getSelectCuotaLote(nIdLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote)
        {
            return await repository.getListInicialLote(nIdLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote)
        {
            return await repository.getListDescuentoContLote(nIdLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote)
        {
            return await repository.getListDescuentoFinLote(nIdLote);
        }

        public async Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion)
        {
            cotizacion = await repository.calculateCotizacion(cotizacion);
            this.calculateCotizacionValues(cotizacion);

            return cotizacion;
        }

        public async Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion)
        {
            return await repository.InsCotizacion(cotizacion);
        }

        public async Task<CotizacionDTO> getCotizacionById(int nIdCotizacion)
        {
            return await repository.getCotizacionById(nIdCotizacion);
        }

        public async Task<string> formatoCotizacion(int nIdCotizacion)
        {
            return await repository.formatoCotizacion(nIdCotizacion);
        }

        public async Task<ClienteDTO> getClienteReservaByLote(int nIdLote)
        {
            return await repository.getClienteReservaByLote(nIdLote);
        }

        public async Task<ClienteDTO> getClientePreContratoByLote(int nIdLote)
        { 
            return await repository.getClientePreContratoByLote(nIdLote);
        }

        public async Task<IList<ReporteCotizacionesDTO>> getListReporteCotizaciones(ReporteCotizacionesFiltrosDTO filtros)
        {
            return await repository.getListReporteCotizaciones(filtros);
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }

        public void calculateCotizacionValues(LotesDisponiblesDTO loteDisponible)
        {
            loteDisponible.nPrecioVenta = loteDisponible.nPrecioVentaM2 * loteDisponible.nMetraje;
            
            loteDisponible.nInicial = loteDisponible.nIdInicial != null ? (
                                            loteDisponible.nIdTipoValorIni == 110 ? 
                                                loteDisponible.nValorCalIni : 
                                                loteDisponible.nValorCalIni/100 * loteDisponible.nPrecioVenta
                                        ) : 0;
            
            loteDisponible.nDescuentoFin = loteDisponible.nIdDescuentoFin != null ? (
                                            loteDisponible.nIdTipoValorDescuentoFin == 110 ?
                                            loteDisponible.nValorCalDescuentoFin :
                                            loteDisponible.nValorCalDescuentoFin / 100 * loteDisponible.nPrecioVenta
                                            ) : 0;

            loteDisponible.nInteres = loteDisponible.nIdInteresCuota != null ? (
                                                loteDisponible.nIdTipoValorInteres == 110 ?
                                                loteDisponible.nValorCalInteres :
                                                loteDisponible.nValorCalInteres / 100 * (loteDisponible.nPrecioVenta - loteDisponible.nInicial)
                                            ) : 0;

            loteDisponible.nValorFinanciado = (loteDisponible.nPrecioVenta - loteDisponible.nInicial - loteDisponible.nDescuentoFin) + loteDisponible.nInteres ;

            loteDisponible.nValorCuota = loteDisponible.nValorFinanciado / loteDisponible.nCuotas;

            loteDisponible.nDescuentoCon = loteDisponible.nIdDescuentoCon != null ? (
                                            loteDisponible.nIdTipoValorDescuentoCon == 110 ? 
                                            loteDisponible.nValorCalDescuentoCon : 
                                            loteDisponible.nValorCalDescuentoCon / 100 * loteDisponible.nPrecioVenta
                                            ) : 0;

            loteDisponible.nValorContado = loteDisponible.nPrecioVenta - loteDisponible.nDescuentoCon;
        }

        public async Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota)
        {
            return await repository.getSelectValidaCuotaInteres(nIdProyecto, nIdCuota);
        }
    }
}
