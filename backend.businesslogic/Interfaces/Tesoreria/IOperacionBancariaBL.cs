using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Tesoreria
{
    public interface IOperacionBancariaBL
    {
        Task<IList<OperacionBancariaDTO>> getAllOperacionBancaria(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getAllProyectosByCompania(int nIdCompania, int nIdUsuario);
        Task<IList<CuentaDTO>> getAllCuentasByProyecto(int nIdCompania, int nIdUsuario, int nIdProyecto, int? nIdMoneda);
        Task<SqlRspDTO> InsOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria);
        Task<SqlRspDTO> UpdOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria);
        Task<OperacionBancariaDTO> getOperacionBancariaByCuentaMovimiento(int nIdCompania, int nIdUsuario, int nIdCuenta, int nMovimiento);
    }
}
