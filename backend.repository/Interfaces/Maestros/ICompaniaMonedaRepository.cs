using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface ICompaniaMonedaRepository
    {
        Task<IList<CompaniaMonedaDTO>> getListMonedaByCompania(int nIdCompania);
        Task<IList<MonedaDTO>> getListMonedaDispByCompania(int nIdCompania);
        Task<SqlRspDTO> InsCompaniaMoneda(CompaniaMonedaDTO companiaMoneda);
        Task<SqlRspDTO> DesActMoneda(CompaniaMonedaDTO companiaMoneda);
        Task<SqlRspDTO> UpdMonedaPrincipal(CompaniaMonedaDTO companiaMoneda);
    }
}
