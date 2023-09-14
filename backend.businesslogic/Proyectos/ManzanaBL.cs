using backend.businesslogic.Interfaces.Proyectos;
using backend.domain;
using backend.repository.Interfaces.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Proyectos
{
    public class ManzanaBL : IManzanaBL
    {
        IManzanaRepository repository;

        public ManzanaBL(IManzanaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ManzanaDTO>> getListManzanaBySector(int nIdSector)
        { 
            return await this.repository.getListManzanaBySector(nIdSector);
        }

        public async Task<SqlRspDTO> InsManzana(ManzanaDTO manzana)
        {
            return await repository.InsManzana(manzana);
        }

        public async Task<SqlRspDTO> UpdManzana(ManzanaDTO manzana)
        {
            return await repository.UpdManzana(manzana);
        }
    }
}
