using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class LotesDisponiblesBL : ILotesDisponiblesBL
    {
        ICotizacionBL cotizacionBL;
        ILotesDisponiblesRepository repository;

        public LotesDisponiblesBL(ILotesDisponiblesRepository _repository, ICotizacionBL _cotizacionBL)
        {
            this.repository = _repository;
            this.cotizacionBL = _cotizacionBL;   
        }

        public async Task<IList<LotesDisponiblesFiltrosDTO>> getListFiltros(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListFiltros(nIdCompania, nIdUsuario);
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(SelectLotesDisponiblesDTO select)
        {
            var list = await repository.getListLotesDisponibles(select);
            foreach (var item in list) {
                await cotizacionBL.calculateCotizacionValues(item, false);
            }
            return list;
        }
    }
}
