using backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote;
using backend.domain;
using backend.repository.Interfaces.Comercial.ParametrosVentaLote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.ParametrosVentaLote
{
  
    public class VigenciaServicioBL : IVigenciaServicioBL
    {
        IVigenciaServicioRepository repository;

        public VigenciaServicioBL(IVigenciaServicioRepository _repository)
        {
            repository = _repository;
        }

        public async Task<VigenciaServicioDTO> getListVigenciaServicioById(int nIdVigenciaServicio)
        {
            return await repository.getListVigenciaServicioById(nIdVigenciaServicio);
        }

        public async Task<SqlRspDTO> InsUpdVigenciaServicio(VigenciaServicioDTO vigenciaServicio)
        {
            return await repository.InsUpdVigenciaServicio(vigenciaServicio);
        }

    }
}
