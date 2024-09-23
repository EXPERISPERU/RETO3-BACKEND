using backend.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IPreContratoLoteBL
    {
        Task<IList<SelectDTO>> getSelectPrecioPreContratoByLoteInicial(int nIdLote, decimal nValorInicial, int nIdMoneda);
        Task<SqlRspDTO> InsPreContratoLote(InsPreContratoLoteDTO insPreContratoLote);
        Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario);
        Task<ContratoDTO> getDataPreContratoByLote(int nIdLote, int nIdProyecto, int nIdUsuario);
        Task<IList<OrdenPagoPreContratoDTO>> getListOPsPreContratoByContrato(int nIdContrato, int nIdMoneda);
        Task<SqlRspDTO> postInsAdicPreContratoLote(InsPreContratoLoteDTO insPreContratoLote);
        Task<IList<PreContratoChartDTO>> postListPreContratoChart(PreContratoFilterDTO preContratoFilter);
    }
}
