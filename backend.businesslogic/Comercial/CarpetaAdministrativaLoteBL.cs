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
    public class CarpetaAdministrativaLoteBL : ICarpetaAdministrativaLoteBL
    {
        ICarpetaAdministrativaLoteRepository repository;

        public CarpetaAdministrativaLoteBL(ICarpetaAdministrativaLoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioCarpetaAdministrativaLote(int nIdLote, decimal nValorInicial, int nIdMoneda)
        {
            return await repository.getSelectPrecioCarpetaAdministrativaLote(nIdLote, nValorInicial, nIdMoneda);
        }
    }
}
