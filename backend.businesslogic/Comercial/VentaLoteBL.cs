using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class VentaLoteBL : IVentaLoteBL
    {
        IVentaLoteRepository repository;

        public VentaLoteBL(IVentaLoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario)
        {
            return await repository.getSelectMedioPago(nIdUsuario);
        }

        public async Task<IList<SelectDTO>> getSelectCicloPago(int nIdLote)
        {
            return await repository.getSelectCicloPago(nIdLote);
        }

        public async Task<SqlRspDTO> InsVentaLote(InsVentaLoteDTO insVentaLoteDTO)
        {
            return await repository.InsVentaLote(insVentaLoteDTO);
        }

        public async Task<IList<VentaLoteChartDTO>> getListVentaChart(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListVentaChart(nIdUsuario, nIdCompania);
        }


    }
}
