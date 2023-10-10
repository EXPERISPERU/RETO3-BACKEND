using backend.businesslogic.Interfaces.Comercial.Descuento;
using backend.domain;
using backend.repository.Interfaces.Comercial.Descuento;
using backend.repository.Interfaces.Comercial.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Comercial.Descuento
{
    public class DescuentoLoteBL : IDescuentoLoteBL
    {
        IDescuentoLoteRepository repository;

        public DescuentoLoteBL(IDescuentoLoteRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<DescuentoLoteDTO>> getListDescuentoLote()
        {
            return await repository.getListDescuentoLote();
        }

        public async Task<DescuentoLoteDTO> getDescuentoLoteByID(int nIdDescuentoLote)
        {
            return await repository.getDescuentoLoteByID(nIdDescuentoLote);
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);
        }

        public async Task<IList<SelectDTO>> getSelectCondicionPago()
        {
            return await repository.getSelectCondicionPago();
        }

        public async Task<IList<SelectDTO>> getSelectTipoDescuento()
        {
            return await repository.getSelectTipoDescuento();
        }

        public async Task<SqlRspDTO> InsDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            return await repository.InsDescuentoLote(descuentoLote);
        }

        public async Task<SqlRspDTO> UpdDescuentoLote(DescuentoLoteDTO descuentoLote)
        {
            return await repository.UpdDescuentoLote(descuentoLote);
        }
    }
}
