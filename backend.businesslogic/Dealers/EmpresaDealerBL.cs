using backend.businesslogic.Interfaces.Dealers;
using backend.domain;
using backend.repository.Interfaces.Dealers;

namespace backend.businesslogic.Dealers
{
    public class EmpresaDealerBL : IEmpresaDealerBL
    {
        IEmpresaDealerRepository repository;

        public EmpresaDealerBL(IEmpresaDealerRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<EmpresaDealerDTO>> getListEmpresaDealer()
        {
            return await repository.getListEmpresaDealer();
        }

        public async Task<EmpresaDealerDTO> getEmpresaDealerByID(int nIdEmpresaDealer)
        {
            return await repository.getEmpresaDealerByID(nIdEmpresaDealer);
        }

        public async Task<EmpresaDealerDTO> findEmpresaByRUC(string sRUC)
        {
            return await repository.findEmpresaByRUC(sRUC);
        }

        public async Task<SqlRspDTO> InsEmpresaDealer(EmpresaDealerDTO empresaDealer)
        {
            return await repository.InsEmpresaDealer(empresaDealer);
        }

        public async Task<SqlRspDTO> UpdEmpresaDealer(EmpresaDealerDTO empresaDealer)
        {
            return await repository.UpdEmpresaDealer(empresaDealer);
        }
    }
}
