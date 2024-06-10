using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Prospectos
{
    public interface IProspectoBL
    {
        Task<IList<ProspectoDTO>> getListProspectoByIdUsuario(int nIdUsuario);
        Task<SqlRspDTO> InsProspecto(ProspectoDTO prospecto);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona);
        Task<IList<ProspectoDTO>> getListProspectoByIdProspecto(int nIdProspecto);
    }
}
