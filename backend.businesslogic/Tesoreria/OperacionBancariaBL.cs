using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using backend.repository.Interfaces.Tesoreria;

namespace backend.businesslogic.Tesoreria
{
    public class OperacionBancariaBL : IOperacionBancariaBL
    {
        IOperacionBancariaRepository repository;
        public OperacionBancariaBL(IOperacionBancariaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<OperacionBancariaDTO>> getAllOperacionBancaria(int nIdCompania, int nIdUsuario)
        {
            return await repository.getAllOperacionBancaria(nIdCompania, nIdUsuario);
        }

        public async Task<IList<SelectDTO>> getAllProyectosByCompania(int nIdCompania, int nIdUsuario)
        {
            return await repository.getAllProyectosByCompania(nIdCompania, nIdUsuario);
        }

        public async Task<IList<CuentaDTO>> getAllCuentasByProyecto(int nIdCompania, int nIdUsuario, int nIdProyecto, int? nIdMoneda)
        {
            return await repository.getAllCuentasByProyecto(nIdCompania, nIdUsuario, nIdProyecto, nIdMoneda);
        }

        public async Task<SqlRspDTO> InsOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria)
        {
            return await repository.InsOperacionBancaria(nIdCompania, operacionBancaria);
        }

        public async Task<SqlRspDTO> UpdOperacionBancaria(int nIdCompania, OperacionBancariaDTO operacionBancaria)
        {
            return await repository.UpdOperacionBancaria(nIdCompania, operacionBancaria);
        }

        public async Task<OperacionBancariaDTO> getOperacionBancariaByCuentaMovimiento(int nIdCompania, int nIdUsuario, int nIdCuenta, int nMovimiento)
        {
            return await repository.getOperacionBancariaByCuentaMovimiento(nIdCompania, nIdUsuario, nIdCuenta, nMovimiento);
        }

        public async Task<SqlRspDTO> InsOperacionBancariaRecaudoBBVA(InsOperacionBancariaRecaudoBBVA operacionBancariaRecaudoBBVA)
        { 
            return await repository.InsOperacionBancariaRecaudoBBVA(operacionBancariaRecaudoBBVA);
        }

        public async Task<IList<OperacionBancariaDTO>> getAllOperacionBancariaRecaudoDisponibles()
        { 
            return await repository.getAllOperacionBancariaRecaudoDisponibles();
        }

        public async Task<SqlRspDTO> UpdOperacionBancariaRecaudo(UpdOperacionBancariaRecaudoDTO updOperacionBancariaRecaudoDTO)
        {
            return await repository.UpdOperacionBancariaRecaudo(updOperacionBancariaRecaudoDTO);
        }
    }
}
