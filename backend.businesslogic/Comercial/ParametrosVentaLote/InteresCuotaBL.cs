using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
    public class InteresCuotaBL : IInteresCuotaBL
    {
        IInteresCuotaRepository repository;

        public InteresCuotaBL(){}

        public InteresCuotaBL(IInteresCuotaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<InteresCuotaDTO>> getListInteresCuota()
        {
            return await repository.getListInteresCuota();
        }

        public async Task<InteresCuotaDTO> getInteresCuotaByID(int nIdInteresCuota)
        {
            return await repository.getInteresCuotaByID(nIdInteresCuota);
        }

        public async Task<IList<SelectDTO>> getSelectTipoInteres()
        {
            return await repository.getSelectTipoInteres();
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            return await repository.getSelectTipoValor();
        }

        public async Task<IList<SelectDTO>> getSelectMoneda()
        {
            return await repository.getSelectMoneda();
        }

        public async Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota)
        {
            return await repository.InsInteresCuota(interesCuota);
        }
    }
}
