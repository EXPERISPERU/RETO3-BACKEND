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
        Task<IList<SelectDTO>> getTipoUsuario();
        Task<IList<SelectDTO>> getPersonaByTipoUsuario(int nIdTipoUsuario);
        Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario);
        Task<SqlRspDTO> UpdUsuarioPortal(UsuarioDTO usuario);
        Task<SqlRspDTO> InsUsuPerCom(PerfilUsuarioDTO perusu);
        Task<SqlRspDTO> DelUsuPerCom(PerfilUsuarioDTO perusu);
        Task<IList<SelectDTO>> getCompanias();
        Task<IList<SelectDTO>> getPerfilDispByUsuComp(int nIdUsuario, int nIdCompania);
        Task<IList<PerfilUsuarioDTO>> getPerfilByUsu(int nIdUsuario);
        Task<IList<OpcionDTO>> getOpcionByUsuComp(int nIdUsuario, int nIdCompania);
        Task<UsuarioDTO> getUserById( int nIdUsuario );
        Task generateUsusariosNuevosClientes();
    }
}
