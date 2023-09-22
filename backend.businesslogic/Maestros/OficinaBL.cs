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
    public class OficinaBL : IOficinaBL
    {
        IOficinaRepository repository;
        public OficinaBL(IOficinaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<OficinaDTO>> getListOficinaByCompania(int nIdCompania)
        { 
            return await repository.getListOficinaByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getTipoOficina()
        {
            return await repository.getTipoOficina();
        }

        public async Task<IList<SelectDTO>> getListOficinaPByTipo(int nIdCompania, int nIdTipoOficina)
        {
            return await repository.getListOficinaPByTipo(nIdCompania, nIdTipoOficina);
        }

        public async Task<SqlRspDTO> InsOficina(OficinaDTO oficina)
        {
            return await repository.InsOficina(oficina);
        }

        public async Task<SqlRspDTO> UpdOficina(OficinaDTO oficina)
        {
            return await repository.UpdOficina(oficina);
        }
    }
}
