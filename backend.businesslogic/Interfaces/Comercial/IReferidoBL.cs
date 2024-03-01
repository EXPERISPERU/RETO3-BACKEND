using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IReferidoBL
    {
        Task<IList<ReferidoDTO>> getListReferido(int nIdUsuario, int nIdCompania);
        Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente);
        Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario);
        Task<PersonaDTO> findPersona(string? sDNI, string? sCE);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<int> getCantReferenciaActivaByPersona(int nIdPersona);
        Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona);
    }
}
