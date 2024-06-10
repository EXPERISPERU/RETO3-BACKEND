using backend.businesslogic.Interfaces.Prospectos;
using backend.domain;
using backend.repository.Interfaces.Prospectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Prospectos
{
    public class ProspectoBL : IProspectoBL
    {
        IProspectoRepository repository;
        public ProspectoBL(IProspectoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ProspectoDTO>> getListProspectoByIdUsuario(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListProspectoByIdUsuario(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsProspecto(ProspectoDTO prospecto)
        {
            return await repository.InsProspecto(prospecto);
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona)
        {
            return await repository.InsReferidoByPersona(persona);
        }
    }
}
