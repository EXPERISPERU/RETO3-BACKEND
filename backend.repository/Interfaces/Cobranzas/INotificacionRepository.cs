﻿using backend.domain;
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
        Task<SqlRspDTO> posInsNotificacion(NotificacionDataDTO notificacionData);
        Task<SqlRspDTO> posEnviarNotificacion(int nIdNotificacion);
    }
}
