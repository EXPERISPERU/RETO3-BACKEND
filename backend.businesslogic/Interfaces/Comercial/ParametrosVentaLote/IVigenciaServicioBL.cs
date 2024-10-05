using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaLote
{
     public interface IVigenciaServicioBL
    {
        Task<VigenciaServicioDTO> getListVigenciaServicioById(int nIdVigenciaServicio);
        Task<SqlRspDTO> InsUpdVigenciaServicio(VigenciaServicioDTO vigenciaServicio);
    }
}
