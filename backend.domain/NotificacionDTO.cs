using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.domain
{
    public class NotificacionDTO
    {
        public int nIdNotificacion { get; set; }
        public int nIdTipoNotificacion { get; set; }
        public string? sTipoNotificacion { get; set; }
        public int? nIdPlantilla { get; set; }
        public int? nIdSeguimiento { get; set; }
        public int? nIdCliente { get; set; }
        public int? nIdContrato { get; set; }
        public int? nIdEstado { get; set; }
        public DateTime? dFechaEnvio { get; set; }
        public int? nIdUsuarioCrea { get; set; }
        public DateTime dFechaCrea { get; set; }
    }


    public class NotificationDetDTO
    {
        public int nIdNotificacionDet { get; set; }
        public int nIdNotificacion { get; set; }
        public int nSecuencial { get; set; }
        public int nIdCliente { get; set; }
        public int nIdContrato { get; set; }
        public int nIdSeguimiento { get; set; }
        public int nIdAdjunto { get; set; }
        public string? sUrlAdjunto { get; set; }
        public int nIdManzana { get; set; }
        public string? sManzana { get; set; }
        public int nIdLote { get; set; }
        public string? sLote { get; set; }
        public string? sInmueble { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }

    public class NotificacionFormatoDTO
    {
        public int nIdNotificacion { get; set; }
        public int nIdFormato { get; set; }
    }

    public class NotificacionFilterDTO
    {
        public int nTipoNotificacion { get; set; }
        public int nGrupo { get; set; }
    }

    public class PlantillaNotificacionDTO
    {
        public int nIdPlantilla { get; set; }
        public string? sDescripcion { get; set; }
        public string? sContenido { get; set; }
        public int? nEstado { get; set; }
        public int? nIdUsuario_crea { get; set; }
        public DateTime dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }

    public class NotificacionDataDTO
    {
        public int? nIdCliente { get; set; }
        public int? nIdContrato { get; set; }
        public int? nIdTipoNotificacion { get; set; }
        public int? nIdPlantilla { get; set; }
    }

    public class NotificacionResponseDTO
    {
        public bool sent { get; set; }
        public string? message { get; set; }
        public string? error { get; set; }
        public int? id { get; set; }
    }
}
