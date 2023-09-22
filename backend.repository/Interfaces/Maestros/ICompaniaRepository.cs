using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface ICompaniaRepository
    {
        Task<IList<CompaniaDTO>> getListCompania();
        Task<SqlRspDTO> InsCompania(CompaniaDTO compania);
        Task<SqlRspDTO> UpdCompania(CompaniaDTO compania);
        Task<CompaniaDTO> getCompaniaByID(int nIdCompania);
    }
}
