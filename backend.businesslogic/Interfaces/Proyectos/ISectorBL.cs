using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Proyectos
{
    public interface ISectorBL
    {
        Task<IList<SelectDTO>> getSelectCompanias();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SectorDTO>> getListSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectEstado();
        Task<SqlRspDTO> InsSector(SectorDTO sector);
        Task<SqlRspDTO> UpdSector(SectorDTO sector);
    }
}
