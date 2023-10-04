using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial.Precio
{
    public interface IPrecioBL
    {
        Task<IList<PrecioDTO>> getListPrecio();
    }
}
