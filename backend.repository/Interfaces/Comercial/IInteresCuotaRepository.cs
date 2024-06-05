using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Comercial
{
    public interface IInteresCuotaRepository
    {
        Task<InteresCuotaDTO> getListInteresCuotaById(int nIdProyecto, int nIdCuotaLote);
        Task<SqlRspDTO> InsInteresCuota(InteresCuotaDTO interesCuota);
        Task<IList<ElementoSistemaDTO>> getListMaestroInteres();
        Task<ProyectoDTO> getProyectoByID(int nIdProyecto);
        Task<IList<SelectDTO>> getSelectTipoDescuento();
        Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania);
        Task<IList<ConfiguracionDTO>> getListTipoInteresConfigByIdProyecto(int nIdProyecto);
    }
}
