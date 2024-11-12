using backend.businesslogic.Interfaces.Dashboard;
using backend.domain;
using backend.repository.Interfaces.Dashboard;
using backend.repository.Interfaces.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Dashboard
{
    public class DashboardBL: IDashboardBL
    {
        IDashboardRepository repository;

        public DashboardBL(IDashboardRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<SelectDTO>> getListUsuarios(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListUsuarios(nIdCompania, nIdUsuario);
        }

        public async Task<IList<SelectDTO>> getListProveedores(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListProveedores(nIdCompania, nIdUsuario);
        }

        public async Task<IList<SelectDTO>> getListTipoUsuario()
        {
            return await repository.getListTipoUsuario();
        }
    }
}
