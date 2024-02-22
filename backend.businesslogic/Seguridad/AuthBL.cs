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
    public class AuthBL : IAuthBL
    {
        IAuthRepository repository;
        public AuthBL(IAuthRepository _repository)
        {
            repository = _repository;
        }

        public async Task<LoginDTO> AuthUser(authLoginDTO authLogin)
        {
            return await repository.AuthUser(authLogin);
        }

        public async Task<LoginDTO> AuthPortalUser(authLoginDTO authLogin)
        {
            return await repository.AuthPortalUser(authLogin);
        }

        public async Task<RecoverPasswordDTO> RecoverPassword(recoverPasswordDTO authLogin)
        {
            return await repository.RecoverPassword(authLogin);
        }

        public async Task<IList<OpcionDTO>> ListOpcionByIdUsuario(int nIdUsuario, int nIdCompania)
        {
            return await repository.ListOpcionByIdUsuario(nIdUsuario, nIdCompania);
        }

        public async Task<IList<CompaniaDTO>> ListCompaniaByIdUsuario(int nIdUsuario)
        {
            return await repository.ListCompaniaByIdUsuario(nIdUsuario);
        }
    }
}
