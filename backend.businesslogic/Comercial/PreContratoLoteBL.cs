using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial
{
    public class PreContratoLoteBL : IPreContratoLoteBL
    {
        IPreContratoLoteRepository repository;

        public PreContratoLoteBL(IPreContratoLoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<SelectDTO>> getSelectPrecioPreContratoByLoteInicial(int nIdLote, decimal nValorInicial, int nIdMoneda)
        { 
            return await repository.getSelectPrecioPreContratoByLoteInicial(nIdLote, nValorInicial, nIdMoneda);
        }

        public async Task<SqlRspDTO> InsPreContratoLote(InsPreContratoLoteDTO insPreContratoLote)
        {
            return await repository.InsPreContratoLote(insPreContratoLote);
        }

        public async Task<IList<SelectDTO>> getSelectMedioPago(int nIdUsuario)
        {
            return await repository.getSelectMedioPago(nIdUsuario);
        }

        public async Task<ContratoDTO> getDataPreContratoByLote(int nIdLote, int nIdProyecto, int nIdUsuario)
        {
            return await repository.getDataPreContratoByLote(nIdLote, nIdProyecto, nIdUsuario);
        }

        public async Task<IList<OrdenPagoPreContratoDTO>> getListOPsPreContratoByContrato(int nIdContrato, int nIdMoneda)
        {
            return await repository.getListOPsPreContratoByContrato(nIdContrato, nIdMoneda);
        }

        public async Task<SqlRspDTO> postInsAdicPreContratoLote(InsAdicPreContratoLote insAdicPreContratoLote)
        {
            return await repository.postInsAdicPreContratoLote(insAdicPreContratoLote);
        }

        public async Task<IList<PreContratoChartDTO>> postListPreContratoChart(PreContratoFilterDTO preContratoFilter)
        {
            return await repository.postListPreContratoChart(preContratoFilter);
        }

    }
}
