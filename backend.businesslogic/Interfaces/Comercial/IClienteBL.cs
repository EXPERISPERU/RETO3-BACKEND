﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IClienteBL
    {
        Task<IList<ClienteDTO>> getListCliente();
        Task<ClienteDTO> getClienteByID(int nIdCliente);
        Task<AgenteDealerDTO> findClienteByDoc(string? sDNI, string? sCE, string? sRUC);
        Task<IList<SelectDTO>> getListTiposPersona();
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsCliente(ClienteDTO cliente);
        Task<SqlRspDTO> UpdCliente(ClienteDTO cliente);
    }
}
