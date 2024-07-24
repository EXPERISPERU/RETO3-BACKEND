using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Prospectos
{
    public interface IProspectoRepository
    {
        Task<IList<ProspectoDTO>> getListProspectoByIdUsuario(int nIdUsuario, int nIdCompania, int nTipoListProspecto);
        Task<SqlRspDTO> InsProspecto(ProspectoDTO prospecto);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona);
        Task<IList<ProspectoDTO>> getListProspectoByIdProspecto(int nIdProspecto);
    }
}
