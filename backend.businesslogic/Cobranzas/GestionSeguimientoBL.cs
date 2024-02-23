using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Cobranzas
{
    public class GestionSeguimientoBL: IGestionSeguimientoBL
    {
        IGestionSeguimientoRepository repository;
        public GestionSeguimientoBL(IGestionSeguimientoRepository _repository)
        {
            this.repository = _repository;
        }
        public async Task<IList<GestionClienteDTO>> getListClientesAsignados(int nIdEmpleado)
        {
            return await repository.getListClientesAsignados(nIdEmpleado);
        }
    }
}
