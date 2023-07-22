using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces
{
    public interface IAuthRepository
    {
        public Task<SqlRspDTO> AuthUser(authLoginDTO authLogin);
    }
}
