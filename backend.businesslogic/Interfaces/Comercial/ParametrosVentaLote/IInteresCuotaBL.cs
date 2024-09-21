using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IInteresCuotaBL
    {
        Task<IList<InteresCuotaDTO>> getListInteresCuota();
        Task<InteresCuotaDTO> getInteresCuotaByID(int nIdInteresCuota);
        Task<IList<SelectDTO>> getSelectTipoInteres();
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<IList<SelectDTO>> getSelectMoneda();
        Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota);
    }
}
