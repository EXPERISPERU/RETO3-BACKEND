using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class Boletas
    {
        public Boletas() { }
        public string Debe(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||{asiento.nValorIgv}|{asiento.nPorcentageIgv}|{asiento.nValorTotal}|VTA|{asiento.nTipoCambio}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|D||||{asiento.sFechaDocumento}||0";
        }

        public string Igv(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||||{asiento.nValorIgv}|VTA|{asiento.nTipoCambio}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H||||{asiento.sFechaDocumento}||0";
        }

        public string Haber(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|||||{asiento.nValorSubTotal}|VTA|{asiento.nTipoCambio}|{asiento.sComprobante} / {asiento.sDescripcionItem} |{asiento.sInmueble} / PROYECTO: {asiento.sProyecto}|{asiento.bAnulado}|H|||{asiento.sCodProyecto}|{asiento.sFechaDocumento}||0";
        }
    }
}