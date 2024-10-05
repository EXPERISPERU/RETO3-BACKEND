using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using backend.repository.Interfaces.Comercial;
using backend.repository.Interfaces.Proyectos;
using Newtonsoft.Json;

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

        public async Task<FeatureCollectionDTO<MapaLoteDTO>> getListLotes()
        {
            var lotes = await loteRepository.getListLotes();
            var pos = await repository.getListLotes();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaLoteDTO>>(pos);
            foreach (var lote in jres.features)
            {
                var found = lotes.First(x => x.Id_Old == lote.properties.idinmueble);
                lote.properties.loteSql = new LoteSqlDTO();
                if (found != null)
                {
                    lote.properties.loteSql.estado = found.nIdEstado;
                    lote.properties.loteSql.nombreEstado = found.sEstado;
                    lote.properties.loteSql.metraje = found.nMetraje;
                }
                else
                {
                    lote.properties.loteSql.estado = 112;
                    lote.properties.loteSql.nombreEstado = "BLOQUEADO";
                    lote.properties.loteSql.metraje = found.nMetraje;
                }

            }
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaManzanaDTO>> getListManzanas()
        {
            var pos = await repository.getListManzanas();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaManzanaDTO>>(pos);
            return jres;
        }
    }
}
