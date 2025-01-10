using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class VgBBVA
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");

        public VgBBVA() { }

        public string Debe(VisitaGuiadaBbvaDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|TR|{asiento.sMovimiento}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|Cobro en Efectivo {asiento.sComprobante}|{asiento.bAnulado}|D|||";
        }

        public string Haber(VisitaGuiadaBbvaDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.000}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|Cobro en Efectivo {asiento.sComprobante}||{asiento.sComprobante}|{asiento.bAnulado}|H|||";
        }

    }
}