using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class UbigeoBL : IUbigeoBL
    {
        IUbigeoRepository repository;
        public UbigeoBL(IUbigeoRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<PaisDTO>> ListPais()
        { 
            return await repository.ListPais();
        }

        public async Task<IList<UbigeoDTO>> ListUbigeoByIdPTipo(int nIdUbigeoP, int nIdTipoUbigeo, int nIdPais)
        {
            return await repository.ListUbigeoByIdPTipo(nIdUbigeoP, nIdTipoUbigeo, nIdPais);
        }

        public async Task<IList<SelectDTO>> ListTipoUbigeoByPais(int nIdPais)
        {
            return await repository.ListTipoUbigeoByPais(nIdPais);
        }

        public async Task<SqlRspDTO> InsPais(PaisDTO pais)
        {
            return await repository.InsPais(pais);
        }

        public async Task<SqlRspDTO> UpdPais(PaisDTO pais)
        {
            return await repository.UpdPais(pais);
        }
    }
}
