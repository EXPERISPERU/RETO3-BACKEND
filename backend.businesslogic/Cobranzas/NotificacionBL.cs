using backend.businesslogic.Interfaces.Cobranzas;
using backend.domain;
using backend.repository.Interfaces.Cobranzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Cobranzas
{
    public class NotificacionBL : INotificacionBL
    {
        INotificacionRepository repository;

        public NotificacionBL(INotificacionRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO notificacionFilter)
        {
            return await repository.getListNotificacion(notificacionFilter);
        }
        public async Task<IList<PlantillaNotificacionDTO>> getListPlantillaNotificacion()
        {
            return await repository.getListPlantillaNotificacion();
        }
        public async Task<NotificacionDTO> getNotificacionByID(int nIdNotificacion)
        {
            return await repository.getNotificacionByID(nIdNotificacion);
        }
        public async Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData)
        {
            return await repository.posInsNotificacion(notificacionData);
        }
        public async Task<PlantillaNotificacionDTO> getPlantillaNotificacionByID(int nIdPlantilla)
        {
            return await repository.getPlantillaNotificacionByID(nIdPlantilla);
        }
        public async Task<SqlRspDTO> updNotificacionEstado(int nIdNotificacion, string message)
        {
            return await repository.updNotificacionEstado(nIdNotificacion, message);
        }
        public async Task<IList<SelectDTO>> getListFormatoCartas()
        {
            return await repository.getListFormatoCartas();
        }
        public async Task<FormatoDTO> getFormatoCartaByID(int nIdFormato)
        {
            return await repository.getFormatoCartaByID(nIdFormato);
        }
        public async Task<IList<CronogramaDeudaDTO>> getList4CronogramaDeuda(int nIdContrato, int nIdSeguimiento)
        {
            return await repository.getList4CronogramaDeuda(nIdContrato, nIdSeguimiento);
        }
    }
}
