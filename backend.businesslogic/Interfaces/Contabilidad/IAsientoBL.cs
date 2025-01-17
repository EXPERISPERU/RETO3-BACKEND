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
        Task<string> getAsientoIzipay(AsientoFilterDTO filter);
        Task<string> getVisitaGuiadaBoletas(AsientoFilterDTO filter);
        Task<string> getVisitaGuiadaCaja(AsientoFilterDTO filter);
        Task<string> getVisitaGuiadaBanco(AsientoFilterDTO filter);
        Task<string> getVisitaGuiadaNotaC(AsientoFilterDTO filter);
    }
}