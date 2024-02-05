using backend.domain;
using backend.repository.Interfaces.Maestros;
using backend.businesslogic.Interfaces.Maestros;

namespace backend.businesslogic.Maestros
{
    public class PersonaBL : IPersonaBL
    {
        IPersonaRepository repository;
        public PersonaBL(IPersonaRepository _repository)
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

        public async Task<int> validDocumentoUsuario(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            return await repository.validDocumentoUsuario(nIdUsuario, sDNI, sCE, sRUC);
        }
    }
}
