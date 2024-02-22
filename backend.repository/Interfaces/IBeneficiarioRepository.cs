using backend.domain;

namespace backend.repository.Interfaces
{
    public interface IBeneficiarioRepository
    {
        Task<IList<BeneficiarioClienteDTO>> getListBeneficiarioByCliente(int nIdCliente);
        Task<BeneficiarioClienteDTO> findPersona(string? sDNI, string? sCE);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<IList<SelectDTO>> getListRelacionFamiliar();
        Task<SqlRspDTO> InsBeneficiario(BeneficiarioClienteDTO beneficiario);
        Task<SqlRspDTO> UpdBeneficiario(BeneficiarioClienteDTO beneficiario);
    }
}
