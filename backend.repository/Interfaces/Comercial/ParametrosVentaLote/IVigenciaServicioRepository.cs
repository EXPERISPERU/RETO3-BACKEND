using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{

    public interface IVigenciaServicioRepository
    {
        Task<VigenciaServicioDTO> getListVigenciaServicioById(int nIdVigenciaServicio);
        Task<SqlRspDTO> InsUpdVigenciaServicio(VigenciaServicioDTO vigenciaServicio);
    }
}
