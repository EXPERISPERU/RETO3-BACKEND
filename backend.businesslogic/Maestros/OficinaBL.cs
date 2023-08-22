using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class OficinaBL : IOficinaBL
    {
        IOficinaRepository repository;
        public OficinaBL(IOficinaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<OficinaDTO>> getListOficinaByCompania(int nIdCompania)
        { 
            return await repository.getListOficinaByCompania(nIdCompania);
        }
    }
}
