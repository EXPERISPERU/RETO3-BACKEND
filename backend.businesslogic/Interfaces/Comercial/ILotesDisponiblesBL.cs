﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ILotesDisponiblesBL
    {
        Task<IList<LotesDisponiblesFiltrosDTO>> getListFiltros(int nIdCompania, int nIdUsuario);
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(SelectLotesDisponiblesDTO select);
    }
}
