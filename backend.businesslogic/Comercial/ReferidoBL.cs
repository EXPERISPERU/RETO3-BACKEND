﻿using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System.Runtime.Intrinsics.X86;

namespace backend.businesslogic.Comercial
{
    public class ReferidoBL : IReferidoBL
    {
        IReferidoRepository repository;

        public ReferidoBL(IReferidoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ReferidoDTO>> getListReferido(int nIdUsuario, int nIdCompania)
        {
            return await repository.getListReferido(nIdUsuario, nIdCompania);
        }

        public async Task<IList<ReferidoDTO>> getListReferidoByCliente(int nIdCliente)
        {
            return await repository.getListReferidoByCliente(nIdCliente);
        }

        public async Task<int> getValidAgregarReferido(int nIdUsuario, int nIdCompania)
        {
            return await repository.getValidAgregarReferido(nIdUsuario, nIdCompania);
        }

        public async Task<SqlRspDTO> InsReferido(int nIdCliente, int nIdUsuario)
        {
            return await repository.InsReferido(nIdCliente, nIdUsuario);
        }

        public async Task<PersonaDTO> findPersona(string? sDNI, string? sCE)
        {
            return await repository.findPersona(sDNI, sCE);
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<int> getCantReferenciaActivaByPersona(int nIdPersona)
        {
            return await repository.getCantReferenciaActivaByPersona(nIdPersona);
        }

        public async Task<SqlRspDTO> InsReferidoByPersona(PersonaDTO persona) 
        {
            return await repository.InsReferidoByPersona(persona);
        }
    }
}
