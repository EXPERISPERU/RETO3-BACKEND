using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class ClienteBL : IClienteBL
    {
        IClienteRepository repository;

        public ClienteBL(IClienteRepository _repository)
        { 
            this.repository = _repository;
        }

        public async Task<IList<ClienteDTO>> getListCliente(int nIdUsuario, int nIdCompania, int pagina, int cantpagina, string? sFiltro)
        {
            return await repository.getListCliente(nIdUsuario, nIdCompania, pagina, cantpagina, sFiltro);
        }

        public async Task<ClienteDTO> getClienteByID(int nIdCompania, int nIdCliente)
        { 
            return await repository.getClienteByID(nIdCompania, nIdCliente);
        }

        public async Task<ClienteDTO> findClienteByDoc(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            return await repository.findClienteByDoc(nIdUsuario, sDNI, sCE, sRUC);
        }

        public async Task<IList<SelectDTO>> getListTiposPersona()
        { 
            return await repository.getListTiposPersona();
        }

        public async Task<IList<SelectDTO>> getListGeneros()
        {
            return await repository.getListGeneros();
        }

        public async Task<IList<SelectDTO>> getListEstadoCivil()
        {
            return await repository.getListEstadoCivil();
        }

        public async Task<SqlRspDTO> InsCliente(ClienteDTO cliente)
        {
            return await repository.InsCliente(cliente);
        }

        public async Task<SqlRspDTO> UpdCliente(ClienteDTO cliente)
        {
            return await repository.UpdCliente(cliente);
        }

        public async Task<ApiResponse<ClienteDTO>> findClienteGCByDoc(int nIdUsuario, int nIdCompania, string? sDNI, string? sCE)
        {
            return await repository.findClienteGCByDoc(nIdUsuario, nIdCompania, sDNI, sCE);
        }
    }
}
