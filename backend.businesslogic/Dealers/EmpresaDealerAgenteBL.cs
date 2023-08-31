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
    public class EmpresaDealerAgenteBL : IEmpresaDealerAgenteBL
    {
        IEmpresaDealerAgenteRepository repository;

        public EmpresaDealerAgenteBL(IEmpresaDealerAgenteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<EmpresaDealerAgenteDTO>> getListEmpresaDealerAgente(int nIdAgenteDealer)
        {
            return await repository.getListEmpresaDealerAgente(nIdAgenteDealer);
        }

        public async Task<IList<SelectDTO>> getEmpresasDealer()
        {
            return await repository.getEmpresasDealer();
        }

        public async Task<int> CantActiveEDAByAgente(int nIdAgenteDealer)
        {
            return await repository.CantActiveEDAByAgente(nIdAgenteDealer);
        }

        public async Task<SqlRspDTO> InsEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            return await repository.InsEmpDeaAgente(empresaDealerAgente);
        }

        public async Task<SqlRspDTO> UpdEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente)
        {
            return await repository.UpdEmpDeaAgente(empresaDealerAgente);
        }

    }
}
