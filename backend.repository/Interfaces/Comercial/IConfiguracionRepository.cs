﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IConfiguracionRepository
    {
        Task<IList<ConfiguracionDTO>> getConfiguracionByIdProyecto(int nIdproyecto);
        Task<IList<ElementoSistemaDTO>> getListInteres();
        Task<IList<ElementoSistemaDTO>> getListConceptoVenta();
        Task<IList<ElementoSistemaDTO>> getListDocumentoVenta();
        Task<SqlRspDTO> InsConfiguracion(ConfiguracionDTO configuracion);
        Task<SqlRspDTO> InsSistemaConfiguracionConcepto(ConfiguracionConceptoDTO configuracionConcepto);
        Task<IList<CompaniaMonedaDTO>> getListMonedaByCompania(int nIdCompania);
        Task<IList<ImpuestosVentaDTO>> getListImpuestoVenta(int nIdCompania);
    }
}
