using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IReferidoBL
    {
        Task<IList<ReferidoDTO>> getListReferido();
        Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente);
        Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario);
    }
}
