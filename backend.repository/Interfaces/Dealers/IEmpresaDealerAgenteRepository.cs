using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Dealers
{
    public interface IEmpresaDealerAgenteRepository
    {
        Task<IList<EmpresaDealerAgenteDTO>> getListEmpresaDealerAgente(int nIdAgenteDealer);
        Task<IList<SelectDTO>> getEmpresasDealer();
        Task<int> CantActiveEDAByAgente(int nIdAgenteDealer);
        Task<SqlRspDTO> InsEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente);
        Task<SqlRspDTO> UpdEmpDeaAgente(EmpresaDealerAgenteDTO empresaDealerAgente);
    }
}
