using backend.domain;

namespace backend.repository.Interfaces.Tesoreria
{
    public interface IOperacionBancariaRepository
    {
        Task<IList<OperacionBancariaDTO>> getAllOperacionBancaria(int nIdCompania, int nIdUsuario);
        Task<IList<SelectDTO>> getAllProyectosByCompania(int nIdCompania, int nIdUsuario);
        Task<IList<CuentaDTO>> getAllCuentasByProyecto(int nIdCompania, int nIdUsuario, int nIdProyecto, int? nIdMoneda);
        Task<SqlRspDTO> InsOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria);
        Task<SqlRspDTO> UpdOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria);
        Task<OperacionBancariaDTO> getOperacionBancariaByCuentaMovimiento(int nIdCompania, int nIdUsuario, int nIdCuenta, int nMovimiento);
    }
}
