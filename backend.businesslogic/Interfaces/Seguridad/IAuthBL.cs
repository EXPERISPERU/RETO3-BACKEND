using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Seguridad
{
    public interface IAuthBL
    {
        public Task<SqlRspDTO> AuthUser(authLoginDTO authLogin);
        public Task<IList<OpcionDTO>> ListOpcionByIdUsuario(int nIdUsuario, int nIdCompania);
        public Task<IList<CompaniaDTO>> ListCompaniaByIdUsuario(int nIdUsuario);
    }
}
