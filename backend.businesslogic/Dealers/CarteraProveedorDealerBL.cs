using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Interfaces.Dealers;

namespace backend.businesslogic.Dealers
{
    public class CarteraProveedorDealerBL : ICarteraProveedorDealerBL
    {
        ICarteraProveedorDealerRepository repository;

        public CarteraProveedorDealerBL(ICarteraProveedorDealerRepository _repository)
        {
            this.repository = _repository;
        }


        public async Task<IList<CarteraProveedorDealerDTO>> getListCarteraProveedorDealer(FilterCarteraDTO filter)
        {
            return await repository.getListCarteraProveedorDealer(filter);
        }
    }
}
