using backend.domain;

namespace backend.businesslogic.Interfaces.Comercial
{
    public interface IMapaBL
    {
        Task<FeatureCollectionDTO<MapaLoteDTO, MultiPolygonDTO>> getListLotes(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaManzanaDTO, MultiPolygonDTO>> getListManzanas(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaParqueDTO, MultiPolygonDTO>> getListParques(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaEducacionDTO, MultiPolygonDTO>> getListEducacion(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaOtrosFinesDTO, MultiPolygonDTO>> getListOtrosFines(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaRecreacionDTO, MultiPolygonDTO>> getListRecreacion(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaComercialDTO, MultiPolygonDTO>> getListComercial(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaServicioDTO, MultiPolygonDTO>> getListServicios(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaBermaDTO, MultiLineStringDTO>> getListBermas(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaSectorDTO, MultiPolygonDTO>> getListSectores(int nIdProyecto);
        Task<FeatureCollectionDTO<MapaViaDTO, MultiLineStringDTO>> getListVias(int nIdProyecto);

    }
}
