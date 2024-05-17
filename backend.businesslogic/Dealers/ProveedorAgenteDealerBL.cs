using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Dealers;
using backend.repository.Interfaces.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Dealers
{
    public class ProveedorAgenteDealerBL : IProveedorAgenteDealerBL
    {
        IProveedorAgenteDealerRepository repository;

        public ProveedorAgenteDealerBL(IProveedorAgenteDealerRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ProveedorAgenteDealerDTO>> getListProveedorAgente(int nIdAgenteDealer)
        {
            return await repository.getListProveedorAgente(nIdAgenteDealer);
        }

        public async Task<IList<SelectDTO>> getProveedoresDealer()
        {
            return await repository.getProveedoresDealer();
        }

        public async Task<int> CantActivePADByAgente(int nIdAgenteDealer)
        {
            return await repository.CantActivePADByAgente(nIdAgenteDealer);
        }

        public async Task<SqlRspDTO> InsProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            return await repository.InsProvAgenDealer(proveedorAgenteDealer);
        }

        public async Task<SqlRspDTO> UpdProvAgenDealer(ProveedorAgenteDealerDTO proveedorAgenteDealer)
        {
            return await repository.UpdProvAgenDealer(proveedorAgenteDealer);
        }

        public async Task<IList<SelectDTO>> getJefesDealer(int nIdProveedor, int nIdAgenteDealer)
        {
            return await repository.getJefesDealer(nIdProveedor, nIdAgenteDealer);
        }

        public async Task<SqlRspDTO> InsJefeDealer(JefeAgenteDealerDTO jefeAgenteDealer)
        {
            return await repository.InsJefeDealer(jefeAgenteDealer);
        }

        public async Task<IList<JefeAgenteDealerDTO>> getJefesDealerByAgenteDealer(int nIdAgenteDealer)
        {
            return await repository.getJefesDealerByAgenteDealer(nIdAgenteDealer);
        }

    }
}
