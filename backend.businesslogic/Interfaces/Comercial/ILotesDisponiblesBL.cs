using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ILotesDisponiblesBL
    {
        Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(int nIdCompania);
        Task<IList<InicialDescuentoDTO>> getListInicialLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoContLote(int nIdLote);
        Task<IList<InicialDescuentoDTO>> getListDescuentoFinLote(int nIdLote);
        Task<LotesDisponiblesDTO> calculateCotizacion(LotesDisponiblesDTO loteDisponible, int nIdCompania);
    }
}
