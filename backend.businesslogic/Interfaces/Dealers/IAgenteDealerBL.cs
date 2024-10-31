﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Dealers
{
    public interface IAgenteDealerBL
    {
        Task<IList<AgenteDealerDTO>> getListAgenteDealer(int nIdUsuario, int nIdCompania);
        Task<AgenteDealerDTO> getAgenteDealerByID(int nIdAgenteDealer, int nIdCompania);
        Task<AgenteDealerDTO> findAgenteDealer(string? sDNI, string? sCE);
        Task<IList<SelectDTO>> getListGeneros();
        Task<IList<SelectDTO>> getListEstadoCivil();
        Task<SqlRspDTO> InsAgenteDealer(AgenteDealerDTO agenteDealer);
        Task<SqlRspDTO> UpdAgenteDealer(AgenteDealerDTO agenteDealer);
        Task<IList<SelectDTO>> getListPerfilDealer();
        Task<SqlRspDTO> BajaAgenteDealer(AgenteDealerDTO agenteDealer);
    }
}
