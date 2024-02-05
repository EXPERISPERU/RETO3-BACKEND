using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface ICorrelativoRepository
    {
        Task<IList<CorrelativoDTO>> getListCorrelativoBySerie(int nIdSerie);
        Task<int> getCantActiveCorrelativoBySerie(int nIdSerie);
        Task<SqlRspDTO> InsCorrelativo(CorrelativoDTO correlativo);
        Task<SqlRspDTO> UpdCorrelativo(CorrelativoDTO correlativo);
    }
}
