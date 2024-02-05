using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface IMonedaRepository
    {
        Task<IList<MonedaDTO>> getListMoneda();
        Task<MonedaDTO> getMonedaByID(int nIdMoneda);
        Task<SqlRspDTO> InsMoneda(MonedaDTO moneda);
        Task<SqlRspDTO> UpdMoneda(MonedaDTO moneda);
    }
}
