using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IOficinaBL
    {
        Task<IList<OficinaDTO>> getListOficinaByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getTipoOficina();
        Task<IList<SelectDTO>> getListOficinaPByTipo(int nIdCompania, int nIdTipoOficina);
        Task<SqlRspDTO> InsOficina(OficinaDTO oficina);
        Task<SqlRspDTO> UpdOficina(OficinaDTO oficina);
    }
}
