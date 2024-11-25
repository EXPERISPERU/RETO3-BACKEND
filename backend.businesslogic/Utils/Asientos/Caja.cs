using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class Caja
    {
        public Caja() { }

        public string Debe(AsientoCajaDTO asiento, int indice)
        {
            return $"{asiento.sCajaEfectivo}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{asiento.nValorTotal}|VTA|{asiento.sFechaDocumento}|{asiento.nValorIgv}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|D|";
        }

        public string Haber(AsientoCajaDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|{asiento.sTipoAnexo}|{asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? ""}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{asiento.nValorTotal}|VTA|{asiento.sFechaDocumento}|{asiento.nValorIgv}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|H|";
        }
    }
}
