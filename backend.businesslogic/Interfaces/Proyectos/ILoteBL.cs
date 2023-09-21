using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Proyectos
{
    public interface ILoteBL
    {
        Task<IList<LoteDTO>> getListLotes();
        Task<IList<LoteDTO>> getListLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectEstadosEdicion();
        Task<IList<SelectDTO>> getSelectUbicaciones();
        Task<IList<SelectDTO>> getSelectTerrenos();
        Task<IList<SelectDTO>> getSelectGrupos();
        Task<IList<SelectDTO>> getSelectZonificacion();
        Task<IList<SelectDTO>> getSelectDescripcion();
        Task<SqlRspDTO> InsLote(LoteDTO lote);
        Task<SqlRspDTO> UpdLote(LoteDTO lote);
    }
}
