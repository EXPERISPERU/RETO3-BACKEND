using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces
{
    public interface IPerfilRepository
    {
        Task<IList<PerfilDTO>> ListPerfil();
        Task<IList<OpcionDTO>> ListOpcionByIdPerfil(int nIdPerfil);
        Task<SqlRspDTO> InsertPerfil(PerfilDTO perfil);
        Task<SqlRspDTO> UpdatePerfil(PerfilDTO perfil);
    }
}
