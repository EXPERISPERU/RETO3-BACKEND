using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Tesoreria
{
    public interface ICajaBL
    {
        Task<IList<CajaDTO>> getListValoresCaja(int nIdCompania, int nIdUsuario);
        Task<SqlRspDTO> getValidaAperturaCaja(int nIdCompania, int nIdUsuario);
        Task<SqlRspDTO> InsCaja(CajaDTO caja);
        Task<SqlRspDTO> getValidaPerfil(int nIdCompania, int nIdUsuario);
    }
}
