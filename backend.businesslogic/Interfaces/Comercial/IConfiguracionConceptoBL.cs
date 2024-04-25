using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public  interface IConfiguracionConceptoBL
    {
        Task<IList<ElementoSistemaDTO>> getListTipoComprante();
        Task<IList<ConfiguracionConceptoDTO>> ListConfiguracionConceptoByIdProyecto(int nIdproyecto);
    }
}
