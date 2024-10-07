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
            // foreach (var lote in jres.features)
            // {
            //     var found = lotes.First(x => x.Id_Old == lote.properties.idinmueble);
            //     lote.properties.loteSql = new LoteSqlDTO();
            //     if (found != null)
            //     {
            //         lote.properties.loteSql.estado = found.nIdEstado;
            //         lote.properties.loteSql.nombreEstado = found.sEstado;
            //         lote.properties.loteSql.metraje = found.nMetraje;
            //     }
            //     else
            //     {
            //         lote.properties.loteSql.estado = 112;
            //         lote.properties.loteSql.nombreEstado = "BLOQUEADO";
            //         lote.properties.loteSql.metraje = found.nMetraje;
            //     }

            // }
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaManzanaDTO>> getListManzanas()
        {
            var pos = await repository.getListManzanas();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaManzanaDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaParqueDTO>> getListParques()
        {
            var pos = await repository.getListParques();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaParqueDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaEducacionDTO>> getListEducacion()
        {
            var pos = await repository.getListEducacion();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaEducacionDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaOtrosFinesDTO>> getListOtrosFines()
        {
            var pos = await repository.getListOtrosFines();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaOtrosFinesDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaRecreacionDTO>> getListRecreacion()
        {
            var pos = await repository.getListRecreacion();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaRecreacionDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaComercialDTO>> getListComercial()
        {
            var pos = await repository.getListComercial();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaComercialDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaServicioDTO>> getListServicios()
        {
            var pos = await repository.getListServicios();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaServicioDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaBermaDTO>> getListBermas()
        {
            var pos = await repository.getListBermas();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaBermaDTO>>(pos);
            return jres;
        }


        public async Task<FeatureCollectionDTO<MapaViaDTO>> getListVias()
        {
            var pos = await repository.getListVias();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaViaDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaSectorDTO>> getListSectores()
        {
            var pos = await repository.getListSectores();
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaSectorDTO>>(pos);
            return jres;
        }

    }
}
