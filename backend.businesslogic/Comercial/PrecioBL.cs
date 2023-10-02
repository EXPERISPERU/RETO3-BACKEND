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
    public class PrecioBL : IPrecioBL
    {
        IPrecioRepository repository;

        public PrecioBL(IPrecioRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<PrecioDTO>> getListPrecio()
        {
            return await repository.getListPrecio();
        }
    }
}
