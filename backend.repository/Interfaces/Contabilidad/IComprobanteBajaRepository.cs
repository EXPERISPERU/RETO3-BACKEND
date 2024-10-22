using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Contabilidad
{
    public interface IComprobanteBajaRepository
    {
        Task<IList<ComprobanteBajaDTO>> getListComprobanteBaja(SelectComprobanteBajaDTO selectComprobanteBaja);
        Task<IList<ComprobanteDTO>> getComprobanteById(int nIdComprobante);
        Task<IList<SelectDTO>> getSelectTipoMotivos();
        Task<SqlRspDTO> InsComprobanteBaja(ComprobanteBajaDTO comprobanteBaja);
        Task<IList<LoginDTO>> AuthUserSuperAnulaCompro(string sUsuario, string sContrasena);
    }
}
