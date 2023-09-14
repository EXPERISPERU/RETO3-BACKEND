using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Proyectos
{
    public interface ILoteRepository
    {
        Task<IList<LoteDTO>> getListLotes();
        Task<IList<LoteDTO>> getListLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectEstadosEdicion();
        Task<SqlRspDTO> InsLote(LoteDTO lote);
        Task<SqlRspDTO> UpdLote(LoteDTO lote);
    }
}
