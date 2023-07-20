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
    public class UsuarioBL : IUsuarioBL
    {
        IUsuarioRepository repository;
        public UsuarioBL(IUsuarioRepository _repository) 
        { 
            repository = _repository;
        }

        public async Task<IList<UsuarioDTO>> GetUsersAll()
        {
            return await repository.GetUsersAll();
        }
    }
}
