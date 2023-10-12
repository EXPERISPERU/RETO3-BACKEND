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

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles()
        {
            return await repository.getListLotesDisponibles();
        }

        public async Task<IList<InicialDescuentoDTO>> getListInicialLote()
        {
            return await repository.getListInicialLote();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoContLote()
        {
            return await repository.getListDescuentoContLote();
        }

        public async Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote()
        {
            return await repository.getListDescuentoFinLote();
        }
    }
}
