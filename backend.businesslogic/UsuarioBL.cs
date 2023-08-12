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

        public async Task<IList<UsuarioDTO>> getAllUsuario()
        {
            return await repository.getAllUsuario();
        }

        public async Task<IList<SelectDTO>> getTipoUsuario()
        {
            return await repository.getTipoUsuario();
        }

        public async Task<IList<SelectDTO>> getPersonaByTipoUsuario(int nIdTipoUsuario)
        { 
            return await repository.getPersonaByTipoUsuario(nIdTipoUsuario);
        }

        public async Task<SqlRspDTO> InsUsuario(UsuarioDTO usuario)
        {
            return await repository.InsUsuario(usuario);
        }

        public async Task<SqlRspDTO> UpdUsuario(UsuarioDTO usuario)
        {
            return await repository.UpdUsuario(usuario);
        }

        public async Task<SqlRspDTO> InsUsuPerCom(PerfilUsuarioDTO perusu)
        {
            return await repository.InsUsuPerCom(perusu);
        }

        public async Task<SqlRspDTO> DelUsuPerCom(PerfilUsuarioDTO perusu)
        {
            return await repository.DelUsuPerCom(perusu);
        }

        public async Task<IList<SelectDTO>> getCompanias()
        {
            return await repository.getCompanias();
        }

        public async Task<IList<SelectDTO>> getPerfilDispByUsuComp(int nIdUsuario, int nIdCompania)
        {
            return await repository.getPerfilDispByUsuComp(nIdUsuario, nIdCompania);
        }

        public async Task<IList<PerfilUsuarioDTO>> getPerfilByUsu(int nIdUsuario)
        {
            return await repository.getPerfilByUsu(nIdUsuario);
        }
    }
}
