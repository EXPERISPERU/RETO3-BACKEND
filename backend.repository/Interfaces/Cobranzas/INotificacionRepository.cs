using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Interfaces.Cobranzas
{
    public interface INotificacionRepository
    {
        Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO notificacionFilter);
        Task<IList<PlantillaNotificacionDTO>> getListPlantillaNotificacion();
        Task<NotificacionDTO> getNotificacionByID(int? nIdNotificacion);
        Task<PlantillaNotificacionDTO> getPlantillaNotificacionByID(int? nIdPlantilla);
        Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData);
        Task<IList<SelectDTO>> getListMedioEnvio();
        Task<SqlRspDTO> updNotificacionEstado(int nIdNotificacion, string message);
        Task<IList<SelectDTO>> getListFormatoCartas();
        Task<FormatoDTO> getFormatoCartaByID(int? nIdFormato);
        Task<IList<CronogramaDeudaDTO>> getList4CronogramaDeuda(int nIdContrato, int? nIdSeguimiento);
        Task<IList<ClienteDeudaDTO>> getListMorosos(NotificacionFilterDTO notificacionFilter);
        Task<ContratosDeudaDTO> getDeudaByContratoID(int? nIdCompania, int? nIdContrato);
        Task<IList<NotificacionDTO>> getListNotificacionBySeguimiento(int? nIdSeguimiento);
    }
}
