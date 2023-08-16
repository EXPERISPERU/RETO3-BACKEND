using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IElementoSistemaBL
    {
        Task<IList<ElementoSistemaDTO>> ListElementoByIdP(int nIdElementoP);
        Task<ElementoSistemaDTO> ElementoById(int nIdElemento);
        Task<SqlRspDTO> InsElementoSistema(ElementoSistemaDTO elemento);
        Task<SqlRspDTO> UpdElementoSistema(ElementoSistemaDTO elemento);
        Task<IList<SelectDTO>> getCompanias();
    }
}
