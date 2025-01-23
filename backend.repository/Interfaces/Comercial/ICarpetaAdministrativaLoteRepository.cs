using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface ICarpetaAdministrativaLoteRepository
    {
        Task<IList<SelectDTO>> getSelectPrecioCarpetaAdministrativaLote(int nIdLote, decimal nValorInicial, int nIdMoneda);
        Task<SqlRspDTO> InsCarpetaAdministrativaLote(CarpetaAdministrativaLoteDTO instCarpetaAdminLote);
        Task<SqlRspDTO> InsAdicCarpetaAdministrativaLote(CarpetaAdministrativaLoteDTO instCarpetaAdminLote);
    }
}
