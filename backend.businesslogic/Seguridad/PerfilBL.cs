using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using backend.repository.Interfaces.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Seguridad
{
    public class PerfilBL : IPerfilBL
    {
        IPerfilRepository repository;
        public PerfilBL(IPerfilRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<PerfilDTO>> ListPerfil()
        {
            return await repository.ListPerfil();
        }

        public async Task<IList<OpcionDTO>> ListOpcionByIdPerfil(int nIdPerfil)
        {
            return await repository.ListOpcionByIdPerfil(nIdPerfil);
        }

        public async Task<SqlRspDTO> InsertPerfil(PerfilDTO perfil)
        {
            return await repository.InsertPerfil(perfil);
        }

        public async Task<SqlRspDTO> UpdatePerfil(PerfilDTO perfil)
        {
            return await repository.UpdatePerfil(perfil);
        }
    }
}
