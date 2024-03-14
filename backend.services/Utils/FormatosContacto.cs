using backend.domain;

namespace backend.services.Utils
{
    public class FormatosContacto
    {
        public string EmailGetFormatoPortalSauces(FormularioContactoPortalDTO formulario, string sFormato)
        {
            try
            {
                var html = "";
                var sCuerpo = sFormato;

                html += sCuerpo
                        .Replace("#sNombreCliente#", formulario.sNombreCompleto)
                        .Replace("#sDocumento#", formulario.sDNI)
                        .Replace("#sDNI#", formulario.sDNI)
                        .Replace("#sCelular#", formulario.sCelular)
                        .Replace("#sDireccion#", formulario.sUbicacion)
                        .Replace("#sCorreo#", formulario.sCorreo)
                        .Replace("#sTipoSolicitud#", formulario.sTipoSolicitud)
                        ;
                return html;
            }
            catch (Exception ex)
            {
                throw;
            }       
        }
    }
}
