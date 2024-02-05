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
    public class CompaniaMonedaBL : ICompaniaMonedaBL
    {
        ICompaniaMonedaRepository repository;
        public CompaniaMonedaBL(ICompaniaMonedaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<CompaniaMonedaDTO>> getListMonedaByCompania(int nIdCompania)
        {
            return await repository.getListMonedaByCompania(nIdCompania);
        }

        public async Task<IList<MonedaDTO>> getListMonedaDispByCompania(int nIdCompania)
        {
            return await repository.getListMonedaDispByCompania(nIdCompania);
        }

        public async Task<SqlRspDTO> InsCompaniaMoneda(CompaniaMonedaDTO companiaMoneda)
        {
            return await repository.InsCompaniaMoneda(companiaMoneda);
        }

        public async Task<SqlRspDTO> DesActMoneda(CompaniaMonedaDTO companiaMoneda)
        {
            return await repository.DesActMoneda(companiaMoneda);
        }

        public async Task<SqlRspDTO> UpdMonedaPrincipal(CompaniaMonedaDTO companiaMoneda)
        {
            return await repository.UpdMonedaPrincipal(companiaMoneda);
        }
    }
}
