using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;

namespace backend.businesslogic.Comercial
{
    public class ReferidoBL : IReferidoBL
    {
        IReferidoRepository repository;

        public ReferidoBL(IReferidoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ReferidoDTO>> getListReferido()
        {
            return await repository.getListReferido();
        }

        public async Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente)
        {
            return await repository.getListReferidoByCliente(nIdCliente);
        }

        public async Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania)
        {
            return await repository.getValidAgregarReferido(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario)
        {
            return await repository.InsReferido(nIdCliente, nIdUsuario);
        }
    }
}
