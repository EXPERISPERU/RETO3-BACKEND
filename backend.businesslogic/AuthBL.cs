using backend.businesslogic.Interfaces;
using backend.domain;
using backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic
{
    public class AuthBL : IAuthBL
    {
        IAuthRepository repository;
        public AuthBL(IAuthRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SqlRspDTO> AuthUser(authLoginDTO authLogin)
        {
            return await repository.AuthUser(authLogin);
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
