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
        Task<IList<AsientoBoletasDTO>> getAsientoBoletas(AsientoFilterDTO filter);
        Task<IList<AsientoDevolucionDTO>> getAsientoDevoluciones(AsientoFilterDTO filter);
        Task<IList<AsientoIzipayDTO>> getAsientoIzipay(AsientoFilterDTO filter);
        Task<IList<VisitaGuiadaBoletasDTO>> getVisitaGuiadaBoletas(AsientoFilterDTO filter);
        Task<IList<VisitaGuiadaEfectivoDTO>> getVisitaGuiadaCaja(AsientoFilterDTO filter);
        Task<IList<VisitaGuiadaBbvaDTO>> getVisitaGuiadaBanco(AsientoFilterDTO filter);
        Task<IList<VisitaGuiadaNcDTO>> getVisitaGuiadaNotaC(AsientoFilterDTO filter);
    }
}