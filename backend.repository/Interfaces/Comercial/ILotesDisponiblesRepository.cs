using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface ILotesDisponiblesRepository
    {
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania);
        Task<IList<SelectDTO>> getSelectCuotaLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote);
        Task<LotesDisponiblesDTO> calculateCotizacion(LotesDisponiblesDTO loteDisponible, int nIdCompania);
    }
}
