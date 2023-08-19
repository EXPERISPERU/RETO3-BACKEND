using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class CompaniaBL : ICompaniaBL
    {
        ICompaniaRepository repository;
        public CompaniaBL(ICompaniaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CompaniaDTO>> getListCompania()
        {
            return await repository.getListCompania();
        }

        public async Task<SqlRspDTO> InsCompania(CompaniaDTO compania)
        {
            return await repository.InsCompania(compania);
        }

        public async Task<SqlRspDTO> UpdCompania(CompaniaDTO compania)
        {
            return await repository.UpdCompania(compania);
        }
    }
}
