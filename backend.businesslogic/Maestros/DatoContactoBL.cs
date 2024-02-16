using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;

namespace backend.businesslogic.Maestros
{
    public class DatoContactoBL : IDatoContactoBL
    {
        IDatoContactoRepository repository;
        public DatoContactoBL(IDatoContactoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<DatoContactoDTO>> getListDatoContacto(int nIdPersona)
        {
            return await repository.getListDatoContacto(nIdPersona);
        }

        public async Task<IList<SelectDTO>> getSelectMedioContacto()
        {
            return await repository.getSelectMedioContacto();
        }

        public async Task<SqlRspDTO> InsDatoContacto(DatoContactoDTO datoContacto)
        {
            return await repository.InsDatoContacto(datoContacto);
        }

        public async Task<SqlRspDTO> UpdDatoContacto(DatoContactoDTO datoContacto)
        { 
            return await repository.UpdDatoContacto(datoContacto);
        }
    }
}
