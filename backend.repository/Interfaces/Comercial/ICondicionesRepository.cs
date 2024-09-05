using backend.domain;

namespace backend.repository.Interfaces.Comercial
{
    public interface ICondicionesRepository
    {
        Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario);
        Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones);
        Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones);
        Task<IList<SelectDTO>> SelectTipoCondiciones();
    }
}
