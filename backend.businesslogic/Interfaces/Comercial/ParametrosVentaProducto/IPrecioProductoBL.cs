using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial.ParametrosVentaProducto
{
    public interface IPrecioProductoBL
    {
        Task<IList<PrecioProductoDTO>> getListPrecioProductoAdicional(int nIdUsuario, int nIdCompania);
        Task<IList<SelectDTO>> getSelectItem(int nIdUsuario, int nIdCompania);
        Task<SqlRspDTO> InsPrecioProducto(PrecioProductoDTO precioProducto);
        Task<SqlRspDTO> UpdPrecioProducto(PrecioProductoDTO precioProducto);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);        
        Task<IList<PrecioProductoDTO>> getListPrecioProductoEspecifica();
    }
}
