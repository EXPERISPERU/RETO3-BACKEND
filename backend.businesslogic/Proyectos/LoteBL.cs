using backend.businesslogic.Interfaces.Proyectos;
using backend.domain;
using backend.repository.Interfaces.Proyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Proyectos
{
    public class LoteBL : ILoteBL
    {
        ILoteRepository repository;

        public LoteBL(ILoteRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<IList<LoteDTO>> getListLotes()
        {
            return await repository.getListLotes();
        }

        public async Task<IList<LoteDTO>> getListLoteByManzana(int nIdManzana)
        {
            return await repository.getListLoteByManzana(nIdManzana);
        }

        public async Task<IList<SelectDTO>> getSelectEstadosEdicion()
        {
            return await repository.getSelectEstadosEdicion();
        }

        public async Task<SqlRspDTO> InsLote(LoteDTO lote)
        {
            return await repository.InsLote(lote);
        }

        public async Task<SqlRspDTO> UpdLote(LoteDTO lote)
        {
            return await repository.UpdLote(lote);
        }

    }
}
