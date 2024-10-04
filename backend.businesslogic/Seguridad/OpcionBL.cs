using backend.businesslogic.Interfaces.Seguridad;
using backend.domain;
using backend.repository.Interfaces.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Seguridad
{
    public class OpcionBL : IOpcionBL
    {
        IOpcionRepository repository;
        public OpcionBL(IOpcionRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<OpcionDTO>> ListOpcion()
        {
            return await repository.ListOpcion();
        }

        public async Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion)
        {
            return await repository.InsOpcionPerfil(perfilOpcion);
        }

        public async Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion)
        {
            return await repository.DelOpcionPerfil(perfilOpcion);
        }

        public async Task<IList<SelectDTO>> ListTipoOpcionByIdOpcionP(int nIdOpcion)
        {
            return await repository.ListTipoOpcionByIdOpcionP(nIdOpcion);
        }

        public async Task<int> CantOpcionHijo(int nIdOpcion)
        {
            return await repository.CantOpcionHijo(nIdOpcion);
        }

        public async Task<SqlRspDTO> InsOpcion(OpcionDTO opcion)
        {
            return await repository.InsOpcion(opcion);
        }

        public async Task<SqlRspDTO> UpdOpcion(OpcionDTO opcion)
        {
            return await repository.UpdOpcion(opcion);
        }

        public async Task<SqlRspDTO> InsOpcionUsuario(UsuarioOpcionDTO usuarioOpcion)
        {
            return await repository.InsOpcionUsuario(usuarioOpcion);
        }

        public async Task<SqlRspDTO> DelOpcionUsuario(UsuarioOpcionDTO usuarioOpcion)
        {
            return await repository.DelOpcionUsuario(usuarioOpcion);
        }

        public async Task<IList<OpcionByPerfilDTO>> getAccionesByUsuarioCompania(int nIdCompania, int nIdUsuario)
        {
            return await repository.getAccionesByUsuarioCompania(nIdCompania, nIdUsuario);
        }

        public async Task<IList<PermisosDashboardDTO>> getPermisosDashboardByUsuarioCompania(int nIdCompania, int nIdUsuario)
        {
            return await repository.getPermisosDashboardByUsuarioCompania(nIdCompania, nIdUsuario);
        }
    }
}
