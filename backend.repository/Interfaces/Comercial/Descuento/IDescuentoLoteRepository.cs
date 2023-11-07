using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial.Descuento
{
    public interface IDescuentoLoteRepository
    {
        Task<IList<DescuentoLoteDTO>> getListDescuentoLote();
        Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote);
        Task<IList<SelectDTO>> getSelectCompania();
        Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania);
        Task<IList<SelectDTO>> getSelectCondicionPago();
        Task<IList<SelectDTO>> getSelectTipoDescuento();
        Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote);
        Task<SqlRspDTO> UpdDescuentoLote(DescuentoLoteDTO descuentoLote);
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
    }
}
