using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.repository.Interfaces.Dealers
{
    public interface ICarteraProveedorDealerRepository
    {
        Task<IList<CarteraProveedorDealerDTO>> getListCarteraProveedorDealer(FilterCarteraDTO filter);

    }
}