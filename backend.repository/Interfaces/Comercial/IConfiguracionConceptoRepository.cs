using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IConfiguracionConceptoRepository
    {
        Task<IList<ElementoSistemaDTO>> getListElement();
        Task<IList<ElementoSistemaDTO>> ListElementoByIdP(int nIdElementoP);
        Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto);
    }
}
