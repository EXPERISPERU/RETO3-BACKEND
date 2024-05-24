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
            return await repository.calculateCotizacion(cotizacion);
        }

        public async Task<SqlRspDTO> InsCotizacion(CotizacionDTO cotizacion)
        {
            return await repository.InsCotizacion(cotizacion);
        }

        public async Task<CotizacionDTO> getCotizacionById(int nIdCotizacion)
        {
            return await repository.getCotizacionById(nIdCotizacion);
        }

        public async Task<string> formatoCotizacion()
        {
            return await repository.formatoCotizacion();
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
    }
}
