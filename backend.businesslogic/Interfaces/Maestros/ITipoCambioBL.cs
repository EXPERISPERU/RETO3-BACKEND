using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface ITipoCambioBL
    {
        Task<SqlRspDTO> insTipoCambio(TipoCambioDTO tipocambio);
    }
}
