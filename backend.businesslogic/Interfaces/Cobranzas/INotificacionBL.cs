﻿using backend.domain;
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
        Task<IList<PlantillaNotificacionDTO>> getListPlantillaNotificacion();
        Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData);
        Task<SqlRspDTO> posEnviarNotificacion(int nIdNotificacion);
    }
}
