namespace backend.services.Utils
{
    public class Sunat
    {
        public string TipoDocumento(string sCodigoTipoComprobante)
        {
            if (sCodigoTipoComprobante == "14") return "01";

            if (sCodigoTipoComprobante == "3") return "03"; //boleta

            if (sCodigoTipoComprobante == "18") return "07"; // Nota Credito

            return "";
        }
    }
}
