using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces
{
    public interface IPerfilBL
    {
        Task<IList<PerfilDTO>> ListPerfil();
        Task<IList<OpcionDTO>> ListOpcionByIdPerfil(int nIdPerfil);
        Task<SqlRspDTO> InsertPerfil(PerfilDTO perfil);
        Task<SqlRspDTO> UpdatePerfil(PerfilDTO perfil);
    }
}
