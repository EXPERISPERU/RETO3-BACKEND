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
        ILotesDisponiblesRepository repository;

        public LotesDisponiblesBL(ILotesDisponiblesRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<LotesDisponiblesFiltrosDTO>> getListFiltros(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListFiltros(nIdCompania, nIdUsuario);
        }

        public async Task<IList<LotesDisponiblesDTO>> getListLotesDisponibles(SelectLotesDisponiblesDTO select)
        {
            var list = await repository.getListLotesDisponibles(select);

            foreach (var item in list) {
                new CotizacionBL().calculateCotizacionValues(item);
            }

            return list;
        }
    }
}
