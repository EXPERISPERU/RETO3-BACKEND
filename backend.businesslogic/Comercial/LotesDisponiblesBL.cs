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
    public class LotesDisponiblesBL : ILotesDisponiblesBL
    {
        ILotesDisponiblesRepository repository;

        public LotesDisponiblesBL(ILotesDisponiblesRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania)
        {
            return await repository.getListLotesDisponibles(nIdCompania);
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

        public async Task<LotesDisponiblesDTO> calculateCotizacion(LotesDisponiblesDTO loteDisponible, int nIdCompania) 
        {
            return await repository.calculateCotizacion(loteDisponible, nIdCompania);
        }
    }
}
