using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Interfaces.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Dealers
{
    public class AgenteDealerBL : IAgenteDealerBL
    {
        IAgenteDealerRepository repository;

        public AgenteDealerBL(IAgenteDealerRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<AgenteDealerDTO>> getListAgenteDealer()
        {
            return await repository.getListAgenteDealer();
        }

        public async Task<AgenteDealerDTO> getAgenteDealerByID(int nIdAgenteDealer)
        {
            return await repository.getAgenteDealerByID(nIdAgenteDealer);
        }

        public async Task<AgenteDealerDTO> findAgenteDealer(string? sDNI, string? sCE)
        {
            return await repository.findAgenteDealer(sDNI, sCE);
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<SqlRspDTO> InsAgenteDealer(AgenteDealerDTO agenteDealer)
        {
            return await repository.InsAgenteDealer(agenteDealer);
        }

        public async Task<SqlRspDTO> UpdAgenteDealer(AgenteDealerDTO agenteDealer)
        {
            return await repository.UpdAgenteDealer(agenteDealer);
        }
    }
}
