using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial.ParametrosVentaLote
{
    public interface IPrecioServicioRepository
    {
        Task<IList<PrecioServicioDTO>> getListPrecioServicioGeneral();
        Task<IList<PrecioServicioDTO>> getListPrecioServicioEspecifica();
        Task<PrecioServicioDTO> getPrecioServicioByID(int nIdPrecioServicio);
        Task<IList<SelectDTO>> getSelectItem();
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectManzanaBySector(int nIdSector);
        Task<IList<SelectDTO>> getSelectLoteByManzana(int nIdManzana);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<SqlRspDTO> InsPrecioServicio(PrecioServicioDTO precioServicio);
        Task<SqlRspDTO> UpdPrecioServicio(PrecioServicioDTO precioServicio);
    }
}
