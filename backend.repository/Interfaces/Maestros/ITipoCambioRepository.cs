﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface ITipoCambioRepository
    {
        Task<SqlRspDTO> insTipoCambio(TipoCambioDTO tipocambio);
    }
}
