﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Cobranzas
{
    public interface IAgendamientoBL
    {
        Task<IList<AgendamientoDTO>> getListAgendamientoByFilters(AgendamientoFiltrosDTO AgendamientoFiltros);
        Task<IList<SelectDTO>> getSelectAsesorAgendamiento(int nIdCompania, int nIdUsuario);
    }
}
