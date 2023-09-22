using backend.businesslogic.Interfaces.Proyectos;
using backend.domain;
using backend.repository.Interfaces.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Proyectos
{
    public class SectorBL : ISectorBL
    {
        ISectorRepository repository;

        public SectorBL(ISectorRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectCompanias()
        {
            return await repository.getSelectCompanias();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        { 
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SectorDTO>> getListSectorByProyecto(int nIdProyecto)
        {
            return await repository.getListSectorByProyecto(nIdProyecto);
        }

        public async Task<SqlRspDTO> InsSector(SectorDTO sector)
        {
            return await repository.InsSector(sector);
        }

        public async Task<SqlRspDTO> UpdSector(SectorDTO sector)
        {
            return await repository.UpdSector(sector);
        }
    }

}
