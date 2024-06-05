using backend.businesslogic.Interfaces.Prospectos;
using backend.domain;
using backend.repository.Interfaces.Prospectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Prospectos
{
    public class ProspectoBL : IProspectoBL
    {
        IProspectoRepository repository;
        public ProspectoBL(IProspectoRepository _repository)
        {
            this.repository = _repository;
        }

    }
}
