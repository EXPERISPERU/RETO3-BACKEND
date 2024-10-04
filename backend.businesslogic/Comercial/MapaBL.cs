using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Proyectos;

namespace backend.businesslogic.Comercial
{
    public class MapaBL : IMapaBL
    {
        private readonly IMapaRepository repository;
        private readonly ILoteRepository loteRepository;
        
        public MapaBL(IMapaRepository _repository, ILoteRepository _loteRepository) 
        {
            repository = _repository;
            loteRepository = _loteRepository;
        }

        public async Task<List<FeatureDTO>> getListLotes()
        {
            var lotes = await loteRepository.getListLotes();
            var pos = await repository.getListLotes();
            var jres = JsonConvert.DeserializeObject<List<FeatureDTO>>(pos);
            return "hola";
        }
    }
}
