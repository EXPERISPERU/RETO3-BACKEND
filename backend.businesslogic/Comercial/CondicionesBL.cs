using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Maestros;

namespace backend.businesslogic.Comercial
{
    public class CondicionesBL : ICondicionesBL
    {
        ICondicionesRepository repository;

        public CondicionesBL(ICondicionesRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CondicionesDTO>> getListCondiciones(int nIdCompania, int nIdUsuario)
        {
            return await repository.getListCondiciones(nIdCompania, nIdUsuario);
        }

        public async Task<SqlRspDTO> InsCondiciones(CondicionesDTO condiciones)
        {
            return await repository.InsCondiciones(condiciones);
        }

        public async Task<SqlRspDTO> UpdCondiciones(CondicionesDTO condiciones)
        {
            return await repository.UpdCondiciones(condiciones);
        }

        public async Task<IList<SelectDTO>> SelectTipoCondiciones()
        { 
            return await repository.SelectTipoCondiciones();
        }
    }
}
