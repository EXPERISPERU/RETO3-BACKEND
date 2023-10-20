﻿using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Maestros
{
    public interface IProveedorBL
    {
        Task<IList<ProveedorDTO>> getListProveedor();
        Task<ProveedorDTO> getProveedorByID(int nIdProveedor);
        Task<ProveedorDTO> findProveedorByRUC(string sRUC);
        Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor);
        Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor);
    }
}
