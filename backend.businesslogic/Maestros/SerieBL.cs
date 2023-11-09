using backend.businesslogic.Interfaces.Maestros;
using backend.domain;
using backend.repository.Interfaces.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.businesslogic.Maestros
{
    public class SerieBL : ISerieBL
    {
        ISerieRepository repository;
        public SerieBL(ISerieRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IList<SerieDTO>> getListSerie()
        {
            return await repository.getListSerie();
        }

        public async Task<SerieDTO> getSerieByID(int nIdSerie)
        {
            return await repository.getSerieByID(nIdSerie);
        }

        public async Task<IList<SelectDTO>> getSelectDocumento()
        {
            return await repository.getSelectDocumento();
        }

        public async Task<IList<SelectDTO>> getSelectCompania()
        {
            return await repository.getSelectCompania();        
        }

        public async Task<IList<SelectDTO>> getSelectOficinaByCompania(int nIdCompania)
        {
            return await repository.getSelectOficinaByCompania(nIdCompania);        
        }

        public async Task<IList<SelectDTO>> getSelectProyectoByCompania(int nIdCompania)
        {
            return await repository.getSelectProyectoByCompania(nIdCompania);        
        }

        public async Task<IList<SelectDTO>> getSelectUsuario()
        {
            return await repository.getSelectUsuario();        
        }

        public async Task<SqlRspDTO> InsSerie(SerieDTO serie)
        {
            return await repository.InsSerie(serie);
        }

        public async Task<SqlRspDTO> UpdSerie(SerieDTO serie)
        {
            return await repository.UpdSerie(serie);
        }
    }
}
