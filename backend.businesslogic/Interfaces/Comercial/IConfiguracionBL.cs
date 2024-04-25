using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IConfiguracionBL
    {
        Task<IList<ConfiguracionDTO>> getConfiguracionByIdProyecto(int nIdproyecto);

        Task<IList<ElementoSistemaDTO>> getListInteres();

        Task<IList<ElementoSistemaDTO>> getListConceptoVenta();

        Task<IList<ElementoSistemaDTO>> getListDocumentoVenta();
    }
}
