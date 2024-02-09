using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Seguridad
{
    public interface IAuthRepository
    {
        public Task<LoginDTO> AuthUser(authLoginDTO authLogin);
        public Task<LoginDTO> AuthPortalUser(authLoginDTO authLogin);
        public Task<IList<OpcionDTO>> ListOpcionByIdUsuario(int nIdUsuario, int nIdCompania);
        public Task<IList<CompaniaDTO>> ListCompaniaByIdUsuario(int nIdUsuario);
    }
}
