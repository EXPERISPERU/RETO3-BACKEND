using backend.businesslogic.Interfaces.Comercial.Precio;
using backend.domain;
using backend.repository.Interfaces.Comercial.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.Precio
{
    public class PrecioBL : IPrecioBL
    {
        IPrecioRepository repository;

        public PrecioBL(IPrecioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<PrecioDTO>> getListPrecio()
        {
            return await repository.getListPrecio();
        }
    }
}
