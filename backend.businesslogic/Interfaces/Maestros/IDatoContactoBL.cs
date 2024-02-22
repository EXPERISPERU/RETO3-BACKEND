using backend.domain;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IDatoContactoBL
    {
        Task<IList<DatoContactoDTO>> getListDatoContacto(int nIdPersona);
        Task<IList<SelectDTO>> getSelectMedioContacto();
        Task<SqlRspDTO> InsDatoContacto(DatoContactoDTO datoContacto);
        Task<SqlRspDTO> UpdDatoContacto(DatoContactoDTO datoContacto);
    }
}
