using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class VgEfectivo
    {
        CultureInfo ci_PE = new CultureInfo("es-PE");

        public VgEfectivo() { }

        public string Debe(VisitaGuiadaEfectivoDTO asiento, int indice)
        {
            return $"{asiento.sCajaEfectivo}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|D|||";
        }

        public string Haber(VisitaGuiadaEfectivoDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{string.Format(ci_PE, "{0:00.00}", asiento.nValorTotal)}|VTA|{asiento.sFechaDocumento}|{string.Format(ci_PE, "{0:0.000}", asiento.nTipoCambio)}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|H|||";
        }
    }
}