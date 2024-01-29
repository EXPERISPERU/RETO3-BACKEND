﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Contabilidad
{
    public interface IComprobanteBL
    {
        Task<ComprobanteDTO> getComprobanteById(int nIdComprobante);
        Task<List<ComprobanteDetDTO>> getComprobanteDetById(int nIdComprobante);
        Task<string> formatoComprobanteByIdComprobante(int nIdComprobante);
        Task<SqlRspDTO> InsComprobanteAdjunto(int nIdComprobante, string sRutaFtp);
    }
}
