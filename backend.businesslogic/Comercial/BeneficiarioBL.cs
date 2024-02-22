using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces;

namespace backend.businesslogic.Comercial
{
    public class BeneficiarioBL : IBeneficiarioBL
    {
        IBeneficiarioRepository repository;
        public BeneficiarioBL(IBeneficiarioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<BeneficiarioClienteDTO>> getListBeneficiarioByCliente(int nIdCliente)
        {
            return await repository.getListBeneficiarioByCliente(nIdCliente);
        }

        public async Task<BeneficiarioClienteDTO> findPersona(string? sDNI, string? sCE)
        {
            return await repository.findPersona(sDNI, sCE);
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<IList<SelectDTO>> getListRelacionFamiliar()
        {
            return await repository.getListRelacionFamiliar();
        }

        public async Task<SqlRspDTO> InsBeneficiario(BeneficiarioClienteDTO beneficiario)
        {
            return await repository.InsBeneficiario(beneficiario);
        }

        public async Task<SqlRspDTO> UpdBeneficiario(BeneficiarioClienteDTO beneficiario)
        {
            return await repository.UpdBeneficiario(beneficiario);
        }
    }
}
