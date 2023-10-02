using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IListaPrecioBL
    {
        Task<IList<ListaPrecioDTO>> getListListaPrecio();
        Task<ListaPrecioDTO> getListaPrecio(int nIdListaPrecio);
        Task<IList<SelectDTO>> getSelectTipoListaPrecio();
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectGrupo();
        Task<IList<SelectDTO>> getSelectUbicacion();
        Task<IList<SelectDTO>> getSelectSectorByProyecto(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectEstadoSector();
        Task<SqlRspDTO> InsListaPrecio(ListaPrecioDTO listaPrecio);
        Task<SqlRspDTO> UpdListaPrecio(ListaPrecioDTO listaPrecio);
    }
}
