using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces
{
    public interface IOpcionRepository
    {
        Task<IList<OpcionDTO>> ListOpcion();
        Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion);
        Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion);
        Task<IList<SelectDTO>> ListTipoOpcionByIdOpcionP(int nIdOpcion);
        Task<int> CantOpcionHijo(int nIdOpcion);
        Task<SqlRspDTO> InsOpcion(OpcionDTO opcion);
        Task<SqlRspDTO> UpdOpcion(OpcionDTO opcion);
    }
}
