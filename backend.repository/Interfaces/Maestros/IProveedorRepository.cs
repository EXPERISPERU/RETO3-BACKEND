using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Maestros
{
    public interface IProveedorRepository
    {
        Task<IList<ProveedorDTO>> getListProveedor();
        Task<ProveedorDTO> getProveedorByID(int nIdProveedor);
        Task<ProveedorDTO> findProveedorByRUC(string? sDNI, string? sRUC);
        Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor);
        Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor);
        Task<SqlRspDTO> InsJefeComercialProveedor(JefeComercialDTO jefeComercial);
        Task<IList<JefeComercialDTO>> getJefesComercialesByProveedor(int nIdProveedor);
        Task<IList<SelectDTO>> getSelectJefesComerciales();
        Task<IList<SelectDTO>> getSelectTipoPersona();
    }
}
