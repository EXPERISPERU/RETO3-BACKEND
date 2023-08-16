using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IUbigeoBL
    {
        Task<IList<PaisDTO>> ListPais();
        Task<IList<UbigeoDTO>> ListUbigeoByIdPTipo(int nIdUbigeoP, int nIdTipoUbigeo, int nIdPais);
        Task<IList<SelectDTO>> ListTipoUbigeoByPais(int nIdPais);
        Task<SqlRspDTO> InsPais(PaisDTO pais);
        Task<SqlRspDTO> UpdPais(PaisDTO pais);
    }
}
