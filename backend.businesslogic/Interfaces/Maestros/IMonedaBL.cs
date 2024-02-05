using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IMonedaBL
    {
        Task<IList<MonedaDTO>> getListMoneda();
        Task<MonedaDTO> getMonedaByID(int nIdMoneda);
        Task<SqlRspDTO> InsMoneda(MonedaDTO moneda);
        Task<SqlRspDTO> UpdMoneda(MonedaDTO moneda);
    }
}
