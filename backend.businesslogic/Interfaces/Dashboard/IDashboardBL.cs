using backend.domain;

namespace backend.businesslogic.Interfaces.Dashboard
{
    public interface IDashboardBL
    {
        Task<IList<SelectDTO>> getListUsuarios(int nIdProveedor, int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListTipoUsuario();
    }
}
