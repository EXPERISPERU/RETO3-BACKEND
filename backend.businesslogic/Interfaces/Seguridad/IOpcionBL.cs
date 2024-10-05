using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Seguridad
{
    public interface IOpcionBL
    {
        Task<IList<OpcionDTO>> ListOpcion();
        Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion);
        Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion);
        Task<IList<SelectDTO>> ListTipoOpcionByIdOpcionP(int nIdOpcion);
        Task<int> CantOpcionHijo(int nIdOpcion);
        Task<SqlRspDTO> InsOpcion(OpcionDTO opcion);
        Task<SqlRspDTO> UpdOpcion(OpcionDTO opcion);
        Task<SqlRspDTO> InsOpcionUsuario(UsuarioOpcionDTO usuarioOpcion);
        Task<SqlRspDTO> DelOpcionUsuario(UsuarioOpcionDTO usuarioOpcion);
        Task<IList<OpcionByPerfilDTO>> getAccionesByUsuarioCompania(int nIdCompania, int nIdUsuario);
        Task<IList<PermisosDashboardDTO>> getPermisosDashboardByUsuarioCompania(int nIdCompania, int nIdUsuario);
    }
}
