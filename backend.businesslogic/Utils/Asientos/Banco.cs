using backend.domain;
using System.Globalization;

namespace backend.businesslogic.Utils.Asientos
{
    public class Banco
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");
        public Banco() { }
        public string Debe(AsientoBancoDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|TR|{asiento.sMovimiento}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}",  asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|D|003";
        }

        public string Haber(AsientoBancoDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:00.00}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|H|";
        }
    }
}