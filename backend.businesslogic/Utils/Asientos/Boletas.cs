using backend.domain;
using System.Globalization;


namespace backend.businesslogic.Utils.Asientos
{
    public class Boletas
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");

        public Boletas() { }
        public string Debe(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||{string.Format(ci_PE, "{0:00.00}", asiento.nValorIgv)}|{string.Format(ci_PE, "{0:00.00}", asiento.nPorcentageIgv)}|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D||||{asiento.sFechaDocumento}||0";
        }

        public string Igv(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||||{string.Format(ci_PE, "{0:00.00}", asiento.nValorIgv)}|VTA|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H||||{asiento.sFechaDocumento}||0";
        }

        public string Haber(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||||{string.Format(ci_PE, "{0:00.00}", asiento.nValorSubTotal)}|VTA|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H|||{asiento.sCodProyecto}|{asiento.sFechaDocumento}||0";
        }
    }
}