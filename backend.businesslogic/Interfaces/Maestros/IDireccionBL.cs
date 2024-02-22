using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IDireccionBL
    {
        Task<IList<DireccionDTO>> getListDireccion(int nIdPersona);
        Task<SqlRspDTO> InsDireccion(DireccionDTO direccion);
        Task<SqlRspDTO> UpdDireccion(DireccionDTO direccion);
        Task<IList<SelectDTO>> getSelectVias();
    }
}
