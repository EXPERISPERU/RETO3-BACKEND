using backend.domain;
using System.Globalization;


namespace backend.businesslogic.Utils.Asientos
{
    public class Devoluciones
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");
        public Devoluciones() { }

        public string Debe(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|||{string.Format(ci_PE, "{0:00.00}", asiento.nValorSubTotal)}|VTA|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D|||{asiento.sCodProyecto}|{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }


        public string Igv(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|||{string.Format(ci_PE, "{0:00.00}", asiento.nValorIgv)}|VTA|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D||||{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }

        public string Haber(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|{string.Format(ci_PE, "{0:00.00}", asiento.nValorIgv)}|{string.Format(ci_PE, "{0:00.00}", asiento.nPorcentageIgv)}|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H||||{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }
    }
}