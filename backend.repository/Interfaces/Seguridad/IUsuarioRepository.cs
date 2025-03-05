using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Seguridad
{
    public interface IUsuarioRepository
    {
        Task<IList<UsuarioDTO>> getAllUsuario();
        Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> dltUsuario(int nIdUsuario);
        Task<UsuarioDTO> getUserById( int nIdUsuario );
    }
}
