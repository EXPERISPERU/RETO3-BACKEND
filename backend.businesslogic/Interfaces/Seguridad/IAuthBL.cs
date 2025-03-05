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
        public Task<LoginDTO> AuthUser(authLoginDTO authLogin);
    }
}
