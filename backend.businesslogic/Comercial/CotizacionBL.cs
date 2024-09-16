using backend.businesslogic.Comercial.ParametrosVentaLote;
using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Comercial.ParametrosVentaLote;
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
        ICuotaLoteRepository cuotaLoteRepository;
        IInicialLoteRepository inicialLoteRepository;
        IDescuentoLoteRepository descuentoLoteRepository;
        IInteresCuotaRepository interesCuotaRepository;

        public CotizacionBL(
            ICotizacionRepository _repository,
            ICuotaLoteRepository _cuotaLoteRepository,
            IInicialLoteRepository _inicialLoteRepository,
            IDescuentoLoteRepository _descuentoLoteRepository,
            IInteresCuotaRepository _interesCuotaRepository
        )
        {
            this.repository = _repository;
            this.cuotaLoteRepository = _cuotaLoteRepository;
            this.inicialLoteRepository = _inicialLoteRepository;
            this.descuentoLoteRepository = _descuentoLoteRepository;
            this.interesCuotaRepository = _interesCuotaRepository;
        }

        public async Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote, int? nIdInicialLote, int? nIdDescuentoLote)
        {
            return await repository.getSelectCuotaLote(nIdLote, nIdInicialLote, nIdDescuentoLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote, int? nIdDescuentoLote, int? nIdCuotaLote)
        {
            return await repository.getListInicialLote(nIdLote, nIdDescuentoLote, nIdCuotaLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote)
        {
            return await repository.getListDescuentoContLote(nIdLote);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote, int? nIdInicialLote, int? nIdCuotaLote)
        {
            return await repository.getListDescuentoFinLote(nIdLote, nIdInicialLote, nIdCuotaLote);
        }

        public async Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion)
        {
            cotizacion = await repository.calculateCotizacion(cotizacion);
            await this.calculateCotizacionValues(cotizacion, true);

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

        public async Task<IList<SelectInteresDTO>> getListInteresLote(int nIdLote, int? nIdInicial, int? nIdDescuento, int? nIdCuotaLote) 
        {
            return await repository.getListInteresLote(nIdLote, nIdInicial, nIdDescuento, nIdCuotaLote);
        }

        public async Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri)
        {
            return await repository.getTipoCambio(nIdLote, nIdMonedaOri);
        }

        public async Task calculateCotizacionValues(LotesDisponiblesDTO loteDisponible, bool bIndividual)
        {
            try
            {
                loteDisponible.nPrecioVenta = loteDisponible.nPrecioVentaM2 * loteDisponible.nMetraje;

                #region OBTENER CONDICIONES PRECONTRATO
                CuotaLoteDTO cuota = null;

                if (loteDisponible.nIdCuota.HasValue)
                {
                    cuota = (CuotaLoteDTO)await cuotaLoteRepository.getCuotaLoteByID((int)loteDisponible.nIdCuota);
                }

                InicialLoteDTO inicial = null;

                if (loteDisponible.nIdInicial.HasValue)
                {
                    inicial = (InicialLoteDTO) await inicialLoteRepository.getInicialLoteByID((int)loteDisponible.nIdInicial);
                }

                DescuentoLoteDTO descuentoFin = null;

                if (loteDisponible.nIdDescuentoFin.HasValue)
                {
                    descuentoFin = (DescuentoLoteDTO) await descuentoLoteRepository.getDescuentoLoteByID((int)loteDisponible.nIdDescuentoFin);
                }

                InteresCuotaDTO interes = null;

                if (loteDisponible.nIdInteresCuota.HasValue)
                {
                    interes = (InteresCuotaDTO) await interesCuotaRepository.getInteresCuotaByID((int)loteDisponible.nIdInteresCuota);
                }

                DescuentoLoteDTO descuentoCon = null;

                if (loteDisponible.nIdDescuentoCon.HasValue)
                {
                    descuentoCon = (DescuentoLoteDTO) await descuentoLoteRepository.getDescuentoLoteByID((int)loteDisponible.nIdDescuentoCon);
                }
                #endregion

                #region OBTENER CONDICIONES POR DEFECTO
                if (!bIndividual && (loteDisponible.nIdContrato == 0 || loteDisponible.nIdContrato == null))
                { 
                    switch (loteDisponible.nCodigoCompania)
                    {
                        case 3:
                            List<InicialDescuentoDTO> listInicial = (List<InicialDescuentoDTO>)await getListInicialLote(loteDisponible.nIdLote, null, null) ;
                            inicial = (InicialLoteDTO) await inicialLoteRepository.getInicialLoteByID(listInicial.Count > 0 ? listInicial.ToList()[0].nId : 0) ;

                            List<SelectDTO> listCuota = (List<SelectDTO>) await getSelectCuotaLote(loteDisponible.nIdLote, null, null);
                            cuota = (CuotaLoteDTO)await cuotaLoteRepository.getCuotaLoteByID(listCuota.Count > 0 ? listCuota.ToList()[0].nCod : 0);

                            List<InicialDescuentoDTO> listDescuentoFin = (List<InicialDescuentoDTO>)await getListDescuentoFinLote(loteDisponible.nIdLote, null, null);
                            descuentoFin = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoFin.Count > 0 ? listDescuentoFin.ToList()[0].nId : 0);

                            List<SelectInteresDTO> listInteres = (List<SelectInteresDTO>)await getListInteresLote(loteDisponible.nIdLote, inicial != null ? inicial.nIdInicialLote : null, null, null);
                            interes = (InteresCuotaDTO)await interesCuotaRepository.getInteresCuotaByID(listInteres.Count > 0 ? listInteres.ToList()[0].nId : 0);

                            List<InicialDescuentoDTO> listDescuentoCon = (List<InicialDescuentoDTO>)await getListDescuentoContLote(loteDisponible.nIdLote);
                            descuentoCon = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoCon.Count > 0 ? listDescuentoCon.ToList()[0].nId : 0);

                            break;
                    }
                }
                #endregion

                #region INICIAL
                if (inicial != null)
                {
                    loteDisponible.nIdInicial = inicial.nIdInicialLote;
                    loteDisponible.nIdTipoValorIni = inicial.nIdTipo;
                    loteDisponible.nValorOriIni = inicial.nValor;

                    if (inicial.sCodigoTipo == "1")
                    {
                        loteDisponible.sSimboloIni = inicial.sSimbolo;
                        if (inicial.nIdMoneda == loteDisponible.nIdMoneda)
                        {
                            loteDisponible.nValorCalIni = inicial.nValor;
                        }
                        else
                        {
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)inicial.nIdMoneda);
                            loteDisponible.nValorCalIni = inicial.nValor * tipoCambio.nVenta;
                        }
                    }
                    else
                    {
                        loteDisponible.sSimboloIni = "%";
                        loteDisponible.nValorCalIni = inicial.nValor;
                    }

                    loteDisponible.nInicial = loteDisponible.nIdInicial != null ? (
                                                    loteDisponible.nIdTipoValorIni == 110 ?
                                                        loteDisponible.nValorCalIni :
                                                        loteDisponible.nValorCalIni / 100 * loteDisponible.nPrecioVenta
                                                ) : 0;
                }
                else
                {
                    loteDisponible.nInicial = 0;
                }
                #endregion

                #region DESCUENTO FINANCIADO
                if (descuentoFin != null)
                {
                    loteDisponible.nIdDescuentoFin = descuentoFin.nIdDescuentoLote;
                    loteDisponible.nIdTipoValorDescuentoFin = descuentoFin.nIdTipo;
                    loteDisponible.nValorOriDescuentoFin = descuentoFin.nValor;

                    if (descuentoFin.sCodigoTipo == "1")
                    {
                        loteDisponible.sSimboloDescuentoFin = descuentoFin.sSimbolo;
                        if (descuentoFin.nIdMoneda == loteDisponible.nIdMoneda)
                        {
                            loteDisponible.nValorCalDescuentoFin = descuentoFin.nValor;
                        }
                        else
                        {
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)descuentoFin.nIdMoneda);
                            loteDisponible.nValorCalDescuentoFin = descuentoFin.nValor * tipoCambio.nVenta;
                        }
                    }
                    else
                    {
                        loteDisponible.sSimboloDescuentoFin = "%";
                        loteDisponible.nValorCalDescuentoFin = descuentoFin.nValor;
                    }

                    loteDisponible.nDescuentoFin = loteDisponible.nIdDescuentoFin != null ? (
                                                    loteDisponible.nIdTipoValorDescuentoFin == 110 ?
                                                    loteDisponible.nValorCalDescuentoFin :
                                                    loteDisponible.nValorCalDescuentoFin / 100 * loteDisponible.nPrecioVenta
                                                    ) : 0;
                }
                else 
                {
                    loteDisponible.nDescuentoFin = 0;
                }

                #endregion

                #region INTERES
                if (interes != null)
                {
                    loteDisponible.nIdInteresCuota = interes.nIdInteresCuota;

                    if (interes.sCodigoTipoValor == "1")
                    {
                        loteDisponible.sSimboloInteres = "";
                        if (interes.nIdMoneda == loteDisponible.nIdMoneda)
                        {
                            loteDisponible.nValorCalInteres = descuentoFin.nValor;
                        }
                        else
                        {
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)interes.nIdMoneda);
                            loteDisponible.nValorCalInteres = interes.nValor * tipoCambio.nVenta;
                        }
                    }
                    else
                    {
                        loteDisponible.sSimboloInteres = "%";
                        loteDisponible.nValorCalInteres = interes.nValor;
                    }

                    if (interes.sCodigoTipoInteres == "1")
                    {
                        loteDisponible.nInteres = loteDisponible.nIdInteresCuota != null ? (
                                                            loteDisponible.nIdTipoValorInteres == 110 ?
                                                            loteDisponible.nValorCalInteres :
                                                            loteDisponible.nValorCalInteres / 100 * (loteDisponible.nPrecioVenta - loteDisponible.nValorCalIni)
                                                        ) : 0;
                    }
                }
                else
                {
                    loteDisponible.nInteres = 0;
                }
                #endregion

                loteDisponible.nValorFinanciado = (loteDisponible.nPrecioVenta - loteDisponible.nInicial - loteDisponible.nDescuentoFin) + loteDisponible.nInteres;

                #region CUOTA
                if (cuota != null)
                {
                    loteDisponible.nIdCuota = cuota.nIdCuotaLote;
                    loteDisponible.nCuotas = cuota.nCuotas;

                    loteDisponible.nValorCuota = loteDisponible.nCuotas > 0 ? loteDisponible.nValorFinanciado / loteDisponible.nCuotas : 0;
                }
                #endregion

                #region DESCUENTO CONTADO
                if (descuentoCon != null)
                {
                    loteDisponible.nIdDescuentoCon = descuentoCon.nIdDescuentoLote;
                    loteDisponible.nIdTipoValorDescuentoCon = descuentoCon.nIdTipo;
                    loteDisponible.nValorOriDescuentoCon = descuentoCon.nValor;

                    if (descuentoCon.sCodigoTipo == "1")
                    {
                        loteDisponible.sSimboloDescuentoCon = descuentoCon.sSimbolo;
                        if (descuentoCon.nIdMoneda == loteDisponible.nIdMoneda)
                        {
                            loteDisponible.nValorCalDescuentoCon = descuentoCon.nValor;
                        }
                        else
                        {
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)descuentoCon.nIdMoneda);
                            loteDisponible.nValorCalDescuentoCon = descuentoCon.nValor * tipoCambio.nVenta;
                        }
                    }
                    else
                    {
                        loteDisponible.sSimboloDescuentoCon = "%";
                        loteDisponible.nValorCalDescuentoCon = descuentoCon.nValor;
                    }

                    loteDisponible.nDescuentoCon = loteDisponible.nIdDescuentoCon != null ? (
                                                    loteDisponible.nIdTipoValorDescuentoCon == 110 ?
                                                    loteDisponible.nValorCalDescuentoCon :
                                                    loteDisponible.nValorCalDescuentoCon / 100 * loteDisponible.nPrecioVenta
                                                    ) : 0;
                }
                else 
                {
                    loteDisponible.nDescuentoCon = 0;
                }
                #endregion

                loteDisponible.nValorContado = loteDisponible.nPrecioVenta - loteDisponible.nDescuentoCon;
            }
            catch (Exception e)
            {
                loteDisponible = null;
            }
        }
    }
}
