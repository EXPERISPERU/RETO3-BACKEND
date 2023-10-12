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
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles();
        Task<IList<InicialDescuentoDTO>> getListInicialLote();
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote();
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote();
    }
}
