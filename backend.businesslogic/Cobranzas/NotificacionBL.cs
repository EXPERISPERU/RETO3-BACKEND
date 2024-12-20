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
    public class NotificacionBL: INotificacionBL
    {
        INotificacionBL repository;
        public async Task<IList<NotificacionDTO>> getListNotificacion(NotificacionFilterDTO notificacionFilter)
        {
            return await repository.getListNotificacion(notificacionFilter);
        }
    }
}
