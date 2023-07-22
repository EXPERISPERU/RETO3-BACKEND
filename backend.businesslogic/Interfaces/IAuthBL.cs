using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces
{
    public interface IAuthBL
    {
        public Task<SqlRspDTO> AuthUser(authLoginDTO authLogin);
    }
}
