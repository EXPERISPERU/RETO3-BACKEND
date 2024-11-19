using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Dashboard
{
    public interface IDashboardRepository
    {
        Task<IList<SelectDTO>> getListUsuarios(int nIdProveedor);
        Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getListTipoUsuario();
    }
}
