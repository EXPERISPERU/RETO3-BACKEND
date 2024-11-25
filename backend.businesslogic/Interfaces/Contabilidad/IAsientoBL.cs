using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Contabilidad
{
    public interface IAsientoBL
    {
        Task<IList<AsientoCajaDTO>> getAsientoCaja(AsientoFilterDTO filter);
        Task<IList<AsientoBancoDTO>> getAsientoBancos(AsientoFilterDTO filter);
        Task<IList<AsientoBoletasDTO>> getAsientoBoletas(AsientoFilterDTO filter);
        Task<IList<AsientoDevolucionDTO>> getAsientoDevoluciones(AsientoFilterDTO filter);
    }
}