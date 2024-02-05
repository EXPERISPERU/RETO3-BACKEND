using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface IProveedorAgenteDealerBL
    {
        Task<IList<ProveedorAgenteDealerDTO>> getListProveedorAgente(int nIdAgenteDealer);
        Task<IList<SelectDTO>> getProveedoresDealer();
        Task<int> CantActivePADByAgente(int nIdAgenteDealer);
        Task<SqlRspDTO> InsProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer);
        Task<SqlRspDTO> UpdProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer);
    }
}
