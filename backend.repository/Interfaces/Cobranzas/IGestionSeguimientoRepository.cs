using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Cobranzas
{
    public interface IGestionSeguimientoRepository
    {
        Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado);
    }
}
