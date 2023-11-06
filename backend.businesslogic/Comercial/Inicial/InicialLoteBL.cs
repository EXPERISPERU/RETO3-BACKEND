using backend.businesslogic.Interfaces.Comercial.Inicial;
using backend.domain;
using backend.repository.Interfaces.Comercial.Descuento;
using backend.repository.Interfaces.Comercial.Inicial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.Inicial
{
    public class InicialLoteBL : IInicialLoteBL
    {
        IInicialLoteRepository repository;

        public InicialLoteBL(IInicialLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<InicialLoteDTO>> getListInicialLote()
        {
            return await repository.getListInicialLote();
        }

        public async Task<InicialLoteDTO> getInicialLoteByID(int nIdInicialLote)
        {
            return await repository.getInicialLoteByID(nIdInicialLote);
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectTipoValor()
        {
            return await repository.getSelectTipoValor();
        }

        public async Task<SqlRspDTO> InsInicialLote(InicialLoteDTO descuentoLote)
        {
            return await repository.InsInicialLote(descuentoLote);
        }

        public async Task<SqlRspDTO> UpdInicialLote(InicialLoteDTO descuentoLote)
        {
            return await repository.UpdInicialLote(descuentoLote);
        }

        public async Task<IList<SelectDTO>> getSelectMonedaByCompania(int nIdCompania)
        {
            return await repository.getSelectMonedaByCompania(nIdCompania);
        }
    }
}
