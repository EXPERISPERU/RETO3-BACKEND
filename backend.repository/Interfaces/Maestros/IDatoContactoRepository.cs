using backend.domain;

namespace backend.repository.Interfaces.Maestros
{
    public interface IDatoContactoRepository
    {
        Task<IList<DatoContactoDTO>> getListDatoContacto(int nIdPersona);
        Task<IList<SelectDTO>> getSelectMedioContacto();
        Task<SqlRspDTO> InsDatoContacto(DatoContactoDTO datoContacto);
        Task<SqlRspDTO> UpdDatoContacto(DatoContactoDTO datoContacto);
    }
}
