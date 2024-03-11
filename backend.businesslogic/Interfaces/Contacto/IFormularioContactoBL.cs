using backend.domain;

namespace backend.businesslogic.Interfaces.Contacto
{
    public interface IFormularioContactoBL
    {
        Task<SqlRspDTO> InsFormularioContactoPortal(FormularioContactoPortalDTO formulario);
    }
}
