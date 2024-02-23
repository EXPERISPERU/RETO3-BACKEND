using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;

namespace backend.businesslogic.Maestros
{
    public class DireccionBL : IDireccionBL
    {
        IDireccionRepository repository;
        public DireccionBL(IDireccionRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<DireccionDTO>> getListDireccion(int nIdPersona)
        {
            return await repository.getListDireccion(nIdPersona);
        }

        public async Task<SqlRspDTO> InsDireccion(DireccionDTO direccion)
        {
            return await repository.InsDireccion(direccion);
        }

        public async Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion)
        {
            return await repository.UpdDireccion(direccion);
        }

        public async Task<IList<SelectDTO>> getSelectVias()
        {                                                  
            return await repository.getSelectVias();
        }

        public async Task<SqlRspDTO> UpdDireccionPrincipal(DireccionDTO direccion)
        {
            return await repository.UpdDireccionPrincipal(direccion);
        }
    }
}
