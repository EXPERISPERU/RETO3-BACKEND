using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Contabilidad
{
    public interface IAsientoBL
    {
        Task<string> getAsientoCaja(AsientoFilterDTO filter);
        Task<string> getAsientoBancos(AsientoFilterDTO filter);
        Task<string> getAsientoBoletas(AsientoFilterDTO filter);
        Task<string> getAsientoDevoluciones(AsientoFilterDTO filter);
    }
}