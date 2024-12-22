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
        public async Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData)
        {
            return await repository.posInsNotificacion(notificacionData);
        }
        public async Task<SqlRspDTO> posEnviarNotificacion(int nIdNotificacion)
        {
            return await repository.posEnviarNotificacion(nIdNotificacion);
        }
    }
}
