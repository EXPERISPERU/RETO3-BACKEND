using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface ICorrelativoBL
    {
        Task<IList<CorrelativoDTO>> getListCorrelativoBySerie(int nIdSerie);
        Task<int> getCantActiveCorrelativoBySerie(int nIdSerie);
        Task<SqlRspDTO> InsCorrelativo(CorrelativoDTO correlativo);
        Task<SqlRspDTO> UpdCorrelativo(CorrelativoDTO correlativo);
    }
}
