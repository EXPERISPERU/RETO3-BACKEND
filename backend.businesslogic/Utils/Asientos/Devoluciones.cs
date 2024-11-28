using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class Devoluciones
    {
        public Devoluciones() { }

        public string Debe(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|||{asiento.nValorSubTotal}|VTA|{asiento.nTipoCambio}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D|||{asiento.sCodProyecto}|{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }


        public string Igv(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|||{asiento.nValorIgv}|VTA|{asiento.nTipoCambio}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D||||{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }

        public string Haber(AsientoDevolucionDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|CC|{asiento.sComprobante}|{asiento.sFechaDocumento}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobanteOrigen}|{asiento.nValorIgv}|{asiento.nPorcentageIgv}|{asiento.nValorTotal}|VTA|{asiento.nTipoCambio}|CC {asiento.sComprobante} / {asiento.sDescripcionItem} |CC {asiento.sComprobante} {asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H||||{asiento.sFechaDocumento}|{asiento.sFechaDocumentoOrigen}|0";
        }
    }
}