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
    public class TipoCambioBL : ITipoCambioBL
    {
        ITipoCambioRepository repository;
        public TipoCambioBL(ITipoCambioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SqlRspDTO> insTipoCambio(TipoCambioDTO tipocambio)
        {
            return await repository.insTipoCambio(tipocambio);
        }
    }
}
