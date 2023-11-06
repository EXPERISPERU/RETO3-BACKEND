using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial.Inicial
{
    public interface IInicialLoteRepository
    {
        Task<IList<InicialLoteDTO>> getListInicialLote();
        Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote);
        Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO inicialLote);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
    }
}
