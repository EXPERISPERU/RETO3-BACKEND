using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using backend.repository.Interfaces.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class ElementoSistemaBL : IElementoSistemaBL
    {
        IElementoSistemaRepository repository;
        public ElementoSistemaBL(IElementoSistemaRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<ElementoSistemaDTO>> ListElementoByIdP(int nIdElementoP)
        {
            return await repository.ListElementoByIdP(nIdElementoP);
        }

        public async Task<ElementoSistemaDTO> ElementoById(int nIdElemento)
        {
            return await repository.ElementoById(nIdElemento);
        }

        public async Task<SqlRspDTO> InsElementoSistema(ElementoSistemaDTO elemento)
        {
            return await repository.InsElementoSistema(elemento);
        }

        public async Task<SqlRspDTO> UpdElementoSistema(ElementoSistemaDTO elemento)
        {
            return await repository.UpdElementoSistema(elemento);
        }

        public async Task<IList<SelectDTO>> getCompanias()
        { 
            return await repository.getCompanias();
        }

        public async Task<IList<SelectDTO>> getPaises()
        {
            return await repository.getPaises();
        }
    }
}
