using backend.domain;

namespace backend.repository.Interfaces.Comercial
{
    public interface IReferidoRepository
    {
        Task<IList<ReferidoDTO>> getListReferido();
        Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente);
        Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario);
    }
}
