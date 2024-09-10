﻿using backend.businesslogic.Interfaces.Comercial;
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

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania, int nIdUsuario)
        {
            var list = await repository.getListLotesDisponibles(nIdCompania, nIdUsuario);
                
            foreach (var item in list) {
                new CotizacionBL().calculateCotizacionValues(item);
            }

            return list;
        }
    }
}
