using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<IList<UsuarioDTO>> GetUsersAll();
    }
}
