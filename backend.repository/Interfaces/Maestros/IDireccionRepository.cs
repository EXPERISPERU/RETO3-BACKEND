using backend.domain;

namespace backend.repository.Interfaces.Maestros
{
    public interface IDireccionRepository
    {
        Task<IList<DireccionDTO>> getListDireccion(int nIdPersona);
        Task<SqlRspDTO> InsDireccion(DireccionDTO direccion);
        Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion);
        Task<IList<SelectDTO>> getSelectVias();
        Task<SqlRspDTO> UpdDireccionPrincipal(DireccionDTO direccion);
    }
}
