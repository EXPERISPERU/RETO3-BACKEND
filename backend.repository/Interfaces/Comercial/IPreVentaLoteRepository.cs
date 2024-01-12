using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IPreVentaLoteRepository
    {
        Task<IList<SelectDTO>> getSelectPrecioPreVentaByLoteInicial(int nIdLote, decimal nValorInicial);
        Task<SqlRspDTO> InsPreventaLote(InsPreVentaLoteDTO insPreventaLote);
        Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario);
    }
}
