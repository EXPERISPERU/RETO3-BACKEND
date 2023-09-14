using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Proyectos
{
    public interface IManzanaBL
    {
        Task<IList<ManzanaDTO>> getListManzanaBySector(int nIdSector);
        Task<SqlRspDTO> InsManzana(ManzanaDTO manzana);
        Task<SqlRspDTO> UpdManzana(ManzanaDTO manzana);
    }
}
