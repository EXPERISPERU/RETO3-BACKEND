﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface ILotesDisponiblesRepository
    {
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania, int nIdUsuario);
    }
}
