using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface ISerieRepository
    {
        Task<IList<SerieDTO>> getListSerie();
        Task<SerieDTO> getSerieByID(int nIdSerie);
        Task<IList<SelectDTO>> getSelectDocumento();
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectUsuario();
        Task<SqlRspDTO> InsSerie(SerieDTO serie);
        Task<SqlRspDTO> UpdSerie(SerieDTO serie);
    }
}
