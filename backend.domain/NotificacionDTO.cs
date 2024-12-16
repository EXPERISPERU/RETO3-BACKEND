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
        public int nMedio {  get; set; }
        public int nIdEstado {  get; set; }
        public int nGrupo {  get; set; }
        public int nIncludeFile {  get; set; }
        public int nIdUsuario_aprove { get; set; }
        public string? sUsuario_aprove { get; set; }
        public int nIdUsuario_crea { get; set; }
        public string? sUsuario_crea { get; set; }
        public DateTime? dFecha_crea { get; set; }
        public int? nIdUsuario_mod { get; set; }
        public string? sUsuario_mod { get; set; }
        public DateTime? dFecha_mod { get; set; }
    }

    public class NotificationDetDTO
    {
        public int nIdNotificacionDet { get; set; }
        public int nIdNotificacion { get; set; }
        public int nSecuencial {  get; set; }
        public int nIdCliente {  get; set; }
        public int nIdContrato { get; set; }
        public int nIdSeguimiento { get; set; }
        public int nIdAdjunto {  get; set; }
        public string? sUrlAdjunto { get; set; }
        public int nIdManzana { get;set; }
        public string? sManzana { get; set; }
        public int nIdLote {  get; set; }
        public string? sLote { get;set; }
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
        public int nGrupo {  get; set; }

    }


}
