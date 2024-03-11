using backend.domain;

namespace backend.repository.Interfaces.Contacto
{
    public interface IFormularioContactoRepository
    {
        Task<SqlRspDTO> InsFormularioContactoPortal(FormularioContactoPortalDTO formulario);
    }
}
