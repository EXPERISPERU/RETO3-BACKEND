using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using backend.repository.Interfaces.Maestros;

namespace backend.businesslogic.Comercial
{
    public class CotizacionBL : ICotizacionBL
    {
        ICotizacionRepository repository;
        ICuotaLoteRepository cuotaLoteRepository;
        IInicialLoteRepository inicialLoteRepository;
        IDescuentoLoteRepository descuentoLoteRepository;
        IInteresCuotaRepository interesCuotaRepository;
        IAsignacionPrecioRepository asignacionPrecioRepository;
        IMonedaRepository monedaRepository;

        public CotizacionBL(
            ICotizacionRepository _repository,
            ICuotaLoteRepository _cuotaLoteRepository,
            IInicialLoteRepository _inicialLoteRepository,
            IDescuentoLoteRepository _descuentoLoteRepository,
            IInteresCuotaRepository _interesCuotaRepository,
            IAsignacionPrecioRepository _asignacionPrecioRepository,
            IMonedaRepository _monedaRepository
        )
        {
            this.repository = _repository;
            this.cuotaLoteRepository = _cuotaLoteRepository;
            this.inicialLoteRepository = _inicialLoteRepository;
            this.descuentoLoteRepository = _descuentoLoteRepository;
            this.interesCuotaRepository = _interesCuotaRepository;
            this.asignacionPrecioRepository = _asignacionPrecioRepository;
            this.monedaRepository = _monedaRepository;
        }

        public async Task<IList<SelectDTO>> getSelectCuotaLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            return await repository.getSelectCuotaLote(selectCotizacionDTO);
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            return await repository.getListInicialLote(selectCotizacionDTO);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            return await repository.getListDescuentoContLote(selectCotizacionDTO);
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(getSelectCotizacionDTO selectCotizacionDTO)
        {
            return await repository.getListDescuentoFinLote(selectCotizacionDTO);
        }

        public async Task<CotizacionDTO> calculateCotizacion(CotizacionDTO cotizacion)
        {
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

        public async Task<IList<SelectInteresDTO>> getListInteresLote(getSelectCotizacionDTO selectCotizacionDTO) 
        {
            return await repository.getListInteresLote(selectCotizacionDTO);
        }

        public async Task<TipoCambioDTO> getTipoCambio(int nIdLote, int nIdMonedaOri, int? nIdMonedaDest)
        {
            return await repository.getTipoCambio(nIdLote, nIdMonedaOri, nIdMonedaDest);
        }

        public async Task calculateCotizacionValues(LotesDisponiblesDTO loteDisponible, bool bIndividual)
        {
            try
            {
                if (bIndividual) 
                {
                    MonedaDTO moneda = (MonedaDTO) await monedaRepository.getMonedaByID(loteDisponible.nIdMoneda);
                    loteDisponible.sSimbolo = moneda.sSimbolo;

                    AsignacionPrecioDTO asignacionPrecioDTO = (AsignacionPrecioDTO) await asignacionPrecioRepository.getAsignacionPrecioByID((int)loteDisponible.nIdAsignacionPrecio);
                    if (loteDisponible.nIdMoneda != asignacionPrecioDTO.nIdMoneda) {
                        TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)asignacionPrecioDTO.nIdMoneda, bIndividual ? loteDisponible.nIdMoneda : null);
                        loteDisponible.nPrecioVentaM2 = asignacionPrecioDTO.nPrecioVenta * tipoCambio.nVenta;
                    }
                    else
                    {
                        loteDisponible.nPrecioVentaM2 = asignacionPrecioDTO.nPrecioVenta;
                    }
                }

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
                    getSelectCotizacionDTO selectCotizacionDTO = new getSelectCotizacionDTO();
                    selectCotizacionDTO.nIdLote = loteDisponible.nIdLote;
                    selectCotizacionDTO.nIdInicialLote = loteDisponible.nIdInicial;
                    selectCotizacionDTO.nIdDescuentoLote = loteDisponible.nIdDescuentoFin;
                    selectCotizacionDTO.nIdCuotaLote = loteDisponible.nIdCuota;
                    selectCotizacionDTO.nIdInteresCuota = loteDisponible.nIdInteresCuota;

                    switch (loteDisponible.nCodigoCompania)
                    {
                        case 1:
                            List<InicialDescuentoDTO> listInicial1 = (List<InicialDescuentoDTO>)await getListInicialLote(selectCotizacionDTO);
                            inicial = (InicialLoteDTO)await inicialLoteRepository.getInicialLoteByID(listInicial1.Count > 0 ? listInicial1.ToList()[0].nId : 0);

                            List<SelectDTO> listCuota1 = (List<SelectDTO>)await getSelectCuotaLote(selectCotizacionDTO);
                            cuota = (CuotaLoteDTO)await cuotaLoteRepository.getCuotaLoteByID(listCuota1.Count > 0 ? listCuota1.ToList()[0].nCod : 0);

                            List<InicialDescuentoDTO> listDescuentoFin1 = (List<InicialDescuentoDTO>)await getListDescuentoFinLote(selectCotizacionDTO);
                            descuentoFin = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoFin1.Count > 0 ? listDescuentoFin1.ToList()[0].nId : 0);

                            List<SelectInteresDTO> listInteres1 = (List<SelectInteresDTO>)await getListInteresLote(selectCotizacionDTO);
                            interes = (InteresCuotaDTO)await interesCuotaRepository.getInteresCuotaByID(listInteres1.Count > 0 ? listInteres1.ToList()[0].nId : 0);

                            List<InicialDescuentoDTO> listDescuentoCon1 = (List<InicialDescuentoDTO>)await getListDescuentoContLote(selectCotizacionDTO);
                            descuentoCon = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoCon1.Count > 0 ? listDescuentoCon1.ToList()[0].nId : 0);

                            break;
                        case 3:
                            List<InicialDescuentoDTO> listInicial = (List<InicialDescuentoDTO>)await getListInicialLote(selectCotizacionDTO) ;
                            inicial = (InicialLoteDTO) await inicialLoteRepository.getInicialLoteByID(listInicial.Count > 0 ? listInicial.ToList()[0].nId : 0) ;

                            List<SelectDTO> listCuota = (List<SelectDTO>) await getSelectCuotaLote(selectCotizacionDTO);
                            cuota = (CuotaLoteDTO)await cuotaLoteRepository.getCuotaLoteByID(listCuota.Count > 0 ? listCuota.ToList()[0].nCod : 0);

                            List<InicialDescuentoDTO> listDescuentoFin = (List<InicialDescuentoDTO>)await getListDescuentoFinLote(selectCotizacionDTO);
                            descuentoFin = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoFin.Count > 0 ? listDescuentoFin.ToList()[0].nId : 0);

                            List<SelectInteresDTO> listInteres = (List<SelectInteresDTO>)await getListInteresLote(selectCotizacionDTO);
                            interes = (InteresCuotaDTO)await interesCuotaRepository.getInteresCuotaByID(listInteres.Count > 0 ? listInteres.ToList()[0].nId : 0);

                            List<InicialDescuentoDTO> listDescuentoCon = (List<InicialDescuentoDTO>)await getListDescuentoContLote(selectCotizacionDTO);
                            descuentoCon = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoCon.Count > 0 ? listDescuentoCon.ToList()[0].nId : 0);

                            break;
                        case 4:
                            List<InicialDescuentoDTO> listInicial4 = (List<InicialDescuentoDTO>)await getListInicialLote(selectCotizacionDTO);
                            inicial = (InicialLoteDTO)await inicialLoteRepository.getInicialLoteByID(listInicial4.Count > 0 ? listInicial4.ToList()[0].nId : 0);

                            List<SelectDTO> listCuota4 = (List<SelectDTO>)await getSelectCuotaLote(selectCotizacionDTO);
                            cuota = (CuotaLoteDTO)await cuotaLoteRepository.getCuotaLoteByID(listCuota4.Count > 0 ? listCuota4.ToList()[0].nCod : 0);

                            List<InicialDescuentoDTO> listDescuentoFin4 = (List<InicialDescuentoDTO>)await getListDescuentoFinLote(selectCotizacionDTO);
                            descuentoFin = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoFin4.Count > 0 ? listDescuentoFin4.ToList()[0].nId : 0);

                            List<SelectInteresDTO> listInteres4 = (List<SelectInteresDTO>)await getListInteresLote(selectCotizacionDTO);
                            interes = (InteresCuotaDTO)await interesCuotaRepository.getInteresCuotaByID(listInteres4.Count > 0 ? listInteres4.ToList()[0].nId : 0);

                            List<InicialDescuentoDTO> listDescuentoCon4 = (List<InicialDescuentoDTO>)await getListDescuentoContLote(selectCotizacionDTO);
                            descuentoCon = (DescuentoLoteDTO)await descuentoLoteRepository.getDescuentoLoteByID(listDescuentoCon4.Count > 0 ? listDescuentoCon4.ToList()[0].nId : 0);

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
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)inicial.nIdMoneda, bIndividual ? loteDisponible.nIdMoneda : null);
                            loteDisponible.nValorCalIni = inicial.nValor * tipoCambio.nVenta;
                        }
                        loteDisponible.nInicial = loteDisponible.nValorCalIni;
                    }
                    else
                    {
                        loteDisponible.sSimboloIni = "%";
                        loteDisponible.nValorCalIni = inicial.nValor;
                        loteDisponible.nInicial = loteDisponible.nValorCalIni / 100 * loteDisponible.nPrecioVenta;
                    }
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
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)descuentoFin.nIdMoneda, bIndividual ? loteDisponible.nIdMoneda : null);
                            loteDisponible.nValorCalDescuentoFin = descuentoFin.nValor * tipoCambio.nVenta;
                        }
                        loteDisponible.nDescuentoFin = loteDisponible.nValorCalDescuentoFin;
                    }
                    else
                    {
                        loteDisponible.sSimboloDescuentoFin = "%";
                        loteDisponible.nValorCalDescuentoFin = descuentoFin.nValor;
                        loteDisponible.nDescuentoFin = loteDisponible.nValorCalDescuentoFin / 100 * loteDisponible.nPrecioVenta;
                    }
                }
                else 
                {
                    loteDisponible.nDescuentoFin = 0;
                }
                #endregion

                loteDisponible.nValorFinanciado = (loteDisponible.nPrecioVenta - loteDisponible.nInicial - loteDisponible.nDescuentoFin);

                #region INTERES
                if (interes != null)
                {
                    loteDisponible.nIdInteresCuota = interes.nIdInteresCuota;
                    loteDisponible.sInteresCuota = interes.sDescripcion;
                    loteDisponible.sCodigoTipoInteresCuota = interes.sCodigoTipoInteres;
                    loteDisponible.sCodigoTipoValorInteresCuota = interes.sCodigoTipoValor;

                    if (interes.sCodigoTipoValor == "1")
                    {
                        if (interes.nIdMoneda == loteDisponible.nIdMoneda)
                        {
                            loteDisponible.nValorCalInteresCuota = descuentoFin.nValor;
                        }
                        else
                        {
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)interes.nIdMoneda, bIndividual ? loteDisponible.nIdMoneda : null);
                            loteDisponible.nValorCalInteresCuota = interes.nValor * tipoCambio.nVenta;
                        }
                    }
                    else
                    {
                        loteDisponible.nValorCalInteresCuota = interes.nValor;
                    }

                    if (interes.sCodigoTipoInteres == "1")
                    {
                        loteDisponible.nInteresCuota = loteDisponible.nIdInteresCuota != null ? (
                                                            loteDisponible.sCodigoTipoValorInteresCuota == "1" ?
                                                            loteDisponible.nValorCalInteresCuota :
                                                            loteDisponible.nValorCalInteresCuota / 100 * (loteDisponible.nPrecioVenta - loteDisponible.nInicial )
                                                        ) : 0;
                        loteDisponible.nValorFinanciado += loteDisponible.nInteresCuota;
                    }
                }
                else
                {
                    loteDisponible.nInteresCuota = 0;
                }
                #endregion

                #region CUOTA
                if (cuota != null)
                {
                    loteDisponible.nIdCuota = cuota.nIdCuotaLote;
                    loteDisponible.nCuotas = cuota.nCuotas;

                    loteDisponible.nValorCuota = loteDisponible.nCuotas > 0 ? loteDisponible.nValorFinanciado / loteDisponible.nCuotas : 0;
                }
                else 
                {
                    loteDisponible.nValorCuota = 0;
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
                            TipoCambioDTO tipoCambio = (TipoCambioDTO)await this.getTipoCambio(loteDisponible.nIdLote, (int)descuentoCon.nIdMoneda, bIndividual ? loteDisponible.nIdMoneda : null);
                            loteDisponible.nValorCalDescuentoCon = descuentoCon.nValor * tipoCambio.nVenta;
                        }
                        loteDisponible.nDescuentoCon = loteDisponible.nValorCalDescuentoCon;
                    }
                    else
                    {
                        loteDisponible.sSimboloDescuentoCon = "%";
                        loteDisponible.nValorCalDescuentoCon = descuentoCon.nValor;
                        loteDisponible.nDescuentoCon = loteDisponible.nValorCalDescuentoCon / 100 * loteDisponible.nPrecioVenta;
                    }
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


        public async Task<IList<CotizacionChartDTO>> postListCotizacionChart(CotizacionChartFilterDTO cotizacionChartFilter)
        {
            return await repository.postListCotizacionChart(cotizacionChartFilter);
        }

    }
}
