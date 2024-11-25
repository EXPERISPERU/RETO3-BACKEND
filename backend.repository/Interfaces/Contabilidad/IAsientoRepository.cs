using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Contabilidad
{
    public interface IAsientoRepository
    {
        Task<IList<AsientoCajaDTO>> getAsientoCaja(AsientoFilterDTO filter);
        Task<IList<AsientoBancoDTO>> getAsientoBancos(AsientoFilterDTO filter);
    }
}