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
    public class AgendamientoBL : IAgendamientoBL
    {
        IAgendamientoRepository repository;
        public AgendamientoBL(IAgendamientoRepository _repository)
        {
            this.repository = _repository;
        }



        public async Task<IList<AgendamientoDTO>> getListAgendamientoByFilters(AgendamientoFiltrosDTO AgendamientoFiltros)
        {
            return await repository.getListAgendamientoByFilters(AgendamientoFiltros);
        }

        public async Task<IList<SelectDTO>> getSelectAsesorAgendamiento(int nIdCompania, int nIdUsuario)
        {
            return await repository.getSelectAsesorAgendamiento(nIdCompania, nIdUsuario);
        }
    }


}
