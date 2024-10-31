using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using backend.repository.Interfaces.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Contabilidad
{
    public class ComprobanteBajaBL : IComprobanteBajaBL
    {

        IComprobanteBajaRepository repository;

        public ComprobanteBajaBL(IComprobanteBajaRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<ComprobanteBajaDTO>> getListComprobanteBaja(SelectComprobanteBajaDTO selectComprobanteBaja)
        {
            return await repository.getListComprobanteBaja(selectComprobanteBaja);
        }

        public async Task<IList<ComprobanteDTO>> getComprobanteById(int nIdComprobante)
        {
            return await repository.getComprobanteById(nIdComprobante);
        }

        public async Task<IList<SelectDTO>> getSelectTipoMotivos()
        {
            return await repository.getSelectTipoMotivos();
        }

        public async Task<SqlRspDTO> InsComprobanteBaja(ComprobanteBajaDTO comprobanteBaja)
        {
            return await repository.InsComprobanteBaja(comprobanteBaja);
        }

        public async Task<IList<LoginDTO>> AuthUserSuperAnulaCompro(string sUsuario, string sContrasena)
        {
            return await repository.AuthUserSuperAnulaCompro(sUsuario, sContrasena);
        }
    }
}
