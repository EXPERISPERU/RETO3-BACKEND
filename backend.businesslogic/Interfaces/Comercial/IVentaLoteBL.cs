using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IVentaLoteBL
    {
        Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario);
        Task<IList<SelectDTO>> getSelectCicloPago(int nIdLote);
        Task<SqlRspDTO> InsVentaLote(InsVentaLoteDTO insVentaLoteDTO);
        Task<IList<VentaLoteChartDTO>> getListVentaChart(int nIdUsuario, int nIdCompania);
    }
}
