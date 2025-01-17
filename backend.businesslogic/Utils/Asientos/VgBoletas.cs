using backend.domain;
using System.Globalization;


namespace backend.businesslogic.Utils.Asientos
{
    public class VgBoletas
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");
        public VgBoletas() { }

        public string Debe(VisitaGuiadaBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|D|||";
        }

        public string Igv(VisitaGuiadaBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|||{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorIgv)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|H|||";
        }

        public string Haber(VisitaGuiadaBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|||{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorSubTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|H|||";
        }
    }
}