using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IPreVentaLoteBL
    {
        Task<IList<SelectDTO>> getSelectPrecioPreVentaByLoteInicial(int nIdLote, decimal nValorInicial);
        Task<SqlRspDTO> InsPreventaLote(InsPreVentaLoteDTO insPreventaLote);
        Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario);
    }
}
