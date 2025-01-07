using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Cobranzas
{
    public interface INotificacionBL
    {
        Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO notificacionFilter);
        Task<IList<SelectDTO>> getListPlantillaNotificacion();
        Task<NotificacionDTO> getNotificacionByID(int? nIdNotificacion);
        Task<PlantillaNotificacionDTO> getPlantillaNotificacionByID(int? nIdPlantilla);
        Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData);
        Task<SqlRspDTO> updNotificacionEstado(int nIdNotificacion, string message);
        Task<IList<SelectDTO>> getListMedioEnvio();
        Task<IList<SelectDTO>> getListFormatoCartas();
        Task<FormatoDTO> getFormatoCartaByID(int? nIdFormato);
        Task<IList<CronogramaDeudaDTO>> getList4CronogramaDeuda(int nIdContrato, int? nIdSeguimiento);
        Task<IList<ClienteDeudaDTO>> getListMorosos(NotificacionFilterDTO filter);
        Task<ContratosDeudaDTO> getDeudaByContratoID(int? nIdCompania, int? nIdCliente, int? nIdContrato);
        Task<IList<NotificacionDTO>> getListNotificacionBySeguimiento(int nIdSeguimiento);

    }
}
