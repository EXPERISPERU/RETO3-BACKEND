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
    public class CorrelativoBL : ICorrelativoBL
    {
        ICorrelativoRepository repository;
        public CorrelativoBL(ICorrelativoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CorrelativoDTO>> getListCorrelativoBySerie(int nIdSerie)
        {
            return await repository.getListCorrelativoBySerie(nIdSerie);
        }

        public async Task<int> getCantActiveCorrelativoBySerie(int nIdSerie)
        {
            return await repository.getCantActiveCorrelativoBySerie(nIdSerie);
        }

        public async Task<SqlRspDTO> InsCorrelativo(CorrelativoDTO correlativo)
        {
            return await repository.InsCorrelativo(correlativo);
        }

        public async Task<SqlRspDTO> UpdCorrelativo(CorrelativoDTO correlativo)
        {
            return await repository.UpdCorrelativo(correlativo);
        }
    }
}
