using backend.domain;
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
    }
}
