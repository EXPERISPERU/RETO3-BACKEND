using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;

namespace backend.businesslogic.Comercial
{
    public class MapaBL : IMapaBL
    {
        private readonly IMapaRepository repository;
        
        public MapaBL(IMapaRepository _repository) 
        {
            repository = _repository;
        }

        public async Task<string> getListLotes()
        { 
            return await repository.getListLotes();
        }
    }
}
