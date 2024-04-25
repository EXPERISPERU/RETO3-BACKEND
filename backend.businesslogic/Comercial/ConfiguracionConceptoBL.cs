﻿using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Comercial;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ConfiguracionConceptoBL: IConfiguracionConceptoBL
    {
        IConfiguracionConceptoRepository repository;

        public ConfiguracionConceptoBL(IConfiguracionConceptoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ElementoSistemaDTO>> getListTipoComprante()
        {
            return await repository.getListTipoComprante();
        }

        public async Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto)
        {
            return await repository.ListConfiguracionConceptoByIdProyecto(nIdproyecto);
        }
    }
}
