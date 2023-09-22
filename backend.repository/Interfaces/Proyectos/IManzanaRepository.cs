using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Proyectos
{
    public interface IManzanaRepository
    {
        Task<IList<ManzanaDTO>> getListManzanaBySector(int nIdSector);
        Task<SqlRspDTO> InsManzana(ManzanaDTO manzana);
        Task<SqlRspDTO> UpdManzana(ManzanaDTO manzana);
    }
}
