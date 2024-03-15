using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IClienteBL
    {
        Task<IList<ClienteDTO>> getListCliente(int nIdUsuario, int nIdCompania, int pagina, int cantpagina, string? sFiltro);
        Task<ClienteDTO> getClienteByID(int nIdCliente);
        Task<ClienteDTO> findClienteByDoc(int nIdUsuario, string? sDNI, string? sCE, string? sRUC);
        Task<IList<SelectDTO>> getListTiposPersona();
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsCliente(ClienteDTO cliente);
        Task<SqlRspDTO> UpdCliente(ClienteDTO cliente);
        Task<ApiResponse<ClienteDTO>> findClienteGCByDoc(int nIdUsuario, int nIdCompania, string? sDNI, string? sCE);

    }
}
