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

        public async Task<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>> getListLotes(int nIdProyecto)
        {
            var lotes = await loteRepository.getListLotes();
            var pos = await repository.getListLotes(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>>(pos);
            foreach (var lote in jres.features)
            {
                var found = lotes.First(x => x.Id_Old == lote.properties.idinmueble);
                lote.properties.loteDto = new LoteDTO();
                if (found != null)
                {
                    lote.properties.idestado = found.nIdEstado.ToString();
                    lote.properties.estadoinmu = found.sEstado;
                    lote.properties.loteDto = found;
                }
                else
                {
                    lote.properties.idestado = "112";
                    lote.properties.loteDto.nIdEstado = 112;
                    lote.properties.loteDto.sEstado = "BLOQUEADO";
                }

            }
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>> getListManzanas(int nIdProyecto)
        {
            var pos = await repository.getListManzanas(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>> getListParques(int nIdProyecto)
        {
            var pos = await repository.getListParques(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>> getListEducacion(int nIdProyecto)
        {
            var pos = await repository.getListEducacion(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>> getListOtrosFines(int nIdProyecto)
        {
            var pos = await repository.getListOtrosFines(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>> getListRecreacion(int nIdProyecto)
        {
            var pos = await repository.getListRecreacion(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>> getListComercial(int nIdProyecto)
        {
            var pos = await repository.getListComercial(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>> getListServicios(int nIdProyecto)
        {
            var pos = await repository.getListServicios(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>> getListBermas(int nIdProyecto)
        {
            var pos = await repository.getListBermas(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>>(pos);
            return jres;
        }


        public async Task<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>> getListVias(int nIdProyecto)
        {
            var pos = await repository.getListVias(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>> getListSectores(int nIdProyecto)
        {
            var pos = await repository.getListSectores(nIdProyecto);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

    }
}
