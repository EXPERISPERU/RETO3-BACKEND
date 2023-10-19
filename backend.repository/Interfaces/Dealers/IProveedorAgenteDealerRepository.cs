using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Dealers
{
    public interface IProveedorAgenteDealerRepository
    {
        Task<IList<ProveedorAgenteDealerDTO>> getListProveedorAgente(int nIdAgenteDealer);
        Task<IList<SelectDTO>> getProveedoresDealer();
        Task<int> CantActivePADByAgente(int nIdAgenteDealer);
        Task<SqlRspDTO> InsProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer);
        Task<SqlRspDTO> UpdProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer);
    }
}
