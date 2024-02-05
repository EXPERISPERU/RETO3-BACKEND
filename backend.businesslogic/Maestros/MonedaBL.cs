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
    public class MonedaBL : IMonedaBL
    {
        IMonedaRepository repository;
        public MonedaBL(IMonedaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<MonedaDTO>> getListMoneda()
        {
            return await repository.getListMoneda();
        }
        
        public async Task<MonedaDTO> getMonedaByID(int nIdMoneda)
        {
            return await repository.getMonedaByID(nIdMoneda);
        }
        
        public async Task<SqlRspDTO> InsMoneda(MonedaDTO moneda)
        {
            return await repository.InsMoneda(moneda);
        }
        
        public async Task<SqlRspDTO> UpdMoneda(MonedaDTO moneda)
        {
            return await repository.UpdMoneda(moneda);
        }
    }
}
