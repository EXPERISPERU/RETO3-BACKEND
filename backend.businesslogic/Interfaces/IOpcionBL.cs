using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces
{
    public interface IOpcionBL
    {
        Task<IList<OpcionDTO>> ListOpcion();
        Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion);
        Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion);
    }
}
