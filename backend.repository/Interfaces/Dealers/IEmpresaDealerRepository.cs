﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Dealers
{
    public interface IEmpresaDealerRepository
    {
        Task<IList<EmpresaDealerDTO>> getListEmpresaDealer();
        Task<EmpresaDealerDTO> getEmpresaDealerByID(int nIdEmpresaDealer);
        Task<EmpresaDealerDTO> findEmpresaByRUC(string sRUC);
        Task<SqlRspDTO> InsEmpresaDealer(EmpresaDealerDTO empresaDealer);
        Task<SqlRspDTO> UpdEmpresaDealer(EmpresaDealerDTO empresaDealer);
    }
}
