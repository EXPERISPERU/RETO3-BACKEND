using backend.businesslogic.Interfaces.Contacto;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using backend.repository.Interfaces.Contacto;

namespace backend.businesslogic.Contacto
{
    public class FormularioContactoBL : IFormularioContactoBL
    {
        IFormularioContactoRepository repository;
        public FormularioContactoBL(IFormularioContactoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<SqlRspDTO> InsFormularioContactoPortal(FormularioContactoPortalDTO formulario)
        {
            return await repository.InsFormularioContactoPortal(formulario);
        }

    }
}
