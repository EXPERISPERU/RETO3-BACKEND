using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ConfiguracionBL: IConfiguracionBL
    {
        IConfiguracionRepository repository;

        public ConfiguracionBL(IConfiguracionRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ConfiguracionDTO>> getConfiguracionByIdProyecto(int nIdproyecto)
        {
            return await repository.getConfiguracionByIdProyecto(nIdproyecto);
        }


        public async Task<IList<ElementoSistemaDTO>> getListInteres()
        {
            return await repository.getListInteres();
        }

    }
}
