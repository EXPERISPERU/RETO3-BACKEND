using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class PreVentaLoteBL : IPreVentaLoteBL
    {
        IPreVentaLoteRepository repository;

        public PreVentaLoteBL(IPreVentaLoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioPreVentaByLoteInicial(int nIdLote, decimal nValorInicial)
        { 
            return await repository.getSelectPrecioPreVentaByLoteInicial(nIdLote, nValorInicial);
        }

        public async Task<SqlRspDTO> InsPreventaLote(InsPreVentaLoteDTO insPreventaLote)
        {
            return await repository.InsPreventaLote(insPreventaLote);
        }
    }
}
