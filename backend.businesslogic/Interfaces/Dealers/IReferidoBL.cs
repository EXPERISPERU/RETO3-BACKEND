using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface IReferidoBL
    {
        Task<IList<ReferidoDTO>> getListReferido();
        Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente);
        Task<int> getIdAgenteDealer(int nIdUsuario);
        Task<SqlRspDTO> InsReferido(ReferidoDTO referido);
    }
}
