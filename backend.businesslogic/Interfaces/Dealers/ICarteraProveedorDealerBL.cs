using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface ICarteraProveedorDealerBL
    {
        Task<IList<CarteraProveedorDealerDTO>> getListCarteraProveedorDealer(FilterCarteraDTO filter);
        Task<SqlRspDTO> posAsignarCartera(AsignarCarteraDTO asignar);

    }
}