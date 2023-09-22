using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Proyectos
{
    public interface IProyectoRepository
    {
        Task<IList<ProyectoDTO>> getListProyectoByCompania(int nIdCompania);
        Task<ProyectoDTO> getProyectoByID(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectCompanias();
        Task<SqlRspDTO> InsProyecto(ProyectoDTO proyecto);
        Task<SqlRspDTO> UpdProyecto(ProyectoDTO proyecto);
    }
}
