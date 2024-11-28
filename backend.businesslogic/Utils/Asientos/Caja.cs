using backend.domain;
using System.Globalization;

namespace backend.businesslogic.Utils.Asientos
{
    public class Caja
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");

        public Caja() { }

        public string Debe(AsientoCajaDTO asiento, int indice)
        {
            return $"{asiento.sCajaEfectivo}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|D|";
        }

        public string Haber(AsientoCajaDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|H|";
        }
    }
}
