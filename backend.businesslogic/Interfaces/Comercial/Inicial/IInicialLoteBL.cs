using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial.Inicial
{
    public interface IInicialLoteBL
    {
        Task<IList<InicialLoteDTO>> getListInicialLote();
        Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectTipoValor();
        Task<SqlRspDTO> InsInicialLote(InicialLoteDTO inicialLote);
        Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO inicialLote);
    }
}
