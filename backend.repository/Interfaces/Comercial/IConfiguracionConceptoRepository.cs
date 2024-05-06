﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IConfiguracionConceptoRepository
    {
        Task<IList<tipoComprobante>> getListTipoComprante();
        Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto);
        Task<IList<ElementoSistemaDTO>> getListMedioPago();
        Task<SqlRspDTO> postInsConfiguracionConcepto(ConfiguracionConceptoDTO configuracion);
        Task<IList<ConfiguracionConceptoDTO>> GetConfiguracionConceptoByIdProyectoAndIdConceptoVenta(int nIdproyecto, int nIdConceptoVenta);
        Task<IList<JsonFormatDTO>> getComprobanteMedioPago(int nIdCompania);
    }
}
