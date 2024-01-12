﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IReporteVentasBL
    {
        Task<IList<ReporteVentasDTO>> getListReporteVentas();
    }
}
