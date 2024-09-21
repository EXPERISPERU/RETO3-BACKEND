using backend.businesslogic.Interfaces.Tesoreria;
using backend.domain;
using backend.repository.Interfaces.Tesoreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Tesoreria
{
    public class CajaBL : ICajaBL
    {
        ICajaRepository repository;
        public CajaBL(ICajaRepository _repository) {
            repository = _repository;
        }

        public async Task<IList<CajaDTO>> getListValoresCaja(int nIdCompania, int nIdUsuario)
        {
           return await repository.getListValoresCaja(nIdCompania, nIdUsuario);
        }

        public async Task<SqlRspDTO> getValidaAperturaCaja(int nIdCompania, int nIdUsuario)
        {
            return await repository.getValidaAperturaCaja(nIdCompania, nIdUsuario);
        }

        public async Task<SqlRspDTO> InsCaja(CajaDTO caja)
        {
            return await repository.InsCaja(caja);
        }

        public async Task<SqlRspDTO> getValidaPerfil(int nIdCompania, int nIdUsuario)
        {
            return await repository.getValidaPerfil(nIdCompania, nIdUsuario);
        }
    }
}
