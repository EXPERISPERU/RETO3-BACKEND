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
    public class ProyectoBL : IProyectoBL
    {
        IProyectoRepository repository;

        public ProyectoBL(IProyectoRepository _repository) 
        {
            this.repository = _repository;
        }

        public async Task<IList<ProyectoDTO>> getListProyectoByCompania(int nIdCompania)
        {
            return await this.repository.getListProyectoByCompania(nIdCompania);
        }
        public async Task<ProyectoDTO> getProyectoByID(int nIdProyecto)
        {
            return await this.repository.getProyectoByID(nIdProyecto);
        }
        public async Task<IList<SelectDTO>> getSelectCompanias() 
        {
            return await this.repository.getSelectCompanias();
        }
        public async Task<SqlRspDTO> InsProyecto(ProyectoDTO proyecto)
        {
            return await this.repository.InsProyecto(proyecto);
        }
        public async Task<SqlRspDTO> UpdProyecto(ProyectoDTO proyecto)
        {
            return await this.repository.UpdProyecto(proyecto);
        }
    }
}
