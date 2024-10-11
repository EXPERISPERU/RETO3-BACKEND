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
        private readonly IProyectoRepository proyectoRepository;
        private readonly ILotesDisponiblesRepository loteDisponibleRepository;

        public MapaBL(IMapaRepository _repository, IProyectoRepository _proyectoRepository, ILotesDisponiblesRepository _loteDisponibleRepository)
        {
            repository = _repository;
            proyectoRepository = _proyectoRepository;
            loteDisponibleRepository = _loteDisponibleRepository;
        }

        public async Task<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>> getListLotes(int nIdCompania, int nIdUsuario, int nIdProyecto)
        {
            var lotes = await loteDisponibleRepository.getListLotesDisponibles(new SelectLotesDisponiblesDTO { nIdCompania = nIdCompania, nIdUsuario = nIdUsuario, PageNumber = 1, RowspPage = 10000, nIdProyecto = nIdProyecto });
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListLotes(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>>(pos);
            foreach (var lote in jres.features)
            {
                var found = lotes.FirstOrDefault(x => x.Id_Old == lote.properties.idinmueble);
                lote.properties.loteDisponible = new LotesDisponiblesDTO();
                if (found != null)
                {
                    lote.properties.idestado = found.nIdEstado.ToString();
                    lote.properties.estadoinmu = found.sEstado;
                    lote.properties.loteDisponible = found;
                }
                else
                {
                    lote.properties.idestado = "112";
                    lote.properties.loteDisponible.nIdEstado = 112;
                    lote.properties.loteDisponible.sEstado = "BLOQUEADO";
                }
            }
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>> getListManzanas(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListManzanas(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>> getListParques(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListParques(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>> getListEducacion(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListEducacion(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>> getListOtrosFines(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListOtrosFines(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>> getListRecreacion(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListRecreacion(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>> getListComercial(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListComercial(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>> getListServicios(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListServicios(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>> getListBermas(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListBermas(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>>(pos);
            return jres;
        }


        public async Task<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>> getListVias(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListVias(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>>(pos);
            return jres;
        }

        public async Task<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>> getListSectores(int nIdProyecto)
        {
            var proyecto = await proyectoRepository.getProyectoByID(nIdProyecto);
            var pos = await repository.getListSectores(proyecto.nCodigo);
            var jres = JsonConvert.DeserializeObject<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>>(pos);
            return jres;
        }

    }
}
