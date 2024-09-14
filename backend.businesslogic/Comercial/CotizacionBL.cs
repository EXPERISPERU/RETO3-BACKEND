using backend.businesslogic.Comercial.ParametrosVentaLote;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
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

        public async Task<IList<SqlRspDTO>> getSelectValidaCuotaInteres(int nIdProyecto, int nIdCuota, int? nIdContrato)
        {
            return await repository.getSelectValidaCuotaInteres(nIdProyecto, nIdCuota, nIdContrato);
        }

        public async Task<IList<SelectInteresDTO>> getListInteresLote(int nIdLote, int nIdInicial, int nIdDescuento, int nIdCuotaLote) 
        {
            return await repository.getListInteresLote(nIdLote, nIdInicial, nIdDescuento, nIdCuotaLote);
        }

        public async Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri)
        {
            return await repository.getTipoCambio(nIdLote, nIdMonedaOri);
        }

        public async void calculateCotizacionValues(LotesDisponiblesDTO loteDisponible)
        {
            try
            {
                loteDisponible.nPrecioVenta = loteDisponible.nPrecioVentaM2 * loteDisponible.nMetraje;

                CuotaLoteDTO cuota = new CuotaLoteDTO();

                if (loteDisponible.nIdCuota.HasValue)
                {
                    cuota = (CuotaLoteDTO) await new CuotaLoteBL().getCuotaLoteByID((int)loteDisponible.nIdCuota);
                }

                InicialLoteDTO inicial = new InicialLoteDTO();

                if (loteDisponible.nIdInicial.HasValue)
                {
                    inicial = (InicialLoteDTO) await new InicialLoteBL().getInicialLoteByID((int)loteDisponible.nIdInicial);
                }

                DescuentoLoteDTO descuentoFin = new DescuentoLoteDTO();

                if (loteDisponible.nIdDescuentoFin.HasValue)
                {
                    descuentoFin = (DescuentoLoteDTO) await new DescuentoLoteBL().getDescuentoLoteByID((int)loteDisponible.nIdDescuentoFin);
                }

                InteresCuotaDTO interes = new InteresCuotaDTO();

                if (loteDisponible.nIdInteresCuota.HasValue)
                {
                    interes = (InteresCuotaDTO) await new InteresCuotaBL().getInteresCuotaByID((int)loteDisponible.nIdInteresCuota);
                }

                DescuentoLoteDTO descuentoCon = new DescuentoLoteDTO();

                if (loteDisponible.nIdDescuentoCon.HasValue)
                {
                    descuentoCon = (DescuentoLoteDTO) await new DescuentoLoteBL().getDescuentoLoteByID((int)loteDisponible.nIdDescuentoCon);
                }

                loteDisponible.nInicial = loteDisponible.nIdInicial != null ? (
                                                loteDisponible.nIdTipoValorIni == 110 ?
                                                    loteDisponible.nValorCalIni :
                                                    loteDisponible.nValorCalIni / 100 * loteDisponible.nPrecioVenta
                                            ) : 0;

                loteDisponible.nDescuentoFin = loteDisponible.nIdDescuentoFin != null ? (
                                                loteDisponible.nIdTipoValorDescuentoFin == 110 ?
                                                loteDisponible.nValorCalDescuentoFin :
                                                loteDisponible.nValorCalDescuentoFin / 100 * loteDisponible.nPrecioVenta
                                                ) : 0;

                loteDisponible.nInteres = loteDisponible.nIdInteresCuota != null ? (
                                                    loteDisponible.nIdTipoValorInteres == 110 ?
                                                    loteDisponible.nValorCalInteres :
                                                    loteDisponible.nValorCalInteres / 100 * (loteDisponible.nPrecioVenta - loteDisponible.nValorCalIni)
                                                ) : 0;

                loteDisponible.nValorFinanciado = (loteDisponible.nPrecioVenta - loteDisponible.nInicial - loteDisponible.nDescuentoFin) + loteDisponible.nInteres;

                loteDisponible.nValorCuota = loteDisponible.nCuotas > 0 ? loteDisponible.nValorFinanciado / loteDisponible.nCuotas : 0;

                loteDisponible.nDescuentoCon = loteDisponible.nIdDescuentoCon != null ? (
                                                loteDisponible.nIdTipoValorDescuentoCon == 110 ?
                                                loteDisponible.nValorCalDescuentoCon :
                                                loteDisponible.nValorCalDescuentoCon / 100 * loteDisponible.nPrecioVenta
                                                ) : 0;

                loteDisponible.nValorContado = loteDisponible.nPrecioVenta - loteDisponible.nDescuentoCon;
            }
            catch (Exception e)
            {
                loteDisponible = null;
            }
        }
    }
}
