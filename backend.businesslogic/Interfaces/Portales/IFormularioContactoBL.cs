using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Portales
{
    public interface IFormularioContactoBL
    {
        Task<SqlRspDTO> InsFormularioContacto(AsignacionClienteDTO formulario);
    }
}
