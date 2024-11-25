using backend.domain;

namespace backend.businesslogic.Utils.Asientos
{
    public class Boletas
    {
        public Boletas() { }
        public string Debe(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaContable}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|TR|{asiento.sMovimiento}|{asiento.sFechaDocumento}|MN|{asiento.nValorTotal}|VTA|{asiento.sFechaDocumento}|{asiento.nValorIgv}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|D|003";
        }

        public string Igv(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCuentaIgv}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|TR|{asiento.sMovimiento}|{asiento.sFechaDocumento}|MN|{asiento.nValorTotal}|VTA|{asiento.sFechaDocumento}|{asiento.nValorIgv}|{asiento.sDescripcionItem}||{asiento.sDescripcionItem}|{asiento.bAnulado}|D|003";
        }

        public string Haber(AsientoBoletasDTO asiento, int indice)
        {
            return $"{asiento.sCodAsientoProyecto}|{asiento.sAnioMes}|{asiento.sSubdiario}|{indice.ToString().PadLeft(4, '0')}|{asiento.sFechaDocumento}|02|{(asiento.sDNI ?? asiento.sRUC ?? asiento.sCE ?? "")}|{asiento.sAbrevTipoComprobante}|{asiento.sComprobante}|{asiento.sFechaDocumento}|MN|{asiento.nValorTotal}|VTA|{asiento.sFechaDocumento}|{asiento.nValorIgv}|{asiento.sDescripcionItem}||{asiento.sComprobante}|{asiento.bAnulado}|H|";
        }
    }
}