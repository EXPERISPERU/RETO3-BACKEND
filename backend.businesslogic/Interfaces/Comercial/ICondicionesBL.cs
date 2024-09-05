
using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface ICondicionesBL
    {
        Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario);
        Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones);
        Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones);
        Task<IList<SelectDTO>> SelectTipoCondiciones();
    }
}
