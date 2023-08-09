using backend.businesslogic.Interfaces;
using backend.domain;
using backend.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic
{
    public class OpcionBL : IOpcionBL
    {
        IOpcionRepository repository;
        public OpcionBL(IOpcionRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<OpcionDTO>> ListOpcion()
        { 
            return await repository.ListOpcion();
        }

        public async Task<SqlRspDTO> InsOpcionPerfil(PerfilOpcionDTO perfilOpcion) 
        {
            return await repository.InsOpcionPerfil(perfilOpcion);
        }

        public async Task<SqlRspDTO> DelOpcionPerfil(PerfilOpcionDTO perfilOpcion) 
        {
            return await repository.DelOpcionPerfil(perfilOpcion);
        }

        public async Task<IList<SelectDTO>> ListTipoOpcionByIdOpcionP(int nIdOpcion) 
        {
            return await repository.ListTipoOpcionByIdOpcionP(nIdOpcion);
        }

        public async Task<int> CantOpcionHijo(int nIdOpcion)
        {
            return await repository.CantOpcionHijo(nIdOpcion);
        }

        public async Task<SqlRspDTO> InsOpcion(OpcionDTO opcion)
        { 
            return await repository.InsOpcion(opcion);
        }

        public async Task<SqlRspDTO> UpdOpcion(OpcionDTO opcion)
        {
            return await repository.UpdOpcion(opcion);
        }
    }
}
