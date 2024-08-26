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
                        .Replace("#sCelular#", formulario.sCelular)
                        .Replace("#sDireccion#", formulario.sUbicacion)
                        .Replace("#sCorreo#", formulario.sCorreo)
                        .Replace("#sTipoSolicitud#", formulario.sTipoSolicitud)
                        ;
                //html += sCuerpo
                //        .Replace("#sCelular#", formulario.sCelular)
                //        .Replace("#sCorreo#", formulario.sCorreo)
                //        ;
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al formatear el correo: {ex.Message}");
                throw;
            }       
        }
    }
}
