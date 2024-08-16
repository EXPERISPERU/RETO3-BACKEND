using backend.domain;
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
        Task<ProveedorDTO> findProveedorByRUC(string? sDNI, string? sRUC);
        Task<SqlRspDTO> InsProveedor(ProveedorDTO proveedor);
        Task<SqlRspDTO> UpdProveedor(ProveedorDTO proveedor);
        Task<SqlRspDTO> InsJefeComercialProveedor(JefeComercialDTO jefeComercial);
        Task<IList<JefeComercialDTO>> getJefesComercialesByProveedor(int nIdProveedor);
        Task<IList<SelectDTO>> getSelectJefesComerciales(int nIdCompania);
        Task<IList<SelectDTO>> getSelectTipoPersona();
    }
}
