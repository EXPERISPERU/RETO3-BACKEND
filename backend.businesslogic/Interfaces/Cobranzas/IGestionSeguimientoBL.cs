using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Cobranzas
{
    public interface IGestionSeguimientoBL
    {
        Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado);
    }
}
